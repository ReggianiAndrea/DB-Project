-- *********************************************
-- * SQL MySQL generation                      
-- *--------------------------------------------
-- * DB-MAIN version: 11.0.2              
-- * Generator date: Sep 14 2021              
-- * Generation date: Wed Apr 15 23:14:12 2026 
-- * LUN file: C:\Users\dedde\Projects\DB-Project\SCHEMA ER FINALE.lun 
-- * Schema: PokedexLogico 
-- ********************************************* 


-- Database Section
-- ________________ 

create database PokedexLogico;
use PokedexLogico;


-- Tables Section
-- _____________ 

create table ABILITA (
     NomeAbilita varchar(20) not null,
     DescrizioneAbilita varchar(50) not null,
     NumeroPokemon int not null,
     constraint ID_ABILITA_ID primary key (NomeAbilita));

create table ACQUISIZIONE (
     NomeMossa varchar(20) not null,
     NumeroPokemon int not null,
     constraint ID_ACQUISIZIONE_ID primary key (NomeMossa, NumeroPokemon));

create table AMICIZIA (
     IdGiocatore int not null,
     IdGiocatoreAmico int not null,
     Bloccato char not null,
     constraint ID_AMICIZIA_ID primary key (IdGiocatoreAmico, IdGiocatore));

create table AVVISTAMENTO (
     IdGiocatore int not null,
     NumeroPokemon int not null,
     constraint ID_AVVISTAMENTO_ID primary key (IdGiocatore, NumeroPokemon));

create table BATTAGLIA (
     IdBattaglia int not null,
     SfidanteVincitore char not null,
     Data date not null,
     IdGiocatoreSfidande int not null,
     IdGiocatoreSfidato int not null,
     Luogo varchar(30) not null,
     constraint SID_BATTAGLIA_ID unique (IdGiocatoreSfidande, IdGiocatoreSfidato, Data),
     constraint ID_BATTAGLIA_ID primary key (IdBattaglia));

create table BIOMA (
     IdBioma int not null,
     Habitat varchar(10) not null,
     DescrizioneHabitat varchar(50) not null,
     constraint ID_BIOMA_ID primary key (IdBioma));

create table BOX_POKEMON (
     IdBox int not null,
     IdGiocatore int not null,
     constraint ID_BOX_POKEMON_ID primary key (IdBox));

create table CATTURA (
     IdGiocatore int not null,
     NumeroPokemon int not null,
     constraint ID_CATTURA_ID primary key (IdGiocatore, NumeroPokemon));

create table ELEMENTO (
     IdElemento int not null,
     Tipologia varchar(10) not null,
     constraint ID_ELEMENTO_ID primary key (IdElemento));

create table ESEMPLARE_POKEMON (
     IdEsemplare int not null,
     NomeAllenatore varchar(30) not null,
     NomePrimoAllenatore varchar(30) not null,
     Livello int not null,
     DataCattura date not null,
     InBox char not null,
     Sesso char(1) not null,
     Cromatico char not null,
     NumeroPokemon int not null,
     IdGiocatoreProprietario int not null,
     IdBox int,
     constraint ID_ESEMPLARE_POKEMON_ID primary key (IdEsemplare));

create table EVOLUZIONE (
     NumeroPokemonStadioCorrente int not null,
     NumeroPokemonStadioSuccessivo int not null,
     IdMetodo int not null,
     constraint ID_EVOLUZIONE_ID primary key (IdMetodo, NumeroPokemonStadioSuccessivo, NumeroPokemonStadioCorrente),
     constraint FKstadio_successivo_ID unique (NumeroPokemonStadioCorrente),
     constraint FKstadio_corrente_ID unique (NumeroPokemonStadioSuccessivo));

create table GIOCATORE (
     IdGiocatore int not null,
     Nome varchar(30) not null,
     Cognome varchar(30) not null,
     Nickname varchar(30) not null,
     Immagine varchar(100) not null,
     IdEsemplarePreferito int,
     constraint ID_GIOCATORE_ID primary key (IdGiocatore));

