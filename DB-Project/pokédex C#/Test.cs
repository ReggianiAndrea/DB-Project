using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POKEDEX_
{
    public class Test
    {
        /*
                     List<Pokemon> pokedex = new List<Pokemon>()
            {
                pikachu, bulbasaur, charmander
                new Pokemon("Pikachu", 6.0f, 0.4f, "M", 25, "Elettro", "scintilla"),
                new Pokemon("Bulbasaur", 6.9f, 0.7f, "M", 1, "Erba", "foglia"),
                new Pokemon("Charmander", 7.1f, 0.6f, "F", 4, "Fuoco", "fiamma") 
    };
            while (true)
            {
                Console.WriteLine("--MENU SELEZIONE POKEDEX");
                Console.WriteLine("1. MOSTRA STATO ALLENATORE");
                Console.WriteLine("2. INCONTRARE UN POKEMON");
                Console.WriteLine("3. TENTARE DI CATTURARE UN POKEMON");
                Console.WriteLine("4. ESCI");
                Console.WriteLine("SELEZIONE UNA DELLE OPZIONI:");
                string scelta= Console.ReadLine();
                Console.WriteLine("");
                switch (scelta)
                {
                    case "1":
                        ash.MostraStato();
                        Console.WriteLine("");
                        break;

                    case "2":
                        Console.WriteLine("Quale Pokémon vuoi incontrare?");
                        for (int i = 0; i < pokedex.Count; i++)
                            Console.WriteLine($"{i + 1}. {pokedex[i].Nome}");

                        Console.Write("Seleziona numero: ");
                        if (int.TryParse(Console.ReadLine(), out int numIncontro) &&
                            numIncontro >= 1 && numIncontro <= pokedex.Count)
                        {
                            ash.Incontra(pokedex[numIncontro - 1].Nome);
                        }
                        else
                        {
                            Console.WriteLine("Scelta non valida");
                        }
                        Console.WriteLine("");
                        break;

                    case "3":
                        Console.WriteLine("Quale Pokémon vuoi tentare di catturare?");
                        for (int i = 0; i < pokedex.Count; i++)
                            Console.WriteLine($"{i + 1}. {pokedex[i].Nome}");

                        Console.Write("Seleziona numero: ");
                        if (int.TryParse(Console.ReadLine(), out int numCattura) &&
                            numCattura >= 1 && numCattura <= pokedex.Count)
                        {
                            // Simuliamo cattura con probabilità semplice (es. 50%)
                            Random rnd = new Random();
                            bool successo = rnd.NextDouble() < 0.5;

                            if (successo)
                                ash.Cattura(pokedex[numCattura - 1].Nome);
                            else
                                ash.CatturaFallita(pokedex[numCattura - 1].Nome);
                        }
                        else
                        {
                            Console.WriteLine("Scelta non valida");
                        }
                        Console.WriteLine("");
                        break;

                    case "4":
                        Console.WriteLine("Uscita dal Pokédex. A presto!");
                        Console.WriteLine("");
                        return;

                    default:
                        Console.WriteLine("Opzione non valida, riprova.");
                        Console.WriteLine("");
                        break;
                }
            }
         */


    }
}
