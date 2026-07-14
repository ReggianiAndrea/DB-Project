using PokedexADA.PokedexADA;
using System.Linq;

namespace PokedexADA
{
    public partial class Form1 : Form
    {
        Dictionary<int, int> mapPokedexToGUIList = new Dictionary<int, int>();

        // esempio di test
        Giocatore ash = Database.GetGiocatore(1);
        List<Pokemon> pokedex = Database.GetPokedex();

        public Form1()
        {
            InitializeComponent();

            tabControl1.Selecting += new TabControlCancelEventHandler(tabControl1_Selecting);

            pokemonDisponibiliBox.Items.AddRange(pokedex.Select(p => p.Nome).ToArray());
            pokemonDisponibiliBox.SelectedItem = pokedex[0].Nome;

            foreach (Pokemon p in pokedex)
            {
                var item = new ListViewItem(new[] { p.NumeroPokemon.ToString(), p.Nome, "" });
                pokedexList.Items.Add(item);
                mapPokedexToGUIList.Add(p.NumeroPokemon, pokedexList.Items.Count - 1);
            }
        }

        private void MostraStatoButtonOnClick(object sender, EventArgs e)
        {
            outputBox.Text = ash.MostraStato();
        }

        private void CercaPokemonSelezionatoButtonOnClick(object sender, EventArgs e)
        {
            outputBox.Text = ash.Incontra(pokedex[pokemonDisponibiliBox.SelectedIndex].NumeroPokemon);
        }

        private void CercaPokemonButtonOnClick(object sender, EventArgs e)
        {
            int id = new Random().Next(pokedex.Count);
            Pokemon pokemon = pokedex[id];
            pokemonDisponibiliBox.SelectedIndex = id;
            outputBox.Text = ash.Incontra(pokemon.NumeroPokemon);
        }

        private void TentaCatturaButtonOnClick(object sender, EventArgs e)
        {
            double catchRate = 0.5;
            int id = pokemonDisponibiliBox.SelectedIndex;
            Pokemon pokemon = pokedex[id];
            string nome = pokedex[id].Nome;
            outputBox.Text = ash.Incontra(pokemon.NumeroPokemon);
            if (new Random().NextDouble() < catchRate)
            {
                outputBox.Text += ash.Cattura(pokemon.NumeroPokemon);
            }
            else
            {
                outputBox.Text += ash.CatturaFallita(pokemon.NumeroPokemon);
            }
        }

        private void pokedexList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pokedexList.SelectedItems.Count == 0)
                return;

            int id = pokedexList.SelectedItems[0].Index;
            Pokemon pokemon = pokedex[id];
            Bitmap picture = (Bitmap)Image.FromFile(@"..\..\..\res\" + pokemon.Immagine);
            string nome, specie, altezza, peso, impronta, descrizione;
            nome = "???";
            specie = "???";
            altezza = "???";
            peso = "???";
            impronta = "???";
            descrizione = "";
            pokedexPicture.Image = null;
            if (ash.NumeroPokemonAvvistati.Select(p => p.NumeroPokemon).Contains(pokemon.NumeroPokemon))
            {
                nome = pokemon.Nome;
                specie = pokemon.Specie;
                pokedexPicture.Image = filterPicture(picture);
            }
            if (ash.NumeroPokemonCatturati.Select(p => p.NumeroPokemon).Contains(pokemon.NumeroPokemon))
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

            foreach (Pokemon p in pokedex)
            {
                string status;
                if (ash.NumeroPokemonCatturati.Select(p => p.NumeroPokemon).Contains(p.NumeroPokemon))
                {
                    status = "x";
                }
                else if (ash.NumeroPokemonAvvistati.Select(p => p.NumeroPokemon).Contains(p.NumeroPokemon))
                {
                    status = "o";
                }
                else
                {
                    status = "";
                }
                int index = mapPokedexToGUIList[p.NumeroPokemon];
                pokedexList.Items[index].SubItems[2].Text = status;
            }
        }
    }

}
