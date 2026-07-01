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
     NumeroPokemonStadioPrecedente int,
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

-- Inserimenti

insert into ELEMENTO values (1, "Normale");
insert into ELEMENTO values (2, "Fuoco");
insert into ELEMENTO values (3, "Lotta");
insert into ELEMENTO values (4, "Acqua");
insert into ELEMENTO values (5, "Volante");
insert into ELEMENTO values (6, "Erba");
insert into ELEMENTO values (7, "Veleno");
insert into ELEMENTO values (8, "Elettro");
insert into ELEMENTO values (9, "Terra");
insert into ELEMENTO values (10, "Psico");
insert into ELEMENTO values (11, "Roccia");
insert into ELEMENTO values (12, "Ghiaccio");
insert into ELEMENTO values (13, "Coleottero");
insert into ELEMENTO values (14, "Drago");
insert into ELEMENTO values (15, "Spettro");
insert into ELEMENTO values (16, "Buio");
insert into ELEMENTO values (17, "Acciaio");
insert into ELEMENTO values (18, "Folletto");

insert into METODO_EVOLUTIVO values (1, "Livello", "Un Pokémon potrebbe evolversi facendo tanta esperienza in battaglia.");
insert into METODO_EVOLUTIVO values (2, "Oggetto", "Un Pokémon potrebbe evolversi quanto va a contatto con un oggetto specifico.");
insert into METODO_EVOLUTIVO values (3, "Scambio", "Un Pokémon potrebbe evolversi quando viene scambiato con un Pokémon di un altro allenatore.");

insert into BIOMA values (1, "Prateria", "");
insert into BIOMA values (2, "Bosco", "");
insert into BIOMA values (3, "Costa", "");
insert into BIOMA values (4, "Mare", "");
insert into BIOMA values (5, "Grotta", "");
insert into BIOMA values (6, "Montagna", "");
insert into BIOMA values (7, "Terreno Spoglio", "");
insert into BIOMA values (8, "Città", "");

-- Dede

insert into POKEMON values (1, null, "Seme", "Bulbasaur", "Ha uno strano bulbo piantato sul dorso fin dalla nascita che cresce e si sviluppa assieme a lui.", 0.7, 6.9, "Bestia", "bulbasaur.png", "Verde", 6, 7);
insert into POKEMON values (2, 1, "Seme", "Ivysaur", "Dicono che il bocciolo sul suo dorso si schiuda in un grande fiore dopo aver assorbito nutrimento.", 1.0, 13.0, "Bestia", "ivysaur.png", "Verde", 6, 7);
insert into POKEMON values (3, 2, "Seme", "Venusaur", "Il giorno dopo che è piovuto, il fiore sul suo dorso emana un profumo più intenso e attira gli altri Pokémon.", 2.0, 100.0, "Dinosauro", "venusaur.png", "Verde", 6, 7);
insert into POKEMON values (4, null, "Lucertola", "Charmander", "La fiamma che Charmander ha sulla coda indica la sua forza vitale. Se è in forma, la fiamma è vivace.", 0.6, 8.5, "Rettile", "charmander.png", "Rosso", 2, null);
insert into POKEMON values (5, 4, "Fiamma", "Charmeleon", "Fa cadere a terra il nemico colpendolo con la coda, per poi finirlo con gli artigli affilati.", 1.1, 19.0, "Rettile", "charmeleon.png", "Rosso", 2, null);
insert into POKEMON values (6, 5, "Fiamma", "Charizard", "Grazie alle sue ali può volare fino a 1.400 m d'altezza. Sputa fiamme incandescenti.", 1.7, 90.5, "Drago", "charizard.png", "Rosso", 2, 5);
insert into POKEMON values (7, null, "Tartaghina", "Squirtle", "Si ritira nel suo guscio per proteggersi e, alla prima occasione, contrattacca colpendo il nemico con spruzzi d'acqua.", 0.5, 9.0, "Bestia", "squirtle.png", "Blu", 4, null);
insert into POKEMON values (8, 7, "Tartaruga", "Wartortle", "Quando sta per ricevere un colpo sulla testa si ritira nella corazza per evitarlo. La coda, però, resta sempre un po' fuori.", 1.0, 22.5, "Tartaruga", "wartortle.png", "Blu", 4, null);
insert into POKEMON values (9, 8, "Carapace", "Blastoise", "Mette KO gli avversari schiacciandoli sotto il corpo possente. Se è in difficoltà, si ritrae nella corazza.", 1.6, 85.5, "Tartaruga", "blastoise.png", "Blu", 4, null);
insert into POKEMON values (16, null, "Uccellino", "Pidgey", "È docile e preferisce evitare conflitti, ma se viene disturbato contrattacca ferocemente.", 0.3, 1.8, "Uccello", "pidgey.png", "Marrone", 1, 5);
insert into POKEMON values (17, 16, "Uccello", "Pidgeotto", "Controlla un vasto territorio e prende a beccate qualsiasi intruso.", 1.1, 30.0, "Uccello", "pidgeotto.png", "Marrone", 1, 5);
insert into POKEMON values (18, 17, "Uccello", "Pidgeot", "Quando caccia, vola rasente alla superficie dell'acqua e cattura Magikarp e altre prede afferrandole con gli artigli.", 1.5, 39.5, "Uccello", "pidgeot.png", "Marrone", 1, 5);
insert into POKEMON values (25, null, "Topo", "Pikachu", "Quando si sente minacciato emette scariche elettriche dalle due piccole sacche sulle guance.", 0.4, 6.0, "Topo", "pikachu.png", "Giallo", 8, null);
insert into POKEMON values (26, 25, "Topo", "Raichu", "Quando l'elettricità al suo interno si accumula finisce per stimolarne i muscoli, rendendolo più aggressivo del solito.", 0.8, 30.0, "Topo", "raichu.png", "Giallo", 8, null);
insert into POKEMON values (27, null, "Topo", "Sandshrew", "Se cade da una grande altezza, questo Pokémon può salvarsi appallottolandosi e rimbalzando.", 0.6, 12.0, "Bestia", "sandshrew.png", "Giallo", 9, null);

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