create table METODO_EVOLUTIVO (
     IdMetodo int not null,
     Nome varchar(20) not null,
     Descrizione varchar(50) not null,
     constraint ID_METODO_EVOLUTIVO_ID primary key (IdMetodo));

create table MOSSA (
     NomeMossa varchar(20) not null,
     DescrizioneMossa varchar(50) not null,
     Precisione int not null,
     IdElemento int not null,
     Danno int,
     constraint ID_MOSSA_ID primary key (NomeMossa));

create table PERMANENZA (
     IdBioma int not null,
     NumeroPokemon int not null,
     constraint ID_PERMANENZA_ID primary key (NumeroPokemon, IdBioma));

create table POKEMON (
     NumeroPokemon int not null,
     NumeroPokemonStadioPrecedente int not null,
     Specie varchar(20) not null,
     Nome varchar(30) not null,
     DescrizionePokemon varchar(100) not null,
     Altezza float(1) not null,
     Peso float(1) not null,
     Impronta int not null,
     Immagine varchar(100) not null,
     ColoreDominante varchar(10) not null,
     IdElementoPrimario int not null,
     IdElementoSecondario int,
     constraint ID_POKEMON_ID primary key (NumeroPokemon),
     constraint FKevoluzione_precedente_ID unique (NumeroPokemonStadioPrecedente));

create table SET_STATISTICHE (
     IdStatistiche int not null,
     Attacco int not null,
     Difesa int not null,
     PuntiSalute int not null,
     AttaccoSpeciale int not null,
     DifesaSpeciale int not null,
     Velocita int not null,
     NumeroPokemon int not null,
     constraint ID_SET_STATISTICHE_ID primary key (IdStatistiche));

create table SQUADRA (
     IdGiocatore int not null,
     constraint FKpossesso_ID primary key (IdGiocatore));


-- Constraints Section
-- ___________________ 

alter table ABILITA add constraint FKcompetenza_FK
     foreign key (NumeroPokemon)
     references POKEMON (NumeroPokemon);

alter table ACQUISIZIONE add constraint FKacq_pok_FK
     foreign key (NumeroPokemon)
     references POKEMON (NumeroPokemon);

alter table ACQUISIZIONE add constraint FKacq_mos
     foreign key (NomeMossa)
     references MOSSA (NomeMossa);

alter table AMICIZIA add constraint FKgiocatore2_FK
     foreign key (IdGiocatore)
     references GIOCATORE (IdGiocatore);

alter table AMICIZIA add constraint FKgiocatore1
     foreign key (IdGiocatoreAmico)
     references GIOCATORE (IdGiocatore);

alter table AVVISTAMENTO add constraint FKavv_pok_FK
     foreign key (NumeroPokemon)
     references POKEMON (NumeroPokemon);

alter table AVVISTAMENTO add constraint FKavv_gio
     foreign key (IdGiocatore)
     references GIOCATORE (IdGiocatore);

alter table BATTAGLIA add constraint FKsfidato
     foreign key (IdGiocatoreSfidande)
     references SQUADRA (IdGiocatore);

alter table BATTAGLIA add constraint FKsfidante_FK
     foreign key (IdGiocatoreSfidato)
     references SQUADRA (IdGiocatore);

-- Not implemented
-- alter table BIOMA add constraint ID_BIOMA_CHK
--     check(exists(select * from PERMANENZA
--                  where PERMANENZA.IdBioma = IdBioma)); 

alter table BOX_POKEMON add constraint FKdotazione_FK
     foreign key (IdGiocatore)
     references GIOCATORE (IdGiocatore);

alter table CATTURA add constraint FKcat_pok_FK
     foreign key (NumeroPokemon)
     references POKEMON (NumeroPokemon);

