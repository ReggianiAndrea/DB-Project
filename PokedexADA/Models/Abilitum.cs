using System;
using System.Collections.Generic;

namespace PokedexADA.Models;

public partial class Abilitum
{
    public string NomeAbilita { get; set; } = null!;

    public string DescrizioneAbilita { get; set; } = null!;

    public virtual ICollection<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
}
