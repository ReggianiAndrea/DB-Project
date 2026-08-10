using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POKEDEX_
{
    internal class Allenatore : Persona, I_Incontra, I_Cattura, I_CatturaFallita
    {
        int IdAllenatore;
        string NickNameAllenatore;

        static public int NumeroIncontri = 0; //per statistiche globali (per statistiche aamici)
        static public int NumeroCatture = 0;
        List<string> PokemonIncontrati = new List<string>();
        List<string> PokemonCatturati = new List<string>();

        public Allenatore(string Nome, string Cognome, int età, float peso, float altezza, string sesso,string NickNameAllenatore,int IdAllenatore) : base(Nome, Cognome, età, peso, altezza, sesso)
        {
            this.NickNameAllenatore = NickNameAllenatore;
            this.IdAllenatore= IdAllenatore;
        }

        public override string Saluta()
        {
            string NewSaluto= $"sono l'allenatore {this.Nome} {this.Cognome}";
            //return base.Comunica();
            return NewSaluto; 
        }
        public void Incontra(string NomePokemon)
        {
            NumeroIncontri++;
            if (PokemonIncontrati.Contains(NomePokemon))
            {
                Console.WriteLine($"{NomePokemon} è un Pokemon già incontrato");
            }
            else
            {
                PokemonIncontrati.Add(NomePokemon);
                Console.WriteLine($"{NomePokemon} è un Pokemon mai incontrato prima");
            }

        }

        public void Cattura(string NomePokemon)
        {
            NumeroCatture++;
            if (PokemonCatturati.Contains(NomePokemon))
            {
                Console.WriteLine($"{NomePokemon} è un Pokemon già catturato, ma {NumeroCatture} aumentato");
            }else
            {
                PokemonCatturati.Add(NomePokemon);
                Console.WriteLine($"{NickNameAllenatore} ha catturato il suo primo esemplare di {NomePokemon}!");
            }
        }

        public void CatturaFallita(string NomePokemon)
        {
            NumeroIncontri++;
            if (PokemonIncontrati.Contains(NomePokemon))
            {
                Console.WriteLine("Non importa,lo abbiamo gia visto");
                if(PokemonCatturati.Contains(NomePokemon)) 
                {
                    Console.WriteLine("e anche catturato");
                }
            }
            else
            {
                PokemonIncontrati.Add(NomePokemon);
                Console.WriteLine($"Era un {NomePokemon} Pokemon mai incontrato prima,peccato");
            }
        }

        public void MostraStato()
        {
            Console.WriteLine($"Allenatore: {NickNameAllenatore} (ID: {IdAllenatore})");

            Console.WriteLine($"Pokémon incontrati ({PokemonIncontrati.Count}):");
            if (PokemonIncontrati.Count == 0)
            {
                Console.WriteLine("— Nessun Pokémon incontrato.");
            } else
                {
                foreach (var P_Incontrato in PokemonIncontrati)
                    Console.WriteLine($"- {P_Incontrato}");
                
            }
            Console.WriteLine($"Pokémon catturati ({PokemonCatturati.Count}):");

            if (PokemonCatturati.Count == 0)
            {
                Console.WriteLine("Nessun Pokémon catturato.");
            }else
                {
                foreach (var P_Catturato in PokemonCatturati)
                    Console.WriteLine($"- {P_Catturato}-");
                }

            Console.WriteLine($"Incontri globali: {NumeroIncontri}");
            Console.WriteLine($"Catture globali: {NumeroCatture}");
        }


    }
}
