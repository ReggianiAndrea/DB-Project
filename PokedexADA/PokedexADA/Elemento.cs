using System;
using System.Collections.Generic;

namespace PokedexADA.PokedexADA;

public partial class Elemento
{
    public int IdElemento { get; set; }

    public string Tipologia { get; set; } = null!;

    public virtual ICollection<Mossa> Mossas { get; set; } = new List<Mossa>();

    public virtual ICollection<Pokemon> PokemonIdElementoPrimarioNavigations { get; set; } = new List<Pokemon>();

    public virtual ICollection<Pokemon> PokemonIdElementoSecondarioNavigations { get; set; } = new List<Pokemon>();
}
