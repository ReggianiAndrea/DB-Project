using System;
using System.Collections.Generic;

namespace PokedexADA.PokedexADA;

public partial class EsemplarePokemon
{
    public int IdEsemplare { get; set; }

    public string NomeAllenatore { get; set; } = null!;

    public string NomePrimoAllenatore { get; set; } = null!;

    public int Livello { get; set; }

    public DateTime DataCattura { get; set; }

    public string InBox { get; set; } = null!;

    public string Sesso { get; set; } = null!;

    public string Cromatico { get; set; } = null!;

    public int NumeroPokemon { get; set; }

    public int IdGiocatoreProprietario { get; set; }

    public int? IdSquadra { get; set; }

    public int? IdBox { get; set; }

    public virtual ICollection<Giocatore> Giocatores { get; set; } = new List<Giocatore>();

    public virtual BoxPokemon? IdBoxNavigation { get; set; }

    public virtual Giocatore IdGiocatoreProprietarioNavigation { get; set; } = null!;

    public virtual Squadra? IdSquadraNavigation { get; set; }

    public virtual Pokemon NumeroPokemonNavigation { get; set; } = null!;
}
