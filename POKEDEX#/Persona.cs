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


            public void Set_Name(string nome)
            {
                this.Nome = Nome;
            }

            public string Get_Name()
            {
                return this.Nome;
            }

            public void Set_Età(int età)
            {
                    this.Età = età;
            }

            public int Get_Età()
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


