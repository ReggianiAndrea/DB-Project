using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POKEDEX_
{
    public abstract class EssereVivente
    {
        public String Nome { get; set; }
        public float Peso { get; set; }
        public float Altezza { get; set; }
        public String Sesso { get; set; } //M, F, neutro

        public EssereVivente(string nome, float peso, float altezza, string sesso)
        {
            this.Nome = nome;
            this.Peso = peso;
            this.Altezza = altezza;
            this.Sesso = sesso;
        }

        public abstract string Comunica();
        //public abstract string OttieniImpronta();
    }
}
