using System.Runtime.InteropServices;

namespace PokedexADA
{
    public class Pokemon : EssereVivente
    {
        public enum Tipo
        {
            NORMALE, FUOCO, LOTTA, ACQUA,
            VOLANTE, ERBA, VELENO, ELETTRO,
            TERRA, PSICO, ROCCIA, GHIACCIO,
            COLEOTTERO, DRAGO, SPETTRO
        }

        public int IdDex { get; }
        public Tipo TipoPrimario { get; }
        public Tipo TipoSecondario { get; }
        public string Impronta { get; }

        private string verso;

        public Pokemon(string nome, int idDex, float peso, float altezza, string impronta, Genere sesso, Tipo tipoPrimario, [Optional] Tipo tipoSecondario)
            : base(nome, peso, altezza, sesso)
        {
            IdDex = idDex;
            TipoPrimario = tipoPrimario;
            TipoSecondario = tipoSecondario;
            Impronta = impronta;
            verso = $"{Nome} fa un verso selvaggio";
        }

        public override string Comunica()
        {
            return verso;
        }

        public string OttieniImpronta()
        {
            return $"il pokemon ha impronta {Impronta}";
        }
    }
}
