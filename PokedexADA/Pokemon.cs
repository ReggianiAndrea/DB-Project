using Mysqlx.Crud;
namespace PokedexADA
{
    public class Pokemon
    {
        public enum Tipo
        {
            NORMALE = 1, FUOCO, LOTTA, ACQUA,
            VOLANTE, ERBA, VELENO, ELETTRO,
            TERRA, PSICO, ROCCIA, GHIACCIO,
            COLEOTTERO, DRAGO, SPETTRO
        }

        public int IdDex { get; }
        public string Nome { get; }
        public float Peso { get; }
        public float Altezza { get; }
        public string Impronta { get; }
        public string Specie { get; }
        public string Descrizione { get; }
        public string Immagine { get; }
        public Tipo TipoPrimario { get; }
        public Tipo? TipoSecondario { get; }

        public Pokemon(string nome, int idDex, float altezza, float peso, string impronta, string specie, string descrizione, string immagine, Tipo tipoPrimario, Tipo? tipoSecondario)
        {
            Nome = nome;
            IdDex = idDex;
            Peso = peso;
            Altezza = altezza;
            Impronta = impronta;
            Specie = specie;
            Descrizione = descrizione;
            Immagine = immagine;
            TipoPrimario = tipoPrimario;
            TipoSecondario = tipoSecondario;
        }
    }
}
