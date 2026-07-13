using System;
using System.Collections.Generic;

namespace PokedexADA.PokedexADA;

public partial class BoxPokemon
{
    public int IdBox { get; set; }

    public int IdGiocatore { get; set; }

    public virtual ICollection<EsemplarePokemon> EsemplarePokemons { get; set; } = new List<EsemplarePokemon>();

    public virtual Giocatore IdGiocatoreNavigation { get; set; } = null!;
}
