namespace PokedexADA
{
    public partial class Form1 : Form
    {
        // esempio di test
        Allenatore ash = new Allenatore("Ash", "Ketchum", 10, 50.0f, 1.5f, EssereVivente.Genere.MASCHIO, "Ash007", 1);

        Pokemon pikachu = new Pokemon("Pikachu", 25, 6.0f, 0.4f, "scintilla", EssereVivente.Genere.MASCHIO, Pokemon.Tipo.ELETTRO);
        Pokemon bulbasaur = new Pokemon("Bulbasaur", 1, 6.9f, 0.7f, "foglia", EssereVivente.Genere.MASCHIO, Pokemon.Tipo.ERBA, Pokemon.Tipo.VELENO);
        Pokemon charmander = new Pokemon("Charmander", 4, 7.1f, 0.6f, "fiamma", EssereVivente.Genere.FEMMINA, Pokemon.Tipo.FUOCO);

        List<Pokemon> pokedex;

        public Form1()
        {
            InitializeComponent();

            tabControl1.Selecting += new TabControlCancelEventHandler(tabControl1_Selecting);

            pokedex = new List<Pokemon> { pikachu, bulbasaur, charmander };
            pokedex.Sort((p1, p2) => p1.IdDex.CompareTo(p2.IdDex));

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
            Bitmap picture = (Bitmap) pokemonImageList.Images[index];
            if (!ash.PokemonIncontrati.Contains(pokemon.Nome))
            {
                picture = filterPicture(picture);
            }
            pokemonLabel.Text = $"{pokemon.IdDex} Pokemon: {pokemon.Nome}";
            if (ash.PokemonCatturati.Contains(pokemon.Nome))
            {
                altezzaPokemonLabel.Text = $"Altezza: {pokemon.Altezza} m";
                pesoPokemonLabel.Text = $"Peso: {pokemon.Peso} kg";
            }
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
