using System;
using System.Collections.Generic;

namespace PokedexADA.PokedexADA;

public partial class Giocatore
{
    public int IdGiocatore { get; set; }

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public string Nickname { get; set; } = null!;

    public string Immagine { get; set; } = null!;

    public int? IdEsemplarePreferito { get; set; }

    public virtual ICollection<Amicizium> AmiciziumIdGiocatoreAmicoNavigations { get; set; } = new List<Amicizium>();

    public virtual ICollection<Amicizium> AmiciziumIdGiocatoreNavigations { get; set; } = new List<Amicizium>();

    public virtual ICollection<BoxPokemon> BoxPokemons { get; set; } = new List<BoxPokemon>();

    public virtual ICollection<EsemplarePokemon> EsemplarePokemons { get; set; } = new List<EsemplarePokemon>();

    public virtual EsemplarePokemon? IdEsemplarePreferitoNavigation { get; set; }

    public virtual Squadra? Squadra { get; set; }

    public virtual ICollection<Pokemon> NumeroPokemons { get; set; } = new List<Pokemon>();

    public virtual ICollection<Pokemon> NumeroPokemonsNavigation { get; set; } = new List<Pokemon>();
}
