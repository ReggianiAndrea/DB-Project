using System;
using System.Collections;
using System.Collections.Generic;
using POKEDEX_;

namespace POKEDEX
{
    class POKEDEX
    {
        static void Main(String[] args)
        {
            // esempio di test
            Allenatore ash = new Allenatore("Ash", "Ketchum", 10, 50.0f, 1.5f, "M", "Ash007", 1);

            Pokemon pikachu = new Pokemon("Pikachu", 6.0f, 0.4f, "M", 25, "Elettro", "🐾⚡");
            Pokemon bulbasaur = new Pokemon("Bulbasaur", 6.9f, 0.7f, "M", 1, "Erba", "🌱🐾");

            Console.WriteLine(ash.Saluta());

            ash.Incontra(pikachu.Nome);
            ash.Incontra(pikachu.Nome); // già incontrato
            ash.Incontra(bulbasaur.Nome);
            ash.MostraStato();

            Console.WriteLine($"Totale incontri globali: {Allenatore.NumeroIncontri}");
        }
    }
}