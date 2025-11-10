namespace PokedexADA
{
    class Persona : EssereVivente
    {
        public string Cognome { get; set; }
        public int Età { get; set; }

        private string saluto;

        public Persona(string Nome,string Cognome,int Età, float Peso, float Altezza, Genere Sesso) : base (Nome,Peso,Altezza,Sesso)
        {
            this.Cognome = Cognome;
            this.Età = Età;
            saluto = $"ciao sono {Nome} {Cognome}";
        }

        public virtual string Saluta()
        {
            return saluto;
        }

        public override string Comunica()
        {
            return Saluta();
        }
    }
}


