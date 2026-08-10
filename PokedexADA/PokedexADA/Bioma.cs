using System;
using System.Collections.Generic;

namespace PokedexADA.PokedexADA;

public partial class Bioma
{
    public int IdBioma { get; set; }

    public string Habitat { get; set; } = null!;

    public string DescrizioneHabitat { get; set; } = null!;

    public virtual ICollection<Pokemon> NumeroPokemons { get; set; } = new List<Pokemon>();
}
