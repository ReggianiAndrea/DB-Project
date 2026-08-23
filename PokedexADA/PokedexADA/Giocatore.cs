using Microsoft.EntityFrameworkCore;

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

    public bool AggiungiAmico(int idAmico)
    {
        return GestioneAmicizia(idAmico, true);
    }
    public bool RimuoviAmico(int idAmico)
    {
        return GestioneAmicizia(idAmico, false);
    }

    private bool GestioneAmicizia(int idAmico, bool aggiunto)
    {
        using var db = new PokedexAdaContext();
        db.Database.EnsureCreated();
        Giocatore g = db.Giocatores.Where(go => go.IdGiocatore == idAmico).First();
        if (g == null)
        {
            return false;
        }
        try
        {
            if (aggiunto)
            {
                Amicizia amicizia = new Amicizia();
                amicizia.IdGiocatore = IdGiocatore;
                amicizia.IdGiocatoreAmico = idAmico;
                db.Amicizia.Add(amicizia);
            }
            else
            {
                Amicizia amicizia = db.Amicizia.Where(am => am.IdGiocatore == IdGiocatore && am.IdGiocatoreAmico == idAmico).First();
                db.Amicizia.Remove(amicizia);
            }
        }
        catch
        {
            return false;
        }
        finally
        {
            db.SaveChanges();
        }
        return true;
    }

    public void CambiaImmagineProfilo(string path)
    {
        using var db = new PokedexAdaContext();
        db.Database.EnsureCreated();
        try
        {
            Immagine = path;
            db.Giocatores.Update(this);
        }
        finally
        {
            db.SaveChanges();
        }
    }

    public bool BloccaAmico(int idAmico)
    {
        return GestioneBloccoAmico(idAmico, true);
    }

    public bool SbloccaAmico(int idAmico)
    {
        return GestioneBloccoAmico(idAmico, false);
    }

    private bool GestioneBloccoAmico(int idAmico, bool bloccato)
    {
        using var db = new PokedexAdaContext();
        db.Database.EnsureCreated();
        Amicizia a = db.Amicizia.Where(am => am.IdGiocatore == IdGiocatore && am.IdGiocatoreAmico == idAmico).First();
        if (a != null)
        {
            a.Bloccato = bloccato;
            Giocatore amico = db.Giocatores.Where(g => g.IdGiocatore == idAmico).First();
            db.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Incontra(int numeroPokemon)
    {
        using var db = new PokedexAdaContext();
        db.Database.EnsureCreated();
        bool visto = (
            from g in db.Giocatores
            from pok in g.NumeroPokemonAvvistati
            where pok.NumeroPokemon == numeroPokemon
            select pok.NumeroPokemon)
            .Any();
        if (!visto)
        {
            db.Database.ExecuteSql($"INSERT INTO AVVISTAMENTO VALUES ({IdGiocatore}, {numeroPokemon})");
            db.SaveChanges();
        }
    }

    public bool TentaCattura(EsemplarePokemon pokemon, double catchRate)
    {
        if (new Random().NextDouble() < catchRate)
        {
            Cattura(pokemon);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Cattura(EsemplarePokemon pokemon)
    {
        using var db = new PokedexAdaContext();
        db.Database.EnsureCreated();
        bool catturato = (
            from g in db.Giocatores
            from pok in g.NumeroPokemonCatturati
            where pok.NumeroPokemon == pokemon.NumeroPokemon
            select pok.NumeroPokemon)
            .Any();
        int numeroPokemonInSquadra = (
            from s in db.Squadras
            from p in s.EsemplarePokemons
            where s.IdGiocatore == IdGiocatore
            && p.IdSquadra == s.IdGiocatore
            select p
            ).Count();
        pokemon.IdEsemplare = db.EsemplarePokemons.Max(p => p.IdEsemplare) + 1;
        pokemon.DataCattura = DateTime.Now;
        pokemon.IdGiocatoreProprietario = IdGiocatore;
        pokemon.NomePrimoAllenatore = Nome;
        pokemon.NomeAllenatore = Nome;
        if (numeroPokemonInSquadra < 6)
        {
            pokemon.IdSquadra = IdGiocatore;
            pokemon.IdBox = null;
            pokemon.InBox = false;
        }
        else
        {
            pokemon.IdSquadra = null;
            pokemon.IdBox = db.BoxPokemons.Where(b => b.IdGiocatore == IdGiocatore).Select(b => b.IdBox).First();
            pokemon.InBox = true;
        }
        db.EsemplarePokemons.Add(pokemon);
        db.SaveChanges();
        if (!catturato)
        {
            db.Database.ExecuteSql($"INSERT INTO CATTURA VALUES ({IdGiocatore}, {pokemon.NumeroPokemon})");
            db.SaveChanges();
        }
    }

    public List<Pokemon> GetPokemonIncontrati()
    {
        using var db = new PokedexAdaContext();
        List<Pokemon> pokemonIncontrati = (
            from g in db.Giocatores
            from p in g.NumeroPokemonAvvistati
            select p)
            .ToList();
        return pokemonIncontrati;
    }

    public List<Pokemon> GetPokemonCatturati()
    {
        using var db = new PokedexAdaContext();
        List<Pokemon> pokemonCatturati = (
            from g in db.Giocatores
            from p in g.NumeroPokemonCatturati
            select p)
            .ToList();
        return pokemonCatturati;
    }

    public bool AggiungiASquadra(int idEsemplare)
    {
        using var db = new PokedexAdaContext();
        db.Database.EnsureCreated();

        int quantitaInSquadra = 0;
        using (var cmdCount = db.Database.GetDbConnection().CreateCommand())
        {
            cmdCount.CommandText = "SELECT COUNT(*) FROM esemplare_pokemon WHERE IdGiocatoreProprietario = @idG AND IdSquadra IS NOT NULL";
            var paramG = cmdCount.CreateParameter();
            paramG.ParameterName = "@idG";
            paramG.Value = IdGiocatore;
            cmdCount.Parameters.Add(paramG);

            if (cmdCount.Connection.State != System.Data.ConnectionState.Open)
                cmdCount.Connection.Open();

            quantitaInSquadra = Convert.ToInt32(cmdCount.ExecuteScalar());
        }

        if (quantitaInSquadra >= 6) return false;

        using (var cmdUpdate = db.Database.GetDbConnection().CreateCommand())
        {
            cmdUpdate.CommandText = "UPDATE esemplare_pokemon SET IdSquadra = @idSq, InBox = '0', IdBox = NULL WHERE IdEsemplare = @idEs AND IdGiocatoreProprietario = @idG";

            var pSq = cmdUpdate.CreateParameter(); pSq.ParameterName = "@idSq"; pSq.Value = IdGiocatore; cmdUpdate.Parameters.Add(pSq);
            var pEs = cmdUpdate.CreateParameter(); pEs.ParameterName = "@idEs"; pEs.Value = idEsemplare; cmdUpdate.Parameters.Add(pEs);
            var pG = cmdUpdate.CreateParameter(); pG.ParameterName = "@idG"; pG.Value = IdGiocatore; cmdUpdate.Parameters.Add(pG);

            if (cmdUpdate.Connection.State != System.Data.ConnectionState.Open)
                cmdUpdate.Connection.Open();

            int righeAggiornate = cmdUpdate.ExecuteNonQuery();
            if (righeAggiornate == 0) return false;
        }

        return true;
    }

    public bool RimuoviDaSquadra(int idEsemplare, int? idBoxDestinazione = null)
    {
        using var db = new PokedexAdaContext();

        using var cmdUpdate = db.Database.GetDbConnection().CreateCommand();
        cmdUpdate.CommandText = "UPDATE esemplare_pokemon SET IdSquadra = NULL, InBox = '1', IdBox = @idBox WHERE IdEsemplare = @idEs AND IdGiocatoreProprietario = @idG";

        var pBox = cmdUpdate.CreateParameter();
        pBox.ParameterName = "@idBox";
        pBox.Value = (object?)idBoxDestinazione ?? DBNull.Value;
        cmdUpdate.Parameters.Add(pBox);

        var pEs = cmdUpdate.CreateParameter();
        pEs.ParameterName = "@idEs";
        pEs.Value = idEsemplare;
        cmdUpdate.Parameters.Add(pEs);

        var pG = cmdUpdate.CreateParameter();
        pG.ParameterName = "@idG";
        pG.Value = IdGiocatore;
        cmdUpdate.Parameters.Add(pG);

        if (cmdUpdate.Connection.State != System.Data.ConnectionState.Open)
            cmdUpdate.Connection.Open();

        int righeAggiornate = cmdUpdate.ExecuteNonQuery();
        if (righeAggiornate == 0) return false;

        return true;
    }

    public bool SfidaGiocatore(int idGiocatoreSfidato, string luogo, bool hoVinto)
    {
        using var db = new PokedexAdaContext();

        bool suaSquadraPronta = db.EsemplarePokemons.Any(e => e.IdGiocatoreProprietario == idGiocatoreSfidato && e.IdSquadra != null)
                                || db.Squadras.Any(s => s.IdGiocatore == idGiocatoreSfidato);
        bool tuaSquadraPronta = db.EsemplarePokemons.Any(e => e.IdGiocatoreProprietario == IdGiocatore && e.IdSquadra != null)
                                || db.Squadras.Any(s => s.IdGiocatore == IdGiocatore);

        if (!suaSquadraPronta || !tuaSquadraPronta)
        {
            return false;
        }

        int idBattaglia;
        try
        {
            idBattaglia = db.Battaglia.Max(b => b.IdBattaglia) + 1;
        }
        catch (Exception ex)
        {
            idBattaglia = 1;
        }

        Battaglia nuovaBattaglia = new Battaglia();
        nuovaBattaglia.IdBattaglia = idBattaglia;
        nuovaBattaglia.IdGiocatoreSfidante = IdGiocatore;
        nuovaBattaglia.IdGiocatoreSfidato = idGiocatoreSfidato;
        nuovaBattaglia.Data = DateTime.Now;
        nuovaBattaglia.Luogo = luogo;
        nuovaBattaglia.SfidanteVincitore = hoVinto;

        db.Battaglia.Add(nuovaBattaglia);
        db.SaveChanges();

        return true;
    }

    public void CambiaPokemonPreferito (int id)
    {
        using var db = new PokedexAdaContext();
        db.Database.EnsureCreated();
        try
        {
            IdEsemplarePreferito = id;
            db.Giocatores.Update(this);
        }
        finally
        {
            db.SaveChanges();
        }

    }
}