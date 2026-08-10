using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PokedexADA.PokedexADA;

public partial class PokedexAdaContext : DbContext
{
    public PokedexAdaContext()
    {
    }

    public PokedexAdaContext(DbContextOptions<PokedexAdaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Abilita> Abilita { get; set; }

    public virtual DbSet<Amicizia> Amicizia { get; set; }

    public virtual DbSet<Battaglia> Battaglia { get; set; }

    public virtual DbSet<Bioma> Biomas { get; set; }

    public virtual DbSet<BoxPokemon> BoxPokemons { get; set; }

    public virtual DbSet<Elemento> Elementos { get; set; }

    public virtual DbSet<EsemplarePokemon> EsemplarePokemons { get; set; }

    public virtual DbSet<Evoluzione> Evoluziones { get; set; }

    public virtual DbSet<Giocatore> Giocatores { get; set; }

    public virtual DbSet<MetodoEvolutivo> MetodoEvolutivos { get; set; }

    public virtual DbSet<Mossa> Mossas { get; set; }

    public virtual DbSet<Pokemon> Pokemons { get; set; }

    public virtual DbSet<SetStatistiche> SetStatistiches { get; set; }

    public virtual DbSet<Squadra> Squadras { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;uid=root;password=;database=pokedexada");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Abilita>(entity =>
        {
            entity.HasKey(e => e.NomeAbilita).HasName("PRIMARY");

            entity.ToTable("abilita");

            entity.HasIndex(e => e.NomeAbilita, "ID_ABILITA_IND").IsUnique();

            entity.Property(e => e.NomeAbilita).HasMaxLength(30);
            entity.Property(e => e.DescrizioneAbilita).HasMaxLength(200);
        });

        modelBuilder.Entity<Amicizia>(entity =>
        {
            entity.HasKey(e => new { e.IdGiocatoreAmico, e.IdGiocatore }).HasName("PRIMARY");

            entity.ToTable("amicizia");

            entity.HasIndex(e => new { e.IdGiocatoreAmico, e.IdGiocatore }, "ID_AMICIZIA_IND").IsUnique();

            entity.HasIndex(e => e.IdGiocatore, "REF_AMICI_GIOCA_1_IND");

            entity.Property(e => e.Bloccato)
                .IsFixedLength();

            entity.HasOne(d => d.IdGiocatoreNavigation).WithMany(p => p.AmiciziaIdGiocatoreNavigations)
                .HasForeignKey(d => d.IdGiocatore)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("REF_AMICI_GIOCA_1_FK");

            entity.HasOne(d => d.IdGiocatoreAmicoNavigation).WithMany(p => p.AmiciziaIdGiocatoreAmicoNavigations)
                .HasForeignKey(d => d.IdGiocatoreAmico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("REF_AMICI_GIOCA");
        });

        modelBuilder.Entity<Battaglia>(entity =>
        {
            entity.HasKey(e => e.IdBattaglia).HasName("PRIMARY");

            entity.ToTable("battaglia");

            entity.HasIndex(e => e.IdBattaglia, "ID_BATTAGLIA_IND").IsUnique();

            entity.HasIndex(e => e.IdGiocatoreSfidato, "REF_BATTA_SQUAD_IND");

            entity.HasIndex(e => new { e.IdGiocatoreSfidante, e.IdGiocatoreSfidato, e.Data }, "SID_BATTAGLIA_ID").IsUnique();

            entity.HasIndex(e => new { e.IdGiocatoreSfidante, e.IdGiocatoreSfidato, e.Data }, "SID_BATTAGLIA_IND").IsUnique();

            entity.Property(e => e.Data).HasColumnType("date");
            entity.Property(e => e.Luogo).HasMaxLength(30);
            entity.Property(e => e.SfidanteVincitore)
                .HasMaxLength(1)
                .IsFixedLength();

            entity.HasOne(d => d.IdGiocatoreSfidanteNavigation).WithMany(p => p.BattagliaIdGiocatoreSfidanteNavigations)
                .HasForeignKey(d => d.IdGiocatoreSfidante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("REF_BATTA_SQUAD_1");

            entity.HasOne(d => d.IdGiocatoreSfidatoNavigation).WithMany(p => p.BattagliaIdGiocatoreSfidatoNavigations)
                .HasForeignKey(d => d.IdGiocatoreSfidato)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("REF_BATTA_SQUAD_FK");
        });

        modelBuilder.Entity<Bioma>(entity =>
        {
            entity.HasKey(e => e.IdBioma).HasName("PRIMARY");

            entity.ToTable("bioma");

            entity.HasIndex(e => e.IdBioma, "ID_BIOMA_IND").IsUnique();

            entity.Property(e => e.DescrizioneHabitat).HasMaxLength(200);
            entity.Property(e => e.Habitat).HasMaxLength(30);
        });

        modelBuilder.Entity<BoxPokemon>(entity =>
        {
            entity.HasKey(e => e.IdBox).HasName("PRIMARY");

            entity.ToTable("box_pokemon");

            entity.HasIndex(e => e.IdBox, "ID_BOX_POKEMON_IND").IsUnique();

            entity.HasIndex(e => e.IdGiocatore, "REF_BOX_P_GIOCA_IND");

            entity.HasOne(d => d.IdGiocatoreNavigation).WithMany(p => p.BoxPokemons)
                .HasForeignKey(d => d.IdGiocatore)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("REF_BOX_P_GIOCA_FK");
        });

        modelBuilder.Entity<Elemento>(entity =>
        {
            entity.HasKey(e => e.IdElemento).HasName("PRIMARY");

            entity.ToTable("elemento");

            entity.HasIndex(e => e.IdElemento, "ID_ELEMENTO_IND").IsUnique();

            entity.Property(e => e.Tipologia).HasMaxLength(10);
        });

        modelBuilder.Entity<EsemplarePokemon>(entity =>
        {
            entity.HasKey(e => e.IdEsemplare).HasName("PRIMARY");

            entity.ToTable("esemplare_pokemon");

            entity.HasIndex(e => e.IdSquadra, "EQU_ESEMP_SQUAD_IND");

            entity.HasIndex(e => e.IdEsemplare, "ID_ESEMPLARE_POKEMON_IND").IsUnique();

            entity.HasIndex(e => e.IdBox, "REF_ESEMP_BOX_P_IND");

            entity.HasIndex(e => e.IdGiocatoreProprietario, "REF_ESEMP_GIOCA_IND");

            entity.HasIndex(e => e.NumeroPokemon, "REF_ESEMP_POKEM_IND");

            entity.Property(e => e.Cromatico)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.DataCattura).HasColumnType("date");
            entity.Property(e => e.InBox)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.NomeAllenatore).HasMaxLength(30);
            entity.Property(e => e.NomePrimoAllenatore).HasMaxLength(30);
            entity.Property(e => e.Sesso)
                .HasMaxLength(1)
                .IsFixedLength();

            entity.HasOne(d => d.IdBoxNavigation).WithMany(p => p.EsemplarePokemons)
                .HasForeignKey(d => d.IdBox)
                .HasConstraintName("REF_ESEMP_BOX_P_FK");

            entity.HasOne(d => d.IdGiocatoreProprietarioNavigation).WithMany(p => p.EsemplarePokemons)
                .HasForeignKey(d => d.IdGiocatoreProprietario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("REF_ESEMP_GIOCA_FK");

            entity.HasOne(d => d.IdSquadraNavigation).WithMany(p => p.EsemplarePokemons)
                .HasForeignKey(d => d.IdSquadra)
                .HasConstraintName("EQU_ESEMP_SQUAD_FK");

            entity.HasOne(d => d.NumeroPokemonNavigation).WithMany(p => p.EsemplarePokemons)
                .HasForeignKey(d => d.NumeroPokemon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("REF_ESEMP_POKEM_FK");
        });

        modelBuilder.Entity<Evoluzione>(entity =>
        {
            entity.HasKey(e => new { e.IdMetodo, e.NumeroPokemonStadioCorrente, e.NumeroPokemonStadioSuccessivo }).HasName("PRIMARY");

            entity.ToTable("evoluzione");

            entity.HasIndex(e => new { e.IdMetodo, e.NumeroPokemonStadioCorrente, e.NumeroPokemonStadioSuccessivo }, "ID_EVOLUZIONE_IND").IsUnique();

            entity.HasIndex(e => e.NumeroPokemonStadioCorrente, "REF_EVOLU_POKEM_IND");

            entity.HasIndex(e => e.NumeroPokemonStadioSuccessivo, "SID_EVOLU_POKEM_ID").IsUnique();

            entity.HasIndex(e => e.NumeroPokemonStadioSuccessivo, "SID_EVOLU_POKEM_IND").IsUnique();

            entity.HasOne(d => d.NumeroPokemonStadioCorrenteNavigation).WithMany(p => p.EvoluzioneNumeroPokemonStadioCorrenteNavigations)
                .HasForeignKey(d => d.NumeroPokemonStadioCorrente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("REF_EVOLU_POKEM_FK");

            entity.HasOne(d => d.NumeroPokemonStadioSuccessivoNavigation).WithOne(p => p.EvoluzioneNumeroPokemonStadioSuccessivoNavigation)
                .HasForeignKey<Evoluzione>(d => d.NumeroPokemonStadioSuccessivo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SID_EVOLU_POKEM_FK");
        });

        modelBuilder.Entity<Giocatore>(entity =>
        {
            entity.HasKey(e => e.IdGiocatore).HasName("PRIMARY");

            entity.ToTable("giocatore");

            entity.HasIndex(e => e.IdGiocatore, "ID_GIOCATORE_IND").IsUnique();

            entity.HasIndex(e => e.IdEsemplarePreferito, "REF_GIOCA_ESEMP_IND");

            entity.Property(e => e.Cognome).HasMaxLength(30);
            entity.Property(e => e.Immagine).HasMaxLength(100);
            entity.Property(e => e.Nickname).HasMaxLength(30);
            entity.Property(e => e.Nome).HasMaxLength(30);

            entity.HasOne(d => d.IdEsemplarePreferitoNavigation).WithMany(p => p.Giocatores)
                .HasForeignKey(d => d.IdEsemplarePreferito)
                .HasConstraintName("REF_GIOCA_ESEMP_FK");

            entity.HasMany(d => d.NumeroPokemonAvvistati).WithMany(p => p.IdGiocatores)
                .UsingEntity<Dictionary<string, object>>(
                    "Avvistamento",
                    r => r.HasOne<Pokemon>().WithMany()
                        .HasForeignKey("NumeroPokemon")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("REF_AVVIS_POKEM_FK"),
                    l => l.HasOne<Giocatore>().WithMany()
                        .HasForeignKey("IdGiocatore")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("REF_AVVIS_GIOCA"),
                    j =>
                    {
                        j.HasKey("IdGiocatore", "NumeroPokemon").HasName("PRIMARY");
                        j.ToTable("avvistamento");
                        j.HasIndex(new[] { "IdGiocatore", "NumeroPokemon" }, "ID_AVVISTAMENTO_IND").IsUnique();
                        j.HasIndex(new[] { "NumeroPokemon" }, "REF_AVVIS_POKEM_IND");
                    });

            entity.HasMany(d => d.NumeroPokemonCatturati).WithMany(p => p.IdGiocatoresNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "Cattura",
                    r => r.HasOne<Pokemon>().WithMany()
                        .HasForeignKey("NumeroPokemon")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("REF_CATTU_POKEM_FK"),
                    l => l.HasOne<Giocatore>().WithMany()
                        .HasForeignKey("IdGiocatore")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("REF_CATTU_GIOCA"),
                    j =>
                    {
                        j.HasKey("IdGiocatore", "NumeroPokemon").HasName("PRIMARY");
                        j.ToTable("cattura");
                        j.HasIndex(new[] { "IdGiocatore", "NumeroPokemon" }, "ID_CATTURA_IND").IsUnique();
                        j.HasIndex(new[] { "NumeroPokemon" }, "REF_CATTU_POKEM_IND");
                    });
        });

        modelBuilder.Entity<MetodoEvolutivo>(entity =>
        {
            entity.HasKey(e => e.IdMetodo).HasName("PRIMARY");

            entity.ToTable("metodo_evolutivo");

            entity.HasIndex(e => e.IdMetodo, "ID_METODO_EVOLUTIVO_IND").IsUnique();

            entity.Property(e => e.Descrizione).HasMaxLength(100);
            entity.Property(e => e.Nome).HasMaxLength(30);
        });

        modelBuilder.Entity<Mossa>(entity =>
        {
            entity.HasKey(e => e.NomeMossa).HasName("PRIMARY");

            entity.ToTable("mossa");

            entity.HasIndex(e => e.NomeMossa, "ID_MOSSA_IND").IsUnique();

            entity.HasIndex(e => e.IdElemento, "REF_MOSSA_ELEME_IND");

            entity.Property(e => e.NomeMossa).HasMaxLength(30);
            entity.Property(e => e.DescrizioneMossa).HasMaxLength(200);

            entity.HasOne(d => d.IdElementoNavigation).WithMany(p => p.Mossas)
                .HasForeignKey(d => d.IdElemento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("REF_MOSSA_ELEME_FK");

            entity.HasMany(d => d.NumeroPokemons).WithMany(p => p.NomeMossas)
                .UsingEntity<Dictionary<string, object>>(
                    "Acquisizione",
                    r => r.HasOne<Pokemon>().WithMany()
                        .HasForeignKey("NumeroPokemon")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("REF_ACQUI_POKEM_FK"),
                    l => l.HasOne<Mossa>().WithMany()
                        .HasForeignKey("NomeMossa")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("REF_ACQUI_MOSSA"),
                    j =>
                    {
                        j.HasKey("NomeMossa", "NumeroPokemon").HasName("PRIMARY");
                        j.ToTable("acquisizione");
                        j.HasIndex(new[] { "NomeMossa", "NumeroPokemon" }, "ID_ACQUISIZIONE_IND").IsUnique();
                        j.HasIndex(new[] { "NumeroPokemon" }, "REF_ACQUI_POKEM_IND");
                        j.IndexerProperty<string>("NomeMossa").HasMaxLength(30);
                    });
        });

        modelBuilder.Entity<Pokemon>(entity =>
        {
            entity.HasKey(e => e.NumeroPokemon).HasName("PRIMARY");

            entity.ToTable("pokemon");

            entity.HasIndex(e => e.IdStatistiche, "EQU_POKEM_SET_S_IND");

            entity.HasIndex(e => e.NumeroPokemon, "ID_POKEMON_IND").IsUnique();

            entity.HasIndex(e => e.NomeAbilita, "REF_POKEM_ABILI_IND");

            entity.HasIndex(e => e.IdElementoSecondario, "REF_POKEM_ELEME_1_IND");

            entity.HasIndex(e => e.IdElementoPrimario, "REF_POKEM_ELEME_IND");

            entity.Property(e => e.ColoreDominante).HasMaxLength(20);
            entity.Property(e => e.DescrizionePokemon).HasMaxLength(200);
            entity.Property(e => e.Immagine).HasMaxLength(100);
            entity.Property(e => e.Impronta).HasMaxLength(30);
            entity.Property(e => e.Nome).HasMaxLength(30);
            entity.Property(e => e.NomeAbilita).HasMaxLength(30);
            entity.Property(e => e.Specie).HasMaxLength(30);

            entity.HasOne(d => d.IdElementoPrimarioNavigation).WithMany(p => p.PokemonIdElementoPrimarioNavigations)
                .HasForeignKey(d => d.IdElementoPrimario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("REF_POKEM_ELEME_FK");

            entity.HasOne(d => d.IdElementoSecondarioNavigation).WithMany(p => p.PokemonIdElementoSecondarioNavigations)
                .HasForeignKey(d => d.IdElementoSecondario)
                .HasConstraintName("REF_POKEM_ELEME_1_FK");

            entity.HasOne(d => d.IdStatisticheNavigation).WithMany(p => p.Pokemons)
                .HasForeignKey(d => d.IdStatistiche)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("EQU_POKEM_SET_S_FK");

            entity.HasOne(d => d.NomeAbilitaNavigation).WithMany(p => p.Pokemons)
                .HasForeignKey(d => d.NomeAbilita)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("REF_POKEM_ABILI_FK");

            entity.HasMany(d => d.IdBiomas).WithMany(p => p.NumeroPokemons)
                .UsingEntity<Dictionary<string, object>>(
                    "Permanenza",
                    r => r.HasOne<Bioma>().WithMany()
                        .HasForeignKey("IdBioma")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("EQU_PERMA_BIOMA_FK"),
                    l => l.HasOne<Pokemon>().WithMany()
                        .HasForeignKey("NumeroPokemon")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("EQU_PERMA_POKEM"),
                    j =>
                    {
                        j.HasKey("NumeroPokemon", "IdBioma").HasName("PRIMARY");
                        j.ToTable("permanenza");
                        j.HasIndex(new[] { "IdBioma" }, "EQU_PERMA_BIOMA_IND");
                        j.HasIndex(new[] { "NumeroPokemon", "IdBioma" }, "ID_PERMANENZA_IND").IsUnique();
                    });
        });

        modelBuilder.Entity<SetStatistiche>(entity =>
        {
            entity.HasKey(e => e.IdStatistiche).HasName("PRIMARY");

            entity.ToTable("set_statistiche");

            entity.HasIndex(e => e.IdStatistiche, "ID_SET_STATISTICHE_IND").IsUnique();
        });

        modelBuilder.Entity<Squadra>(entity =>
        {
            entity.HasKey(e => e.IdGiocatore).HasName("PRIMARY");

            entity.ToTable("squadra");

            entity.HasIndex(e => e.IdGiocatore, "ID_SQUAD_GIOCA_IND").IsUnique();

            entity.HasOne(d => d.IdGiocatoreNavigation).WithOne(p => p.Squadra)
                .HasForeignKey<Squadra>(d => d.IdGiocatore)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ID_SQUAD_GIOCA_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
