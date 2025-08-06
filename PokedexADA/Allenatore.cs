namespace PokedexADA
{
    internal class Allenatore : Persona
    {
        int IdAllenatore;
        string NickNameAllenatore;

        static public int NumeroIncontri = 0; //per statistiche globali (per statistiche amici)
        static public int NumeroCatture = 0;
        List<string> PokemonIncontrati = new List<string>();
        List<string> PokemonCatturati = new List<string>();

        public Allenatore(string nome, string cognome, int età, float peso, float altezza, Genere sesso, string nickNameAllenatore, int idAllenatore) : base(nome, cognome, età, peso, altezza, sesso)
        {
            NickNameAllenatore = nickNameAllenatore;
            IdAllenatore= idAllenatore;
        }

        public override string Saluta()
        {
            return $"sono l'allenatore {Nome} {Cognome}"; ; 
        }

        public string Incontra(string NomePokemon)
        {
            string output = "";
            NumeroIncontri++;
            if (PokemonIncontrati.Contains(NomePokemon))
            {
                output += $"{NomePokemon} è un Pokemon già incontrato\n";
            }
            else
            {
                PokemonIncontrati.Add(NomePokemon);
                output += $"{NomePokemon} è un Pokemon mai incontrato prima\n";
            }
            return output;
        }

        public string Cattura(string NomePokemon)
        {
            string output = "";
            NumeroCatture++;
            if (PokemonCatturati.Contains(NomePokemon))
            {
                output += $"{NomePokemon} è un Pokemon già catturato, ma {NumeroCatture} aumentato\n";
            }
            else
            {
                PokemonCatturati.Add(NomePokemon);
                output += $"{NickNameAllenatore} ha catturato il suo primo esemplare di {NomePokemon}!\n";
            }
            return output;
        }

        public string CatturaFallita(string NomePokemon)
        {
            string output = "";
            NumeroIncontri++;
            if (PokemonIncontrati.Contains(NomePokemon))
            {
                output += $"Non importa, {NomePokemon} lo abbiamo gia visto\n";
                if (PokemonCatturati.Contains(NomePokemon)) 
                {
                    output += "e anche catturato\n";
                }
            }
            else
            {
                PokemonIncontrati.Add(NomePokemon);
                output += $"Era un {NomePokemon} Pokemon mai incontrato prima,peccato\n";
            }
            return output;
        }

        public string MostraStato()
        {
            string output = $"Allenatore: {NickNameAllenatore} (ID: {IdAllenatore})\n";

            output += $"Pokémon incontrati ({PokemonIncontrati.Count}):\n";
            if (PokemonIncontrati.Count == 0)
            {
                output += "— Nessun Pokémon incontrato.\n";
            }
            else
            {
                foreach (var P_Incontrato in PokemonIncontrati)
                {
                    output += $"- {P_Incontrato}\n";
                }
            }

            output += $"Pokémon catturati ({PokemonCatturati.Count}):\n";
            
            if (PokemonCatturati.Count == 0)
            {
                output += "Nessun Pokémon catturato.\n";
            }
            else
            {
                foreach (var P_Catturato in PokemonCatturati)
                {
                    output += $"- {P_Catturato}-\n";
                }
            }

            output += $"Incontri globali: {NumeroIncontri}\n";
            output += $"Catture globali: {NumeroCatture}\n";

            return output;
        }
    }
}
