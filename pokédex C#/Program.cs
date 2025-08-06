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

            //Allenatore(string Nome, string Cognome, int età, float peso, float altezza, string sesso,string NickNameAllenatore,int IdAllenatore)
            Allenatore ash = new Allenatore("Ash", "Ketchum", 10, 50.0f, 1.5f, "M", "Ash007", 1);
            Allenatore gary = new Allenatore("Gary", "Oak", 10, 50.0f, 1.5f, "M", "Gary008", 1);


            //Pokemon(string nome, float peso, float altezza, string sesso, int IdDex, string tipoPrimario,string Impronta)
            Pokemon pikachu = new Pokemon("Pikachu", 6.0f, 0.4f, "M", 25, "Elettro", "scintilla");
            Pokemon bulbasaur = new Pokemon("Bulbasaur", 6.9f, 0.7f, "M", 1, "Erba", "foglia");
            Pokemon charmander = new Pokemon("Charmander", 7.1f, 0.6f, "F", 1, "FUOCO", "fiamma");
            //gli ultimi sono impronte ma non so come caazo fare

            
                         Console.WriteLine(ash.Saluta());

                        ash.Incontra(pikachu.Nome);
                        ash.Incontra(pikachu.Nome); // già incontrato
                                                    // --> incontro senza ridondanza perchè osservo dalla lista INCONTRI che tiene conto solo di incontri nuovi
                        ash.Incontra(bulbasaur.Nome);
                        ash.Incontra(charmander.Nome);

                        ash.Cattura(pikachu.Nome);
                        ash.CatturaFallita(pikachu.Nome); 

                        ash.Cattura(bulbasaur.Nome);
                        ash.CatturaFallita(charmander.Nome);

                        ash.MostraStato();

                        Console.WriteLine($"Totale incontri globali: {Allenatore.NumeroIncontri}");




            List<Pokemon> pokedex = new List<Pokemon>()
            {
                pikachu, bulbasaur, charmander,
                new Pokemon("Pikachu", 6.0f, 0.4f, "M", 25, "Elettro", "scintilla"),
                new Pokemon("Bulbasaur", 6.9f, 0.7f, "M", 1, "Erba", "foglia"),
                new Pokemon("Charmander", 7.1f, 0.6f, "F", 4, "Fuoco", "fiamma")
            };



        }
    }
}