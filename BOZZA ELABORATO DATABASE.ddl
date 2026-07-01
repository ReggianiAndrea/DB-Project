-- *********************************************
-- * Standard SQL generation                   
-- *--------------------------------------------
-- * DB-MAIN version: 11.0.2              
-- * Generator date: Sep 20 2021              
-- * Generation date: Wed Jul  1 21:04:38 2026 
-- * LUN file: /home/davide/Progetti/DB-Project/SCHEMA ER FINALE.lun 
-- * Schema: PokedexLogico/SQL 
-- ********************************************* 


-- Database Section
-- ________________ 

create database PokedexLogico;
use PokedexLogico;

-- DBSpace Section
-- _______________


-- Tables Section
-- _____________ 

create table ABILITA (
     NomeAbilita varchar(20) not null,
     DescrizioneAbilita varchar(50) not null,
     constraint ID_ABILITA_ID primary key (NomeAbilita));

create table ACQUISIZIONE (
     NomeMossa varchar(20) not null,
     NumeroPokemon numeric(1) not null,
     constraint ID_ACQUISIZIONE_ID primary key (NomeMossa, NumeroPokemon));

create table AMICIZIA (
     IdGiocatore numeric(1) not null,
     IdGiocatoreAmico numeric(1) not null,
     Bloccato char not null,
     constraint ID_AMICIZIA_ID primary key (IdGiocatoreAmico, IdGiocatore));

create table AVVISTAMENTO (
     IdGiocatore numeric(1) not null,
     NumeroPokemon numeric(1) not null,
     constraint ID_AVVISTAMENTO_ID primary key (IdGiocatore, NumeroPokemon));

create table BATTAGLIA (
     IdBattaglia numeric(1) not null,
     SfidanteVincitore char not null,
     Data date not null,
     IdGiocatoreSfidante numeric(1) not null,
     IdGiocatoreSfidato numeric(1) not null,
     Luogo varchar(30) not null,
     constraint SID_BATTAGLIA_ID unique (IdGiocatoreSfidante, IdGiocatoreSfidato, Data),
     constraint ID_BATTAGLIA_ID primary key (IdBattaglia));

create table BIOMA (
     IdBioma numeric(1) not null,
     Habitat varchar(10) not null,
     DescrizioneHabitat varchar(50) not null,
     constraint ID_BIOMA_ID primary key (IdBioma));

create table BOX_POKEMON (
     IdBox numeric(1) not null,
     IdGiocatore numeric(1) not null,
     constraint ID_BOX_POKEMON_ID primary key (IdBox));

create table CATTURA (
     IdGiocatore numeric(1) not null,
     NumeroPokemon numeric(1) not null,
     constraint ID_CATTURA_ID primary key (IdGiocatore, NumeroPokemon));

create table ELEMENTO (
     IdElemento numeric(1) not null,
     Tipologia varchar(10) not null,
     constraint ID_ELEMENTO_ID primary key (IdElemento));

create table ESEMPLARE_POKEMON (
     IdEsemplare numeric(1) not null,
     NomeAllenatore varchar(30) not null,
     NomePrimoAllenatore varchar(30) not null,
     Livello numeric(1) not null,
     DataCattura date not null,
     InBox char not null,
     Sesso char(1) not null,
     Cromatico char not null,
     NumeroPokemon numeric(1) not null,
     IdGiocatoreProprietario numeric(1) not null,
     IdSquadra numeric(1),
     IdBox numeric(1),
     constraint ID_ESEMPLARE_POKEMON_ID primary key (IdEsemplare));

create table EVOLUZIONE (
     NumeroPokemonStadioCorrente numeric(1) not null,
     NumeroPokemonStadioSuccessivo numeric(1) not null,
     IdMetodo numeric(1) not null,
     constraint ID_EVOLUZIONE_ID primary key (IdMetodo, NumeroPokemonStadioCorrente, NumeroPokemonStadioSuccessivo),
     constraint SID_EVOLU_POKEM_1_ID unique (NumeroPokemonStadioSuccessivo),
     constraint SID_EVOLU_POKEM_ID unique (NumeroPokemonStadioCorrente));

