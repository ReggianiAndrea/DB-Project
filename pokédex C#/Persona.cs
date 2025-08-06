using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POKEDEX_
{
        class Persona : EssereVivente
        {
            public string Cognome;
            public int Età;

            public Persona(string Nome,string Cognome,int Età, float Peso, float Altezza, string Sesso) : base (Nome,Peso,Altezza,Sesso)
            {
                this.Cognome = Cognome;
                this.Età = Età;
            }


            public void SetName(string nome)
            {
                this.Nome = Nome;
            }

            public string GetName()
            {
                return this.Nome;
            }

            public void SetEtà(int età)
            {
                    this.Età = età;
            }

            public int GetEtà()
            {
                return this.Età;
            }

            public virtual string Saluta()
            {
                string saluto=$"ciao sono {this.Nome} {this.Cognome}";
                return saluto;
            }

            public override string Comunica()
            {
                return Saluta();
            }


        }
}


