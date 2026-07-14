using System;
using System.Collections.Generic;
using System.Linq;

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

    public string Incontra(int numeroPokemon)
    {
        Pokemon p = (
            from pokemon in Database.Instance.Db.Pokemons
            where pokemon.NumeroPokemon == numeroPokemon
            select pokemon)
            .First();
        string output = "";
        if (NumeroPokemonAvvistati.Select(p => p.NumeroPokemon).Contains(numeroPokemon))
        {
            output += $"{p.Nome} è un Pokemon già incontrato\n";
        }
        else
        {
            NumeroPokemonAvvistati.Add(p);
            output += $"{p.Nome} è un Pokemon mai incontrato prima\n";
        }
        return output;
    }

    public string Cattura(int numeroPokemon)
    {
        Pokemon p = (
            from pokemon in Database.Instance.Db.Pokemons
            where pokemon.NumeroPokemon == numeroPokemon
            select pokemon)
            .First();
        string output = "";
        if (NumeroPokemonCatturati.Select(p => p.NumeroPokemon).Contains(numeroPokemon))
        {
            output += $"{p.Nome} è un Pokemon già catturato, ma {NumeroPokemonCatturati.Count} aumentato\n";
        }
        else
        {
            NumeroPokemonCatturati.Add(p);
            output += $"{Nickname} ha catturato il suo primo esemplare di {p.Nome}!\n";
        }
        return output;
    }

    public string CatturaFallita(int numeroPokemon)
    {
        Pokemon p = (
            from pokemon in Database.Instance.Db.Pokemons
            where pokemon.NumeroPokemon == numeroPokemon
            select pokemon)
            .First();
        string output = "";
        if (NumeroPokemonAvvistati.Select(p => p.NumeroPokemon).Contains(numeroPokemon))
        {
            output += $"Non importa, {p.Nome} lo abbiamo gia visto\n";
            if (NumeroPokemonCatturati.Select(p => p.NumeroPokemon).Contains(numeroPokemon))
            {
                output += "e anche catturato\n";
            }
        }
        else
        {
           NumeroPokemonAvvistati.Add(p);
            output += $"Era un {p.Nome} Pokemon mai incontrato prima, peccato\n";
        }
        return output;
    }

    public string MostraStato()
    {
        List<Pokemon> pokemonIncontrati = (
            from g in Database.Instance.Db.Giocatores
            from p in g.NumeroPokemonAvvistati
            select p)
            .ToList();
        List<Pokemon> pokemonCatturati = (
            from g in Database.Instance.Db.Giocatores
            from p in g.NumeroPokemonCatturati
            select p)
            .ToList();

        string output = $"Allenatore: {Nickname} (ID: {IdGiocatore})\n";

        output += $"Pokémon incontrati ({NumeroPokemonAvvistati.Count}):\n";
        if (NumeroPokemonAvvistati.Count == 0)
        {
            output += "— Nessun Pokémon incontrato.\n";
        }
        else
        {
            foreach (string nome in NumeroPokemonAvvistati.Select(p => p.Nome))
            {
                output += $"- {nome}\n";
            }
        }

        output += $"Pokémon catturati ({NumeroPokemonCatturati.Count}):\n";
        if (NumeroPokemonCatturati.Count == 0)
        {
            output += "Nessun Pokémon catturato.\n";
        }
        else
        {
            foreach (string nome in NumeroPokemonCatturati.Select(p => p.Nome))
            {
                output += $"- {nome}\n";
            }
        }

        return output;
    }
}
