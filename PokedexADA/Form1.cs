using MySql.Data;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

namespace PokedexADA
{
    public partial class Form1 : Form
    {
        // esempio di test
        Allenatore ash = new Allenatore("Ash", "Ketchum", 10, 50.0f, 1.5f, EssereVivente.Genere.MASCHIO, "Ash007", 1);
        List<Pokemon> pokedex;

        public Form1()
        {
            MySqlConnection db = new MySqlConnection("Server=localhost; Database=PokedexADA; Uid=root; Password=;");
            db.Open();

            InitializeComponent();

            tabControl1.Selecting += new TabControlCancelEventHandler(tabControl1_Selecting);

            MySqlCommand cmd = new MySqlCommand("select * from pokemon", db);
            MySqlDataReader q = cmd.ExecuteReader();
            pokedex = new List<Pokemon>();
            while (q.Read())
            {
                Pokemon p = new Pokemon((string)q["nome"], (int)q["numeropokemon"], (float)q["altezza"], (float)q["peso"],
                    (string)q["impronta"], (string)q["specie"], (string)q["descrizionepokemon"], (string)q["immagine"],
                    (Pokemon.Tipo)q["idelementoprimario"],
                    (q["idelementosecondario"] is System.DBNull ? null : (Pokemon.Tipo)q["idelementosecondario"]));
                pokedex.Add(p);
            }
            q.Close();


            pokemonDisponibiliBox.Items.AddRange(pokedex.Select(p => p.Nome).ToArray());
            pokemonDisponibiliBox.SelectedItem = pokedex[0].Nome;

            outputBox.AppendText(ash.Saluta());

            foreach (Pokemon p in pokedex)
            {
                var item = new ListViewItem(new[] { p.IdDex.ToString(), p.Nome, "" });
                pokedexList.Items.Add(item);
            }
        }

        private void MostraStatoButtonOnClick(object sender, EventArgs e)
        {
            outputBox.Text = ash.MostraStato();
        }

        private void CercaPokemonSelezionatoButtonOnClick(object sender, EventArgs e)
        {
            outputBox.Text = ash.Incontra(pokedex[pokemonDisponibiliBox.SelectedIndex].Nome);
        }

        private void CercaPokemonButtonOnClick(object sender, EventArgs e)
        {
            int index = new Random().Next(pokedex.Count);
            string nome = pokedex[index].Nome;
            pokemonDisponibiliBox.SelectedIndex = index;
            outputBox.Text = ash.Incontra(nome);
        }

        private void TentaCatturaButtonOnClick(object sender, EventArgs e)
        {
            double catchRate = 0.5;
            int id = pokemonDisponibiliBox.SelectedIndex;
            string nome = pokedex[id].Nome;
            outputBox.Text = ash.Incontra(nome);
            if (new Random().NextDouble() < catchRate)
            {
                outputBox.Text += ash.Cattura(nome);
                pokedexList.Items[id].SubItems[2].Text = "x";
            }
            else
            {
                outputBox.Text += ash.CatturaFallita(nome);
            }
        }

        private void pokedexList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pokedexList.SelectedItems.Count == 0)
                return;

            int index = pokedexList.SelectedItems[0].Index;
            Pokemon pokemon = pokedex[index];
            Bitmap picture = (Bitmap)Image.FromFile(@"..\..\..\res\" + pokemon.Immagine);
            string nome, specie, altezza, peso, impronta, descrizione;
            if (!ash.PokemonIncontrati.Contains(pokemon.Nome))
            {
                picture = filterPicture(picture);
                nome = "???";
                specie = "???";
                altezza = "???";
                peso = "???";
                impronta = "???";
                descrizione = "";
            }
            else
            {
                nome = pokemon.Nome;
                specie = pokemon.Specie;
                altezza = "" + pokemon.Altezza;
                peso = "" + pokemon.Peso;
                impronta = pokemon.Impronta;
                descrizione = pokemon.Descrizione;
            }
            pokemonLabel.Text = $"{pokemon.IdDex}: {nome}";
            speciePokemonLabel.Text = $"Pokemon: {specie}";
            altezzaPokemonLabel.Text = $"Altezza: {altezza} m";
            pesoPokemonLabel.Text = $"Peso: {peso} kg";
            improntaPokemonLabel.Text = $"Impronta: {impronta}";
            descrizionePokemonTextBox.Text = descrizione;
            pokedexPicture.Image = picture;
        }

        private Bitmap filterPicture(Bitmap picture)
        {
            Bitmap filteredPicture = new Bitmap(picture.Width, picture.Height);
            for (int y = 0; y < filteredPicture.Height; y++)
            {
                for (int x = 0; x < filteredPicture.Width; x++)
                {
                    Color px = picture.GetPixel(x, y);
                    if (px.A != 0)
                    {
                        px = Color.Gray;
                    }
                    filteredPicture.SetPixel(x, y, px);
                }
            }
            return filteredPicture;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            pokedexPicture.Image = new Bitmap(pokedexPicture.Width, pokedexPicture.Height);
            pokedexList.SelectedItems.Clear();
        }
    }

}
