﻿namespace PokedexADA
{
    internal class Allenatore : Persona
    {
        private int idAllenatore;
        private string nickNameAllenatore;
        private List<string> pokemonIncontrati;
        private List<string> pokemonCatturati;

        public int NumeroIncontri { get; private set; }
        public int NumeroCatture { get; private set; }

        public Allenatore(string nome, string cognome, int età, float peso, float altezza, Genere sesso, string nickNameAllenatore, int idAllenatore)
            : base(nome, cognome, età, peso, altezza, sesso)
        {
            this.nickNameAllenatore = nickNameAllenatore;
            this.idAllenatore = idAllenatore;
            NumeroIncontri = 0;
            NumeroCatture = 0;
            pokemonIncontrati = new List<string>();
            pokemonCatturati = new List<string>();
        }

        public override string Saluta()
        {
            return $"sono l'allenatore {Nome} {Cognome}"; ; 
        }

        public string Incontra(string NomePokemon)
        {
            string output = "";
            NumeroIncontri++;
            if (pokemonIncontrati.Contains(NomePokemon))
            {
                output += $"{NomePokemon} è un Pokemon già incontrato\n";
            }
            else
            {
                pokemonIncontrati.Add(NomePokemon);
                output += $"{NomePokemon} è un Pokemon mai incontrato prima\n";
            }
            return output;
        }

        public string Cattura(string nomePokemon)
        {
            string output = "";
            NumeroCatture++;
            if (pokemonCatturati.Contains(nomePokemon))
            {
                output += $"{nomePokemon} è un Pokemon già catturato, ma {NumeroCatture} aumentato\n";
            }
            else
            {
                pokemonCatturati.Add(nomePokemon);
                output += $"{nickNameAllenatore} ha catturato il suo primo esemplare di {nomePokemon}!\n";
            }
            return output;
        }

        public string CatturaFallita(string nomePokemon)
        {
            string output = "";
            NumeroIncontri++;
            if (pokemonIncontrati.Contains(nomePokemon))
            {
                output += $"Non importa, {nomePokemon} lo abbiamo gia visto\n";
                if (pokemonCatturati.Contains(nomePokemon)) 
                {
                    output += "e anche catturato\n";
                }
            }
            else
            {
                pokemonIncontrati.Add(nomePokemon);
                output += $"Era un {nomePokemon} Pokemon mai incontrato prima,peccato\n";
            }
            return output;
        }

        public string MostraStato()
        {
            string output = $"Allenatore: {nickNameAllenatore} (ID: {idAllenatore})\n";

            output += $"Pokémon incontrati ({pokemonIncontrati.Count}):\n";
            if (pokemonIncontrati.Count == 0)
            {
                output += "— Nessun Pokémon incontrato.\n";
            }
            else
            {
                foreach (var incontrato in pokemonIncontrati)
                {
                    output += $"- {incontrato}\n";
                }
            }

            output += $"Pokémon catturati ({pokemonCatturati.Count}):\n";
            if (pokemonCatturati.Count == 0)
            {
                output += "Nessun Pokémon catturato.\n";
            }
            else
            {
                foreach (var incontrato in pokemonCatturati)
                {
                    output += $"- {incontrato}-\n";
                }
            }

            output += $"Incontri globali: {NumeroIncontri}\n";
            output += $"Catture globali: {NumeroCatture}\n";

            return output;
        }
    }
}
