using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using MySql.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokedexADA.PokedexADA;

public partial class Pokemon
{
    public int NumeroPokemon { get; set; }

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

    public int NumeroSceltePreferito { get; set; } = 0;

    public virtual ICollection<EsemplarePokemon> EsemplarePokemons { get; set; } = new List<EsemplarePokemon>();

    public virtual ICollection<Evoluzione> EvoluzioneNumeroPokemonStadioCorrenteNavigations { get; set; } = new List<Evoluzione>();

    public virtual Evoluzione? EvoluzioneNumeroPokemonStadioSuccessivoNavigation { get; set; }

    public virtual Elemento IdElementoPrimarioNavigation { get; set; } = null!;

    public virtual Elemento? IdElementoSecondarioNavigation { get; set; }

    public virtual SetStatistiche IdStatisticheNavigation { get; set; } = null!;

    public virtual Abilita NomeAbilitaNavigation { get; set; } = null!;

    public virtual ICollection<Bioma> IdBiomas { get; set; } = new List<Bioma>();

    public virtual ICollection<Giocatore> IdGiocatores { get; set; } = new List<Giocatore>();

    public virtual ICollection<Giocatore> IdGiocatoresNavigation { get; set; } = new List<Giocatore>();

    public virtual ICollection<Mossa> NomeMossas { get; set; } = new List<Mossa>();

    public List<Mossa> GetMosseApprendibili()
    {
        using var db = new PokedexAdaContext();
        List<Mossa> mosseApprendibili = (
            from p in db.Pokemons
            from m in p.NomeMossas
            where p.NumeroPokemon == NumeroPokemon
            select m)
            .ToList();
        return mosseApprendibili;
    }

    public List<Evoluzione> GetLineaEvolutiva()
    {
        using var db = new PokedexAdaContext();
        using var conn = new MySqlConnection("Server=localhost;Port=3306;Database=pokedexada;User=root;Password=;");
        conn.Open();
        string sql = $@"with recursive base as (
	            select e.numeropokemon, p.numeropokemon numeropokemonevo, ev.idmetodo
	            from pokemon p
                join evoluzione ev on ev.numeropokemonstadiosuccessivo = p.numeropokemon
                join pokemon e on ev.numeropokemonstadiocorrente = e.numeropokemon
	            where e.numeropokemon = (
		            with recursive base as (
			            select p.numeropokemon, e.numeropokemon numeropokemonevo
			            from pokemon p
			            left join evoluzione ev on ev.numeropokemonstadiocorrente = p.numeropokemon
			            left join pokemon e on ev.numeropokemonstadiosuccessivo = e.numeropokemon
			            where p.numeropokemon = {NumeroPokemon}
			            union all
			            select p.numeropokemon, e.numeropokemon numeropokemonevo
			            from pokemon p
			            left join evoluzione ev on ev.numeropokemonstadiocorrente = p.numeropokemon
			            inner join base e on ev.numeropokemonstadiosuccessivo = e.numeropokemon
		            )
		            select numeropokemon from base order by numeropokemon limit 1
                )
	            union all
	            select e.numeropokemonevo, p.numeropokemon, ev.idmetodo
	            from pokemon p
                join evoluzione ev on ev.numeropokemonstadiosuccessivo = p.numeropokemon
                inner join base e on ev.numeropokemonstadiocorrente = e.numeropokemonevo
            )
            select * from base;";
        var reader = new MySqlCommand(sql, conn).ExecuteReader();
        List<Evoluzione> lineaEvolutiva = new List<Evoluzione>();
        while (reader.Read()) {
            Evoluzione e = (
                from evo in db.Evoluziones
                where evo.NumeroPokemonStadioCorrente == reader.GetInt32("numeropokemon")
                && evo.NumeroPokemonStadioSuccessivo == reader.GetInt32("numeropokemonevo")
                && evo.IdMetodo == reader.GetInt32("idmetodo")
                select evo
            ).First();
            lineaEvolutiva.Add(e);
        }
        return lineaEvolutiva;
    }
}