create table GIOCATORE (
     IdGiocatore numeric(1) not null,
     Nome varchar(30) not null,
     Cognome varchar(30) not null,
     Nickname varchar(30) not null,
     Immagine varchar(100) not null,
     IdEsemplarePreferito numeric(1),
     constraint ID_GIOCATORE_ID primary key (IdGiocatore));

create table METODO_EVOLUTIVO (
     IdMetodo numeric(1) not null,
     Nome varchar(20) not null,
     Descrizione varchar(50) not null,
     constraint ID_METODO_EVOLUTIVO_ID primary key (IdMetodo));

create table MOSSA (
     NomeMossa varchar(20) not null,
     DescrizioneMossa varchar(50) not null,
     Precisione numeric(1) not null,
     Danno numeric(1),
     IdElemento numeric(1) not null,
     constraint ID_MOSSA_ID primary key (NomeMossa));

create table PERMANENZA (
     IdBioma numeric(1) not null,
     NumeroPokemon numeric(1) not null,
     constraint ID_PERMANENZA_ID primary key (NumeroPokemon, IdBioma));

create table POKEMON (
     NumeroPokemon numeric(1) not null,
     NumeroPokemonStadioPrecedente numeric(1),
     Specie varchar(20) not null,
     Nome varchar(30) not null,
     DescrizionePokemon varchar(100) not null,
     Altezza float(1) not null,
     Peso float(1) not null,
     Impronta numeric(1) not null,
     Immagine varchar(100) not null,
     ColoreDominante varchar(10) not null,
     IdElementoPrimario numeric(1) not null,
     IdElementoSecondario numeric(1),
     IdStatistiche numeric(1) not null,
     NomeAbilita varchar(20) not null,
     constraint ID_POKEMON_ID primary key (NumeroPokemon),
     constraint SID_POKEM_POKEM_ID unique (NumeroPokemonStadioPrecedente));

create table SET_STATISTICHE (
     IdStatistiche numeric(1) not null,
     Attacco numeric(1) not null,
     Difesa numeric(1) not null,
     PuntiSalute numeric(1) not null,
     AttaccoSpeciale numeric(1) not null,
     DifesaSpeciale numeric(1) not null,
     Velocita numeric(1) not null,
     constraint ID_SET_STATISTICHE_ID primary key (IdStatistiche));

create table SQUADRA (
     IdGiocatore numeric(1) not null,
     constraint ID_SQUAD_GIOCA_ID primary key (IdGiocatore));


-- Constraints Section
-- ___________________ 

alter table ACQUISIZIONE add constraint REF_ACQUI_POKEM_FK
     foreign key (NumeroPokemon)
     references POKEMON;

alter table ACQUISIZIONE add constraint REF_ACQUI_MOSSA
     foreign key (NomeMossa)
     references MOSSA;

alter table AMICIZIA add constraint REF_AMICI_GIOCA_1_FK
     foreign key (IdGiocatore)
     references GIOCATORE;

alter table AMICIZIA add constraint REF_AMICI_GIOCA
     foreign key (IdGiocatoreAmico)
     references GIOCATORE;

alter table AVVISTAMENTO add constraint REF_AVVIS_POKEM_FK
     foreign key (NumeroPokemon)
     references POKEMON;

alter table AVVISTAMENTO add constraint REF_AVVIS_GIOCA
     foreign key (IdGiocatore)
     references GIOCATORE;

alter table BATTAGLIA add constraint REF_BATTA_SQUAD_1
     foreign key (IdGiocatoreSfidante)
     references SQUADRA;

alter table BATTAGLIA add constraint REF_BATTA_SQUAD_FK
     foreign key (IdGiocatoreSfidato)
     references SQUADRA;

alter table BIOMA add constraint ID_BIOMA_CHK
     check(exists(select * from PERMANENZA
                  where PERMANENZA.IdBioma = IdBioma)); 

alter table BOX_POKEMON add constraint REF_BOX_P_GIOCA_FK
     foreign key (IdGiocatore)
     references GIOCATORE;

alter table CATTURA add constraint REF_CATTU_POKEM_FK
     foreign key (NumeroPokemon)
     references POKEMON;

