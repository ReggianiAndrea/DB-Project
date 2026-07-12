using System;
using System.Collections.Generic;

namespace PokedexADA.PokedexADA;

public partial class Mossa
{
    public string NomeMossa { get; set; } = null!;

    public string DescrizioneMossa { get; set; } = null!;

    public int Precisione { get; set; }

    public int? Danno { get; set; }

    public int IdElemento { get; set; }

    public virtual Elemento IdElementoNavigation { get; set; } = null!;

    public virtual ICollection<Pokemon> NumeroPokemons { get; set; } = new List<Pokemon>();
}
