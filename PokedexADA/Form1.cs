namespace PokedexADA
{
    public partial class Form1 : Form
    {
        private List<string> output = new List<string>();

        public Form1()
        {
            InitializeComponent();
            // esempio di test

            //Allenatore(string Nome, string Cognome, int età, float peso, float altezza, string sesso,string NickNameAllenatore,int IdAllenatore)
            Allenatore ash = new Allenatore("Ash", "Ketchum", 10, 50.0f, 1.5f, EssereVivente.Genere.MASCHIO, "Ash007", 1);
            Allenatore gary = new Allenatore("Gary", "Oak", 10, 50.0f, 1.5f, EssereVivente.Genere.MASCHIO, "Gary008", 1);

            //Pokemon(string nome, float peso, float altezza, string sesso, int IdDex, string tipoPrimario,string Impronta)
            Pokemon pikachu = new Pokemon("Pikachu", 25, 6.0f, 0.4f, "scintilla", EssereVivente.Genere.MASCHIO, Pokemon.Tipo.ELETTRO);
            Pokemon bulbasaur = new Pokemon("Bulbasaur", 1, 6.9f, 0.7f, "foglia", EssereVivente.Genere.MASCHIO, Pokemon.Tipo.ERBA, Pokemon.Tipo.VELENO);
            Pokemon charmander = new Pokemon("Charmander", 4, 7.1f, 0.6f, "fiamma", EssereVivente.Genere.FEMMINA, Pokemon.Tipo.FUOCO);

            output.Add(ash.Saluta());

            output.Add(ash.Incontra(pikachu.Nome));
            output.Add(ash.Incontra(pikachu.Nome)); // già incontrato
                                        // --> incontro senza ridondanza perchè osservo dalla lista INCONTRI che tiene conto solo di incontri nuovi
            output.Add(ash.Incontra(bulbasaur.Nome));
            output.Add(ash.Incontra(charmander.Nome));

            output.Add(ash.Cattura(pikachu.Nome));
            output.Add(ash.CatturaFallita(pikachu.Nome));

            output.Add(ash.Cattura(bulbasaur.Nome));
            output.Add(ash.CatturaFallita(charmander.Nome));

            output.Add(ash.MostraStato());

            output.Add($"Totale incontri globali: {Allenatore.NumeroIncontri}");

            output.ForEach(p => richTextBox1.Text += p + "\n");
        }
    }
}