alter table CATTURA add constraint REF_CATTU_GIOCA
     foreign key (IdGiocatore)
     references GIOCATORE;

alter table ESEMPLARE_POKEMON add constraint REF_ESEMP_BOX_P_FK
     foreign key (IdBox)
     references BOX_POKEMON;

alter table ESEMPLARE_POKEMON add constraint REF_ESEMP_GIOCA_FK
     foreign key (IdGiocatoreProprietario)
     references GIOCATORE;

alter table ESEMPLARE_POKEMON add constraint EQU_ESEMP_SQUAD_FK
     foreign key (IdSquadra)
     references SQUADRA;

alter table ESEMPLARE_POKEMON add constraint REF_ESEMP_POKEM_FK
     foreign key (NumeroPokemon)
     references POKEMON;

alter table EVOLUZIONE add constraint EQU_EVOLU_METOD
     foreign key (IdMetodo)
     references METODO_EVOLUTIVO;

alter table EVOLUZIONE add constraint SID_EVOLU_POKEM_1_FK
     foreign key (NumeroPokemonStadioSuccessivo)
     references POKEMON;

alter table EVOLUZIONE add constraint SID_EVOLU_POKEM_FK
     foreign key (NumeroPokemonStadioCorrente)
     references POKEMON;

alter table GIOCATORE add constraint ID_GIOCATORE_CHK
     check(exists(select * from SQUADRA
                  where SQUADRA.IdGiocatore = IdGiocatore)); 

alter table GIOCATORE add constraint REF_GIOCA_ESEMP_FK
     foreign key (IdEsemplarePreferito)
     references ESEMPLARE_POKEMON;

alter table METODO_EVOLUTIVO add constraint ID_METODO_EVOLUTIVO_CHK
     check(exists(select * from EVOLUZIONE
                  where EVOLUZIONE.IdMetodo = IdMetodo)); 

alter table MOSSA add constraint REF_MOSSA_ELEME_FK
     foreign key (IdElemento)
     references ELEMENTO;

alter table PERMANENZA add constraint EQU_PERMA_POKEM
     foreign key (NumeroPokemon)
     references POKEMON;

alter table PERMANENZA add constraint EQU_PERMA_BIOMA_FK
     foreign key (IdBioma)
     references BIOMA;

alter table POKEMON add constraint ID_POKEMON_CHK
     check(exists(select * from PERMANENZA
                  where PERMANENZA.NumeroPokemon = NumeroPokemon)); 

alter table POKEMON add constraint ID_POKEMON_CHK
     check(exists(select * from EVOLUZIONE
                  where EVOLUZIONE.NumeroPokemonStadioCorrente = NumeroPokemon)); 

alter table POKEMON add constraint REF_POKEM_ELEME_1_FK
     foreign key (IdElementoSecondario)
     references ELEMENTO;

alter table POKEMON add constraint REF_POKEM_ELEME_FK
     foreign key (IdElementoPrimario)
     references ELEMENTO;

alter table POKEMON add constraint EQU_POKEM_SET_S_FK
     foreign key (IdStatistiche)
     references SET_STATISTICHE;

alter table POKEMON add constraint SID_POKEM_POKEM_FK
     foreign key (NumeroPokemonStadioPrecedente)
     references POKEMON;

alter table POKEMON add constraint REF_POKEM_ABILI_FK
     foreign key (NomeAbilita)
     references ABILITA;

alter table SET_STATISTICHE add constraint ID_SET_STATISTICHE_CHK
     check(exists(select * from POKEMON
                  where POKEMON.IdStatistiche = IdStatistiche)); 

alter table SQUADRA add constraint ID_SQUAD_GIOCA_CHK
     check(exists(select * from ESEMPLARE_POKEMON
                  where ESEMPLARE_POKEMON.IdSquadra = IdGiocatore)); 

alter table SQUADRA add constraint ID_SQUAD_GIOCA_FK
     foreign key (IdGiocatore)
     references GIOCATORE;


-- Index Section
-- _____________ 

create unique index ID_ABILITA_IND
     on ABILITA (NomeAbilita);

