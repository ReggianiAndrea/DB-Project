using System;
using System.Collections.Generic;

namespace PokedexADA.PokedexADA;

public partial class Pokemon
{
    public int NumeroPokemon { get; set; }

    public int? NumeroPokemonStadioPrecedente { get; set; }

    public string Specie { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string DescrizionePokemon { get; set; } = null!;

    public float Altezza { get; set; }

    public float Peso { get; set; }

    public string Impronta { get; set; } = null!;

    public string Immagine { get; set; } = null!;

    public string ColoreDominante { get; set; } = null!;

    public int IdElementoPrimario { get; set; }

    public int? IdElementoSecondario { get; set; }

    public int IdStatistiche { get; set; }

    public string NomeAbilita { get; set; } = null!;

    public virtual ICollection<EsemplarePokemon> EsemplarePokemons { get; set; } = new List<EsemplarePokemon>();

    public virtual Evoluzione? EvoluzioneNumeroPokemonStadioCorrenteNavigation { get; set; }

    public virtual Evoluzione? EvoluzioneNumeroPokemonStadioSuccessivoNavigation { get; set; }

    public virtual Elemento IdElementoPrimarioNavigation { get; set; } = null!;

    public virtual Elemento? IdElementoSecondarioNavigation { get; set; }

    public virtual SetStatistiche IdStatisticheNavigation { get; set; } = null!;

    public virtual Pokemon? InverseNumeroPokemonStadioPrecedenteNavigation { get; set; }

    public virtual Abilita NomeAbilitaNavigation { get; set; } = null!;

    public virtual Pokemon? NumeroPokemonStadioPrecedenteNavigation { get; set; }

    public virtual ICollection<Bioma> IdBiomas { get; set; } = new List<Bioma>();

    public virtual ICollection<Giocatore> IdGiocatores { get; set; } = new List<Giocatore>();

    public virtual ICollection<Giocatore> IdGiocatoresNavigation { get; set; } = new List<Giocatore>();

    public virtual ICollection<Mossa> NomeMossas { get; set; } = new List<Mossa>();
}
