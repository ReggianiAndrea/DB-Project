using System;
using System.Collections.Generic;

namespace PokedexADA.PokedexADA;

public partial class Squadra
{
    public int IdGiocatore { get; set; }

    public virtual ICollection<Battaglium> BattagliumIdGiocatoreSfidanteNavigations { get; set; } = new List<Battaglium>();

    public virtual ICollection<Battaglium> BattagliumIdGiocatoreSfidatoNavigations { get; set; } = new List<Battaglium>();

    public virtual ICollection<EsemplarePokemon> EsemplarePokemons { get; set; } = new List<EsemplarePokemon>();

    public virtual Giocatore IdGiocatoreNavigation { get; set; } = null!;
}