alter table CATTURA add constraint FKcat_gio
     foreign key (IdGiocatore)
     references GIOCATORE (IdGiocatore);

alter table ESEMPLARE_POKEMON add constraint FKlocazione_FK
     foreign key (IdBox)
     references BOX_POKEMON (IdBox);

alter table ESEMPLARE_POKEMON add constraint FKcomposizione_FK
     foreign key (IdGiocatoreProprietario)
     references SQUADRA (IdGiocatore);

alter table ESEMPLARE_POKEMON add constraint FKassociazione_FK
     foreign key (NumeroPokemon)
     references POKEMON (NumeroPokemon);

alter table EVOLUZIONE add constraint FKtramite
     foreign key (IdMetodo)
     references METODO_EVOLUTIVO (IdMetodo);

alter table EVOLUZIONE add constraint FKstadio_successivo_FK
     foreign key (NumeroPokemonStadioCorrente)
     references POKEMON (NumeroPokemon);

alter table EVOLUZIONE add constraint FKstadio_corrente_FK
     foreign key (NumeroPokemonStadioSuccessivo)
     references POKEMON (NumeroPokemon);

-- Not implemented
-- alter table GIOCATORE add constraint ID_GIOCATORE_CHK
--     check(exists(select * from SQUADRA
--                  where SQUADRA.IdGiocatore = IdGiocatore)); 

alter table GIOCATORE add constraint FKpreferenza_FK
     foreign key (IdEsemplarePreferito)
     references ESEMPLARE_POKEMON (IdEsemplare);

-- Not implemented
-- alter table METODO_EVOLUTIVO add constraint ID_METODO_EVOLUTIVO_CHK
--     check(exists(select * from EVOLUZIONE
--                  where EVOLUZIONE.IdMetodo = IdMetodo)); 

alter table MOSSA add constraint FKspecializzazione_FK
     foreign key (IdElemento)
     references ELEMENTO (IdElemento);

alter table PERMANENZA add constraint FKper_pok
     foreign key (NumeroPokemon)
     references POKEMON (NumeroPokemon);

alter table PERMANENZA add constraint FKper_bio_FK
     foreign key (IdBioma)
     references BIOMA (IdBioma);

-- Not implemented
-- alter table POKEMON add constraint ID_POKEMON_CHK
--     check(exists(select * from SET_STATISTICHE
--                  where SET_STATISTICHE.NumeroPokemon = NumeroPokemon)); 

-- Not implemented
-- alter table POKEMON add constraint ID_POKEMON_CHK
--     check(exists(select * from PERMANENZA
--                  where PERMANENZA.NumeroPokemon = NumeroPokemon)); 

-- Not implemented
-- alter table POKEMON add constraint ID_POKEMON_CHK
--     check(exists(select * from EVOLUZIONE
--                  where EVOLUZIONE.NumeroPokemonStadioSuccessivo = NumeroPokemon)); 

alter table POKEMON add constraint FKsecondario_FK
     foreign key (IdElementoSecondario)
     references ELEMENTO (IdElemento);

alter table POKEMON add constraint FKprimario_FK
     foreign key (IdElementoPrimario)
     references ELEMENTO (IdElemento);

alter table POKEMON add constraint FKevoluzione_precedente_FK
     foreign key (NumeroPokemonStadioPrecedente)
     references POKEMON (NumeroPokemon);

alter table SET_STATISTICHE add constraint FKparametri_FK
     foreign key (NumeroPokemon)
     references POKEMON (NumeroPokemon);

-- Not implemented
-- alter table SQUADRA add constraint FKpossesso_CHK
--     check(exists(select * from ESEMPLARE_POKEMON
--                  where ESEMPLARE_POKEMON.IdGiocatoreProprietario = IdGiocatore)); 

alter table SQUADRA add constraint FKpossesso_FK
     foreign key (IdGiocatore)
     references GIOCATORE (IdGiocatore);


