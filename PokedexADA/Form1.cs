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

            pokedex = new List<Pokemon> { pikachu, bulbasaur, charmander };

            pokemonDisponibiliBox.Items.AddRange(pokedex.Select(p => p.Nome).ToArray());
            pokemonDisponibiliBox.SelectedItem = pokedex[0].Nome;

            outputBox.AppendText(ash.Saluta());
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
            string nome = pokedex[pokemonDisponibiliBox.SelectedIndex].Nome;
            outputBox.Text = ash.Incontra(nome);
            if (new Random().NextDouble() < catchRate)
            {
                outputBox.Text += ash.Cattura(nome);
            }
            else
            {
                outputBox.Text += ash.CatturaFallita(nome);
            }
        }
    }
}
