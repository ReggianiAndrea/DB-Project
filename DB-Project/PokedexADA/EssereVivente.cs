namespace PokedexADA
{
    public abstract class EssereVivente
    {
        public enum Genere
        {
            MASCHIO,
            FEMMINA,
            NEUTRALE
        }

        public string Nome { get; set; }
        public float Peso { get; set; }
        public float Altezza { get; set; }
        public Genere Sesso { get; set; }

        public EssereVivente(string nome, float peso, float altezza, Genere sesso)
        {
            Nome = nome;
            Peso = peso;
            Altezza = altezza;
            Sesso = sesso;
        }

        public abstract string Comunica();
    }
}
