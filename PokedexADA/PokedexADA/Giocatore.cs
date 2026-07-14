using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace PokedexADA.PokedexADA;

public partial class Giocatore
{
    public int IdGiocatore { get; set; }

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public string Nickname { get; set; } = null!;

    public string Immagine { get; set; } = null!;

    public int? IdEsemplarePreferito { get; set; }

    public virtual ICollection<Amicizia> AmiciziaIdGiocatoreAmicoNavigations { get; set; } = new List<Amicizia>();

    public virtual ICollection<Amicizia> AmiciziaIdGiocatoreNavigations { get; set; } = new List<Amicizia>();

    public virtual ICollection<BoxPokemon> BoxPokemons { get; set; } = new List<BoxPokemon>();

    public virtual ICollection<EsemplarePokemon> EsemplarePokemons { get; set; } = new List<EsemplarePokemon>();

    public virtual EsemplarePokemon? IdEsemplarePreferitoNavigation { get; set; }

    public virtual Squadra? Squadra { get; set; }

    public virtual ICollection<Pokemon> NumeroPokemonAvvistati { get; set; } = new List<Pokemon>();

    public virtual ICollection<Pokemon> NumeroPokemonCatturati { get; set; } = new List<Pokemon>();

    public string AggiungiAmico(int idAmico)
    {
        return GestioneAmicizia(idAmico, true);
    }
    public string RimuoviAmico(int idAmico)
    {
        return GestioneAmicizia(idAmico, true);
    }

    private string GestioneAmicizia(int idAmico, bool aggiunto)
    {
        string output;
        using var db = new PokedexAdaContext();
        db.Database.EnsureCreated();
        Giocatore g = db.Giocatores.Where(go => go.IdGiocatore == idAmico).First();
        if (g == null)
        {
            output = "Giocatore con id " + idAmico + " non trovato";
            return output;
        }
        if (aggiunto)
        {
            Amicizia amicizia = new Amicizia();
            amicizia.IdGiocatore = IdGiocatore;
            amicizia.IdGiocatoreAmico = idAmico;
            db.Amicizia.Add(amicizia);
            output = "Giocatore " + g.Nickname +" aggiunto tra gli amici";
        }
        else
        {
            Amicizia amicizia = db.Amicizia.Where(am => am.IdGiocatore == IdGiocatore && am.IdGiocatoreAmico == idAmico).First();
            db.Amicizia.Remove(amicizia);
            output = "Giocatore " + g.Nickname + " rimosso dagli amici";
        }
        db.SaveChanges();
        return output;
    }

    public string BloccaAmico(int idAmico)
    {
        return GestioneBloccoAmico(idAmico, true);
    }

    public string SbloccaAmico(int idAmico)
    {
        return GestioneBloccoAmico(idAmico, false);
    }

    private string GestioneBloccoAmico(int idAmico, bool bloccato)
    {
        string output = "";
        using var db = new PokedexAdaContext();
        db.Database.EnsureCreated();
        Amicizia a = db.Amicizia.Where(am => am.IdGiocatore == IdGiocatore && am.IdGiocatoreAmico == idAmico).First();
        if (a != null)
        {
            a.Bloccato = bloccato;
            Giocatore amico = db.Giocatores.Where(g => g.IdGiocatore == idAmico).First();
            output = $"Amico {amico.Nickname} " + (bloccato ? "" : "s") + "bloccato con successo";
            db.SaveChanges();
        }
        else
        {
            output = "Amico con id " + idAmico + "non trovato";
        }
        return output;
    }

    public string Incontra(int numeroPokemon)
    {
        using var db = new PokedexAdaContext();
        db.Database.EnsureCreated();
        bool visto = (
            from g in db.Giocatores
            from pok in g.NumeroPokemonAvvistati
            where pok.NumeroPokemon == numeroPokemon
            select pok.NumeroPokemon)
            .Any();
        Pokemon p = (
            from pok in db.Pokemons
            where pok.NumeroPokemon == numeroPokemon
            select pok)
            .First();
        string output = "";
        if (visto)
        {
            output = $"{p.Nome} è un Pokemon già incontrato\n";
        }
        else
        {
            db.Database.ExecuteSql($"INSERT INTO AVVISTAMENTO VALUES ({IdGiocatore}, {numeroPokemon})");
            db.SaveChanges();
            output = $"{p.Nome} è un Pokemon mai incontrato prima\n";
        }
        return output;
    }

    public string TentaCattura(int numeroPokemon, double catchRate)
    {
        string output;
        if (new Random().NextDouble() < catchRate)
        {
            output = Cattura(numeroPokemon);
        }
        else
        {
            output = CatturaFallita(numeroPokemon);
        }
        return output;
    }

    private string Cattura(int numeroPokemon)
    {
        using var db = new PokedexAdaContext();
        db.Database.EnsureCreated();
        bool catturato = (
            from g in  db.Giocatores
            from pok in g.NumeroPokemonCatturati
            where pok.NumeroPokemon == numeroPokemon
            select pok.NumeroPokemon)
            .Any();
        Pokemon p = (
            from pokemon in db.Pokemons
            where pokemon.NumeroPokemon == numeroPokemon
            select pokemon)
            .First();
        string output;
        if (catturato)
        {
            output = $"{Nickname} ha catturato un {p.Nome}!\n";
        }
        else
        {
            db.Database.ExecuteSql($"INSERT INTO CATTURA VALUES ({IdGiocatore}, {p.NumeroPokemon})");
            db.SaveChanges();
            output = $"{Nickname} ha catturato il suo primo esemplare di {p.Nome}!\n";
        }
        return output;
    }

    private string CatturaFallita(int numeroPokemon)
    {
        using var db = new PokedexAdaContext();
        db.Database.EnsureCreated();
        bool visto = (
            from g in db.Giocatores
            from pok in g.NumeroPokemonAvvistati
            where pok.NumeroPokemon == numeroPokemon
            select pok.NumeroPokemon).Any();
        Pokemon p = (
            from pok in db.Pokemons
            where pok.NumeroPokemon == numeroPokemon
            select pok)
            .First();
        if (!visto)
        {
            db.Database.ExecuteSql($"INSERT INTO AVVISTAMENTO VALUES ({IdGiocatore}, {p.NumeroPokemon})");
            db.SaveChanges();
        }
        return $"{Nickname} ha fallito la cattura di {p.Nome}\n";
    }

    public string MostraStato()
    {
        using var db = new PokedexAdaContext();
        List<Pokemon> pokemonIncontrati = (
            from g in db.Giocatores
            from p in g.NumeroPokemonAvvistati
            select p)
            .ToList();
        List<Pokemon> pokemonCatturati = (
            from g in db.Giocatores
            from p in g.NumeroPokemonCatturati
            select p)
            .ToList();

        string output = $"Allenatore: {Nickname} (ID: {IdGiocatore})\n";

        output += $"Pokémon incontrati ({pokemonIncontrati.Count}):\n";
        if (pokemonIncontrati.Count == 0)
        {
            output += "— Nessun Pokémon incontrato.\n";
        }
        else
        {
            foreach (string nome in pokemonIncontrati.Select(p => p.Nome))
            {
                output += $"- {nome}\n";
            }
        }

        output += $"Pokémon catturati ({pokemonCatturati.Count}):\n";
        if (pokemonCatturati.Count == 0)
        {
            output += "Nessun Pokémon catturato.\n";
        }
        else
        {
            foreach (string nome in pokemonCatturati.Select(p => p.Nome))
            {
                output += $"- {nome}\n";
            }
        }

        return output;
    }
}
