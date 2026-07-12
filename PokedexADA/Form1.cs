using PokedexADA.PokedexADA;

namespace PokedexADA
{
    public partial class Form1 : Form
    {
        // esempio di test
        Allenatore ash = new Allenatore("Ash", "Ketchum", Allenatore.Genere.MASCHIO, "Ash007", 1);
        List<Pokemon> pokedex = Database.Instance.GetPokedex();

        public Form1()
        {
            InitializeComponent();

            tabControl1.Selecting += new TabControlCancelEventHandler(tabControl1_Selecting);

            pokemonDisponibiliBox.Items.AddRange(pokedex.Select(p => p.Nome).ToArray());
            pokemonDisponibiliBox.SelectedItem = pokedex[0].Nome;

            outputBox.AppendText(ash.Saluta());

            foreach (Pokemon p in pokedex)
            {
                var item = new ListViewItem(new[] { p.NumeroPokemon.ToString(), p.Nome, "" });
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
            nome = "???";
            specie = "???";
            altezza = "???";
            peso = "???";
            impronta = "???";
            descrizione = "";
            pokedexPicture.Image = null;
            if (ash.PokemonIncontrati.Contains(pokemon.Nome))
            {
                nome = pokemon.Nome;
                specie = pokemon.Specie;
                pokedexPicture.Image = filterPicture(picture);
            }
            if (ash.PokemonCatturati.Contains(pokemon.Nome))
            {
                altezza = "" + pokemon.Altezza;
                peso = "" + pokemon.Peso;
                impronta = pokemon.Impronta;
                descrizione = pokemon.DescrizionePokemon;
                pokedexPicture.Image = picture;
            }
            pokemonLabel.Text = $"{pokemon.NumeroPokemon}: {nome}";
            speciePokemonLabel.Text = $"Pokemon: {specie}";
            altezzaPokemonLabel.Text = $"Altezza: {altezza} m";
            pesoPokemonLabel.Text = $"Peso: {peso} kg";
            improntaPokemonLabel.Text = $"Impronta: {impronta}";
            descrizionePokemonTextBox.Text = descrizione;
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
