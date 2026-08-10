using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexADA
{
    // Interfacce per gestire Pokemon selvatici
    public interface IWildPokemonInteraction
    {
        string Incontra(string nomePokemon);
        string Cattura(string nomePokemon);
        string CatturaFallita(string nomePokemon);
    }

    // Interfacce per gestire il team (da implementare dopo)
    public interface ITeamManager
    {
        void AggiungiAlTeam(Pokemon pokemon);
        void ScambiaConBox(int posizioneTeam, int posizioneBox);
    }

    // Interfacce per gestire il box (da implementare dopo)
    public interface IBoxManager
    {
        void AggiungiAlBox(Pokemon pokemon);
        List<Pokemon> GetTuttiPokemonBox();
    }

    public class PokemonManager : IWildPokemonInteraction
    {
        // Proprietà pubbliche (come in Allenatore)
        public int NumeroIncontri { get; private set; }
        public int NumeroCatture { get; private set; }
        public List<string> PokemonIncontrati { get; private set; }
        public List<string> PokemonCatturati { get; private set; }

        private string nickNameAllenatore;

        // Costruttore
        public PokemonManager(string nickNameAllenatore)
        {
            this.nickNameAllenatore = nickNameAllenatore;
            NumeroIncontri = 0;
            NumeroCatture = 0;
            PokemonIncontrati = new List<string>();
            PokemonCatturati = new List<string>();
        }

        public string Incontra(string nomePokemon)
        {
            string output = "";
            NumeroIncontri++;
            if (PokemonIncontrati.Contains(nomePokemon))
            {
                output += $"{nomePokemon} è un Pokemon già incontrato\n";
            }
            else
            {
                PokemonIncontrati.Add(nomePokemon);
                output += $"{nomePokemon} è un Pokemon mai incontrato prima\n";
            }
            return output;
        }

        public string Cattura(string nomePokemon)
        {
            string output = "";
            NumeroCatture++;
            if (PokemonCatturati.Contains(nomePokemon))
            {
                output += $"{nomePokemon} è un Pokemon già catturato, ma {NumeroCatture} aumentato\n";
            }
            else
            {
                PokemonCatturati.Add(nomePokemon);
                output += $"{nickNameAllenatore} ha catturato il suo primo esemplare di {nomePokemon}!\n";
            }
            return output;
        }

        public string CatturaFallita(string nomePokemon)
        {
            string output = "";
            NumeroIncontri++;
            if (PokemonIncontrati.Contains(nomePokemon))
            {
                output += $"Non importa, {nomePokemon} lo abbiamo gia visto\n";
                if (PokemonCatturati.Contains(nomePokemon))
                {
                    output += "e anche catturato\n";
                }
            }
            else
            {
                PokemonIncontrati.Add(nomePokemon);
                output += $"Era un {nomePokemon} Pokemon mai incontrato prima,peccato\n";
            }
            return output;
        }
    }
}