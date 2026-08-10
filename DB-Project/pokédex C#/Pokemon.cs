using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace POKEDEX_
{
    public class Pokemon : EssereVivente
    {
        public int IdDex;
        public string tipoPrimario;
        public string verso;
        public string Impronta;

        public Pokemon(string nome, float peso, float altezza, string sesso, int IdDex, string tipoPrimario,string Impronta) : base(nome, peso, altezza, sesso)
        {
            this.IdDex = IdDex;
            this.tipoPrimario = tipoPrimario;
            this.Impronta = Impronta;
        }

        public override string Comunica()
        {
            verso = $"{this.Nome} fa un verso selvaggio";
            return verso;
        }
        public string OttieniImpronta()
        {
            return $"il pokemon ha impronta {this.Impronta}";
        }
    }
}
