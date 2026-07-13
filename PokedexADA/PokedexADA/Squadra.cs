using System;
using System.Collections.Generic;

namespace PokedexADA.PokedexADA;

public partial class Squadra
{
    public int IdGiocatore { get; set; }

    public virtual ICollection<Battaglia> BattagliaIdGiocatoreSfidanteNavigations { get; set; } = new List<Battaglia>();

    public virtual ICollection<Battaglia> BattagliaIdGiocatoreSfidatoNavigations { get; set; } = new List<Battaglia>();

    public virtual ICollection<EsemplarePokemon> EsemplarePokemons { get; set; } = new List<EsemplarePokemon>();

    public virtual Giocatore IdGiocatoreNavigation { get; set; } = null!;
}
