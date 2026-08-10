using System;
using System.Collections.Generic;

namespace PokedexADA.PokedexADA;

public partial class SetStatistiche
{
    public int IdStatistiche { get; set; }

    public int Attacco { get; set; }

    public int Difesa { get; set; }

    public int PuntiSalute { get; set; }

    public int AttaccoSpeciale { get; set; }

    public int DifesaSpeciale { get; set; }

    public int Velocita { get; set; }

    public virtual ICollection<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
}
