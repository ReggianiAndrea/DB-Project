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

    public bool TentaCattura(int numeroPokemon, double catchRate)
    {
        if (new Random().NextDouble() < catchRate)
        {
            Cattura(numeroPokemon);
            return true;
        }
        else
        {
            CatturaFallita(numeroPokemon);
            return false;
        }
    }

    private void Cattura(int numeroPokemon)
    {
        using var db = new PokedexAdaContext();
        db.Database.EnsureCreated();
        bool catturato = (
            from g in  db.Giocatores
            from pok in g.NumeroPokemonCatturati
            where pok.NumeroPokemon == numeroPokemon
            select pok.NumeroPokemon)
            .Any();
        if (!catturato)
        {
            db.Database.ExecuteSql($"INSERT INTO CATTURA VALUES ({IdGiocatore}, {numeroPokemon})");
            db.SaveChanges();
        }
    }

    private void CatturaFallita(int numeroPokemon)
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

        // Trova l'esemplare e verifica che sia di proprietà del giocatore
        var esemplare = db.EsemplarePokemons.FirstOrDefault(e => e.IdEsemplare == idEsemplare && e.IdGiocatoreProprietario == IdGiocatore);
        if (esemplare == null) return false;

        //  Assicurati che il giocatore abbia una riga nella tabella Squadra
        var squadra = db.Squadras.Include(s => s.EsemplarePokemons).FirstOrDefault(s => s.IdGiocatore == IdGiocatore);
        if (squadra == null)
        {
            squadra = new Squadra { IdGiocatore = IdGiocatore };
            db.Squadras.Add(squadra);
            db.SaveChanges(); // Salva per ottenere l'istanza nel DB
        }


        if (squadra.EsemplarePokemons.Count >= 6) return false;

        esemplare.IdSquadra = IdGiocatore;
        esemplare.InBox = "0"; // Flag: falso, non è nel box
        esemplare.IdBox = null;

        db.EsemplarePokemons.Update(esemplare);
        db.SaveChanges();
        return true;
    }

    public bool RimuoviDaSquadra(int idEsemplare, int? idBoxDestinazione = null)
    {
        using var db = new PokedexAdaContext();

        // Eseguiamo l'aggiornamento direttamente con SQL grezzo per evitare il caricamento dell'entità e l'errore sulle date
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

        // Controlliamo in modo sicuro se il giocatore sfidato ha una squadra o dei pokemon assegnati
        bool suaSquadraPronta = db.EsemplarePokemons.Any(e => e.IdGiocatoreProprietario == idGiocatoreSfidato && e.IdSquadra != null)
                                || db.Squadras.Any(s => s.IdGiocatore == idGiocatoreSfidato);

        if (!suaSquadraPronta)
        {
            return false;
        }

        Battaglia nuovaBattaglia = new Battaglia
        {
            IdGiocatoreSfidante = IdGiocatore,
            IdGiocatoreSfidato = idGiocatoreSfidato,
            Data = DateTime.Now,
            Luogo = luogo,
            SfidanteVincitore = hoVinto ? "1" : "0"
        };

        db.Battaglia.Add(nuovaBattaglia);
        db.SaveChanges();

        return true;
    }
}