-- Index Section
-- _____________ 

create unique index ID_ABILITA_IND
     on ABILITA (NomeAbilita);

create index FKcompetenza_IND
     on ABILITA (NumeroPokemon);

create unique index ID_ACQUISIZIONE_IND
     on ACQUISIZIONE (NomeMossa, NumeroPokemon);

create index FKacq_pok_IND
     on ACQUISIZIONE (NumeroPokemon);

create unique index ID_AMICIZIA_IND
     on AMICIZIA (IdGiocatoreAmico, IdGiocatore);

create index FKgiocatore2_IND
     on AMICIZIA (IdGiocatore);

create unique index ID_AVVISTAMENTO_IND
     on AVVISTAMENTO (IdGiocatore, NumeroPokemon);

create index FKavv_pok_IND
     on AVVISTAMENTO (NumeroPokemon);

create unique index SID_BATTAGLIA_IND
     on BATTAGLIA (IdGiocatoreSfidande, IdGiocatoreSfidato, Data);

create unique index ID_BATTAGLIA_IND
     on BATTAGLIA (IdBattaglia);

create index FKsfidante_IND
     on BATTAGLIA (IdGiocatoreSfidato);

create unique index ID_BIOMA_IND
     on BIOMA (IdBioma);

create unique index ID_BOX_POKEMON_IND
     on BOX_POKEMON (IdBox);

create index FKdotazione_IND
     on BOX_POKEMON (IdGiocatore);

create unique index ID_CATTURA_IND
     on CATTURA (IdGiocatore, NumeroPokemon);

create index FKcat_pok_IND
     on CATTURA (NumeroPokemon);

create unique index ID_ELEMENTO_IND
     on ELEMENTO (IdElemento);

create unique index ID_ESEMPLARE_POKEMON_IND
     on ESEMPLARE_POKEMON (IdEsemplare);

create index FKlocazione_IND
     on ESEMPLARE_POKEMON (IdBox);

create index FKcomposizione_IND
     on ESEMPLARE_POKEMON (IdGiocatoreProprietario);

create index FKassociazione_IND
     on ESEMPLARE_POKEMON (NumeroPokemon);

create unique index ID_EVOLUZIONE_IND
     on EVOLUZIONE (IdMetodo, NumeroPokemonStadioSuccessivo, NumeroPokemonStadioCorrente);

create unique index FKstadio_successivo_IND
     on EVOLUZIONE (NumeroPokemonStadioCorrente);

create unique index FKstadio_corrente_IND
     on EVOLUZIONE (NumeroPokemonStadioSuccessivo);

create unique index ID_GIOCATORE_IND
     on GIOCATORE (IdGiocatore);

create index FKpreferenza_IND
     on GIOCATORE (IdEsemplarePreferito);

create unique index ID_METODO_EVOLUTIVO_IND
     on METODO_EVOLUTIVO (IdMetodo);

create unique index ID_MOSSA_IND
     on MOSSA (NomeMossa);

create index FKspecializzazione_IND
     on MOSSA (IdElemento);

create unique index ID_PERMANENZA_IND
     on PERMANENZA (NumeroPokemon, IdBioma);

create index FKper_bio_IND
     on PERMANENZA (IdBioma);

create unique index ID_POKEMON_IND
     on POKEMON (NumeroPokemon);

create index FKsecondario_IND
     on POKEMON (IdElementoSecondario);

create index FKprimario_IND
     on POKEMON (IdElementoPrimario);

create unique index FKevoluzione_precedente_IND
     on POKEMON (NumeroPokemonStadioPrecedente);

create unique index ID_SET_STATISTICHE_IND
     on SET_STATISTICHE (IdStatistiche);

create index FKparametri_IND
     on SET_STATISTICHE (NumeroPokemon);

create unique index FKpossesso_IND
     on SQUADRA (IdGiocatore);