create unique index ID_ACQUISIZIONE_IND
     on ACQUISIZIONE (NomeMossa, NumeroPokemon);

create index REF_ACQUI_POKEM_IND
     on ACQUISIZIONE (NumeroPokemon);

create unique index ID_AMICIZIA_IND
     on AMICIZIA (IdGiocatoreAmico, IdGiocatore);

create index REF_AMICI_GIOCA_1_IND
     on AMICIZIA (IdGiocatore);

create unique index ID_AVVISTAMENTO_IND
     on AVVISTAMENTO (IdGiocatore, NumeroPokemon);

create index REF_AVVIS_POKEM_IND
     on AVVISTAMENTO (NumeroPokemon);

create unique index SID_BATTAGLIA_IND
     on BATTAGLIA (IdGiocatoreSfidante, IdGiocatoreSfidato, Data);

create unique index ID_BATTAGLIA_IND
     on BATTAGLIA (IdBattaglia);

create index REF_BATTA_SQUAD_IND
     on BATTAGLIA (IdGiocatoreSfidato);

create unique index ID_BIOMA_IND
     on BIOMA (IdBioma);

create unique index ID_BOX_POKEMON_IND
     on BOX_POKEMON (IdBox);

create index REF_BOX_P_GIOCA_IND
     on BOX_POKEMON (IdGiocatore);

create unique index ID_CATTURA_IND
     on CATTURA (IdGiocatore, NumeroPokemon);

create index REF_CATTU_POKEM_IND
     on CATTURA (NumeroPokemon);

create unique index ID_ELEMENTO_IND
     on ELEMENTO (IdElemento);

create unique index ID_ESEMPLARE_POKEMON_IND
     on ESEMPLARE_POKEMON (IdEsemplare);

create index REF_ESEMP_BOX_P_IND
     on ESEMPLARE_POKEMON (IdBox);

create index REF_ESEMP_GIOCA_IND
     on ESEMPLARE_POKEMON (IdGiocatoreProprietario);

create index EQU_ESEMP_SQUAD_IND
     on ESEMPLARE_POKEMON (IdSquadra);

create index REF_ESEMP_POKEM_IND
     on ESEMPLARE_POKEMON (NumeroPokemon);

create unique index ID_EVOLUZIONE_IND
     on EVOLUZIONE (IdMetodo, NumeroPokemonStadioCorrente, NumeroPokemonStadioSuccessivo);

create unique index SID_EVOLU_POKEM_1_IND
     on EVOLUZIONE (NumeroPokemonStadioSuccessivo);

create unique index SID_EVOLU_POKEM_IND
     on EVOLUZIONE (NumeroPokemonStadioCorrente);

create unique index ID_GIOCATORE_IND
     on GIOCATORE (IdGiocatore);

create index REF_GIOCA_ESEMP_IND
     on GIOCATORE (IdEsemplarePreferito);

create unique index ID_METODO_EVOLUTIVO_IND
     on METODO_EVOLUTIVO (IdMetodo);

create unique index ID_MOSSA_IND
     on MOSSA (NomeMossa);

create index REF_MOSSA_ELEME_IND
     on MOSSA (IdElemento);

create unique index ID_PERMANENZA_IND
     on PERMANENZA (NumeroPokemon, IdBioma);

create index EQU_PERMA_BIOMA_IND
     on PERMANENZA (IdBioma);

create unique index ID_POKEMON_IND
     on POKEMON (NumeroPokemon);

create index REF_POKEM_ELEME_1_IND
     on POKEMON (IdElementoSecondario);

create index REF_POKEM_ELEME_IND
     on POKEMON (IdElementoPrimario);

create index EQU_POKEM_SET_S_IND
     on POKEMON (IdStatistiche);

create unique index SID_POKEM_POKEM_IND
     on POKEMON (NumeroPokemonStadioPrecedente);

create index REF_POKEM_ABILI_IND
     on POKEMON (NomeAbilita);

create unique index ID_SET_STATISTICHE_IND
     on SET_STATISTICHE (IdStatistiche);

create unique index ID_SQUAD_GIOCA_IND
     on SQUADRA (IdGiocatore);

