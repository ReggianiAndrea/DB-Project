use PokedexADA;

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
insert into BIOMA values (8, "Deserto", "");
insert into BIOMA values (9, "Vulcano", "");
insert into BIOMA values (10, "Città", "");

-- Dede

insert into SET_STATISTICHE (IdStatistiche, PuntiSalute, Attacco, Difesa, AttaccoSpeciale, DifesaSpeciale, Velocita) values (null, 45, 49, 49, 65, 65, 45);
insert into SET_STATISTICHE (IdStatistiche, PuntiSalute, Attacco, Difesa, AttaccoSpeciale, DifesaSpeciale, Velocita) values (null, 60, 62, 63, 80, 80, 60);
insert into SET_STATISTICHE (IdStatistiche, PuntiSalute, Attacco, Difesa, AttaccoSpeciale, DifesaSpeciale, Velocita) values (null, 80, 82, 83, 100, 100, 80);
insert into SET_STATISTICHE (IdStatistiche, PuntiSalute, Attacco, Difesa, AttaccoSpeciale, DifesaSpeciale, Velocita) values (null, 39, 52, 43, 60, 50, 65);
insert into SET_STATISTICHE (IdStatistiche, PuntiSalute, Attacco, Difesa, AttaccoSpeciale, DifesaSpeciale, Velocita) values (null, 58, 64, 58, 80, 65, 80);
insert into SET_STATISTICHE (IdStatistiche, PuntiSalute, Attacco, Difesa, AttaccoSpeciale, DifesaSpeciale, Velocita) values (null, 78, 84, 78, 109, 85, 100);
insert into SET_STATISTICHE (IdStatistiche, PuntiSalute, Attacco, Difesa, AttaccoSpeciale, DifesaSpeciale, Velocita) values (null, 44, 48, 65, 50, 64, 43);
insert into SET_STATISTICHE (IdStatistiche, PuntiSalute, Attacco, Difesa, AttaccoSpeciale, DifesaSpeciale, Velocita) values (null, 59, 63, 80, 65, 80, 58);
insert into SET_STATISTICHE (IdStatistiche, PuntiSalute, Attacco, Difesa, AttaccoSpeciale, DifesaSpeciale, Velocita) values (null, 79, 83, 100, 85, 105, 78);
insert into SET_STATISTICHE (IdStatistiche, PuntiSalute, Attacco, Difesa, AttaccoSpeciale, DifesaSpeciale, Velocita) values (null, 40, 45, 40, 35, 35, 56);
insert into SET_STATISTICHE (IdStatistiche, PuntiSalute, Attacco, Difesa, AttaccoSpeciale, DifesaSpeciale, Velocita) values (null, 63, 60, 55, 50, 50, 71);
insert into SET_STATISTICHE (IdStatistiche, PuntiSalute, Attacco, Difesa, AttaccoSpeciale, DifesaSpeciale, Velocita) values (null, 83, 80, 75, 70, 70, 101);
insert into SET_STATISTICHE (IdStatistiche, PuntiSalute, Attacco, Difesa, AttaccoSpeciale, DifesaSpeciale, Velocita) values (null, 35, 55, 40, 50, 50, 90);
insert into SET_STATISTICHE (IdStatistiche, PuntiSalute, Attacco, Difesa, AttaccoSpeciale, DifesaSpeciale, Velocita) values (null, 60, 90, 55, 90, 80, 110);
insert into SET_STATISTICHE (IdStatistiche, PuntiSalute, Attacco, Difesa, AttaccoSpeciale, DifesaSpeciale, Velocita) values (null, 50, 75, 85, 20, 30, 40);

insert into ABILITA values ("Erbaiuto", "Quando al Pokémon rimangono pochi PS, la potenza delle sue mosse di tipo Erba aumenta.");
insert into ABILITA values ("Aiutofuoco", "Quando al Pokémon rimangono pochi PS, la potenza delle sue mosse di tipo Fuoco aumenta.");
insert into ABILITA values ("Acquaiuto", "Quando al Pokémon rimangono pochi PS, la potenza delle sue mosse di tipo Acqua aumenta.");
insert into ABILITA values ("Sguardofermo", "La vista acuta del Pokémon impedisce che la sua precisione diminuisca.");
insert into ABILITA values ("Statico", "Il Pokémon si ricopre di elettricità statica e può causare paralisi a chi è entrato in contatto con lui.");
insert into ABILITA values ("Sabbiavelo", "L'elusione aumenta durante le tempeste di sabbia.");

insert into POKEMON values (1, null, "Seme", "Bulbasaur", "Ha uno strano bulbo piantato sul dorso fin dalla nascita che cresce e si sviluppa assieme a lui.", 0.7, 6.9, "Bestia", "001.png", "Verde", 6, 7, 1, "Erbaiuto");
insert into POKEMON values (2, 1, "Seme", "Ivysaur", "Dicono che il bocciolo sul suo dorso si schiuda in un grande fiore dopo aver assorbito nutrimento.", 1.0, 13.0, "Bestia", "002.png", "Verde", 6, 7, 2, "Erbaiuto");
insert into POKEMON values (3, 2, "Seme", "Venusaur", "Il giorno dopo che è piovuto, il fiore sul suo dorso emana un profumo più intenso e attira gli altri Pokémon.", 2.0, 100.0, "Dinosauro", "003.png", "Verde", 6, 7, 3, "Erbaiuto");
insert into POKEMON values (4, null, "Lucertola", "Charmander", "La fiamma che Charmander ha sulla coda indica la sua forza vitale. Se è in forma, la fiamma è vivace.", 0.6, 8.5, "Rettile", "004.png", "Rosso", 2, null, 4, "Aiutofuoco");
insert into POKEMON values (5, 4, "Fiamma", "Charmeleon", "Fa cadere a terra il nemico colpendolo con la coda, per poi finirlo con gli artigli affilati.", 1.1, 19.0, "Rettile", "005.png", "Rosso", 2, null, 5, "Aiutofuoco");
insert into POKEMON values (6, 5, "Fiamma", "Charizard", "Grazie alle sue ali può volare fino a 1.400 m d'altezza. Sputa fiamme incandescenti.", 1.7, 90.5, "Drago", "006.png", "Rosso", 2, 5, 6, "Aiutofuoco");
insert into POKEMON values (7, null, "Tartaghina", "Squirtle", "Si ritira nel suo guscio per proteggersi e, alla prima occasione, contrattacca colpendo il nemico con spruzzi d'acqua.", 0.5, 9.0, "Bestia", "007.png", "Blu", 4, null, 7, "Acquaiuto");
insert into POKEMON values (8, 7, "Tartaruga", "Wartortle", "Quando sta per ricevere un colpo sulla testa si ritira nella corazza per evitarlo. La coda, però, resta sempre un po' fuori.", 1.0, 22.5, "Tartaruga", "008.png", "Blu", 4, null, 8, "Acquaiuto");
insert into POKEMON values (9, 8, "Carapace", "Blastoise", "Mette KO gli avversari schiacciandoli sotto il corpo possente. Se è in difficoltà, si ritrae nella corazza.", 1.6, 85.5, "Tartaruga", "009.png", "Blu", 4, null, 9, "Acquaiuto");
insert into POKEMON values (16, null, "Uccellino", "Pidgey", "È docile e preferisce evitare conflitti, ma se viene disturbato contrattacca ferocemente.", 0.3, 1.8, "Uccello", "016.png", "Marrone", 1, 5, 10, "Sguardofermo");
insert into POKEMON values (17, 16, "Uccello", "Pidgeotto", "Controlla un vasto territorio e prende a beccate qualsiasi intruso.", 1.1, 30.0, "Uccello", "017.png", "Marrone", 1, 5, 11, "Sguardofermo");
insert into POKEMON values (18, 17, "Uccello", "Pidgeot", "Quando caccia, vola rasente alla superficie dell'acqua e cattura Magikarp e altre prede afferrandole con gli artigli.", 1.5, 39.5, "Uccello", "018.png", "Marrone", 1, 5, 12, "Sguardofermo");
insert into POKEMON values (25, null, "Topo", "Pikachu", "Quando si sente minacciato emette scariche elettriche dalle due piccole sacche sulle guance.", 0.4, 6.0, "Topo", "025.png", "Giallo", 8, null, 13, "Statico");
insert into POKEMON values (26, 25, "Topo", "Raichu", "Quando l'elettricità al suo interno si accumula finisce per stimolarne i muscoli, rendendolo più aggressivo del solito.", 0.8, 30.0, "Topo", "026.png", "Giallo", 8, null, 14, "Statico");
insert into POKEMON values (27, null, "Topo", "Sandshrew", "Se cade da una grande altezza, questo Pokémon può salvarsi appallottolandosi e rimbalzando.", 0.6, 12.0, "Bestia", "027.png", "Giallo", 9, null, 15, "Sabbiavelo");

insert into MOSSA values ("Azione", "Infligge danno e non ha nessun effetto aggiuntivo.", 100, 40, 1);
insert into MOSSA values ("Graffio", "Infligge danno e non ha nessun effetto aggiuntivo.", 100, 40, 1);
insert into MOSSA values ("Attacco Rapido", "Infligge danno ed è una mossa ad alta priorità.", 100, 40, 1);
insert into MOSSA values ("Ruggito", "Riduce l'Attacco di tutti gli avversari adiacenti di un livello.", 100, null, 1);
insert into MOSSA values ("Frustata", "Infligge danno e non ha nessun effetto aggiuntivo.", 100, 45, 6);
insert into MOSSA values ("Braciere", "Infligge danno e ha il 10% di probabilità di scottare il bersaglio.", 100, 40, 2);
insert into MOSSA values ("Pistolacqua", "Infligge danno e non ha nessun effetto aggiuntivo.", 100, 40, 4);
insert into MOSSA values ("Raffica", "Infligge danno e non ha nessun effetto aggiuntivo.", 100, 40, 5);
insert into MOSSA values ("Tuonoshock", "Infligge danno e ha il 10% di probabilità di paralizzare il bersaglio.", 100, 40, 8);
insert into MOSSA values ("Sonnifero", "Fa addormentare il bersaglio.", 75, null, 6);
insert into MOSSA values ("Velenpolvere", "Avvelena il bersaglio.", 75, null, 7);
insert into MOSSA values ("Muro di Fumo", "Riduce la precisione del bersaglio di un livello", 100, null, 1);
insert into MOSSA values ("Turbosabbia", "Riduce la precisione del bersaglio di un livello", 100, null, 9);
insert into MOSSA values ("Dragospiro", "Infligge danno e ha il 30% di probabilità di paralizzare il bersaglio.", 100, 60, 14);
insert into MOSSA values ("Ritirata", "Aumenta la Difesa dell'utilizzatore di un livello.", 101, null, 4);
insert into MOSSA values ("Agilità", "Aumenta la Velocità dell'utilizzatore di due livelli.", 101, null, 10);
insert into MOSSA values ("Trespolo", "Ripristina metà dei PS massimi dell'utilizzatore. L'eventuale tipo Volante del Pokémon verrà ignorato fino alla fine del turno.", 101, null, 5);
insert into MOSSA values ("Protezione", "Rende l'utilizzatore invulnerabile a tutti gli effetti delle mosse durante il turno in cui viene usata.", 101, null, 1);
insert into MOSSA values ("Tuononda", "Paralizza il bersaglio.", 101, null, 8);
insert into MOSSA values ("Fulmine", "Infligge danno e ha il 10% di probabilità di paralizzare il bersaglio.", 100, 90, 8);
insert into MOSSA values ("Petalodanza", "Infligge danno e causa all'utilizzatore lo stato di collera.", 100, 120, 6);
insert into MOSSA values ("Eterelama", "Infligge danno e ha il 30% di probabilità di far tentennare il bersaglio.", 95, 75, 5);
insert into MOSSA values ("Cannonflash", "Infligge danno e ha il 10% di probabilità di diminuire la Difesa Speciale del bersaglio di un livello.", 100, 80, 17);
insert into MOSSA values ("Rapigiro", "Infligge danno e aumenta la Velocità dell'utilizzatore di un livello.", 100, 50, 1);
insert into MOSSA values ("Rotolamento", "Infligge danno nel corso di 5 turni, in ognuno dei quali viene effettuato un controllo della precisione.", 90, 30, 11);
insert into MOSSA values ("Terremoto", "Infligge danno e non ha nessun effetto aggiuntivo.", 100, 100, 9);

# Bulbasaur
insert into ACQUISIZIONE values ("Azione", 1);
insert into ACQUISIZIONE values ("Frustata", 1);
insert into ACQUISIZIONE values ("Ruggito", 1);
insert into ACQUISIZIONE values ("Sonnifero", 1);
insert into ACQUISIZIONE values ("Velenpolvere", 1);

# Ivysaur
insert into ACQUISIZIONE values ("Azione", 2);
insert into ACQUISIZIONE values ("Frustata", 2);
insert into ACQUISIZIONE values ("Ruggito", 2);
insert into ACQUISIZIONE values ("Sonnifero", 2);
insert into ACQUISIZIONE values ("Velenpolvere", 2);

# Venusaur
insert into ACQUISIZIONE values ("Azione", 3);
insert into ACQUISIZIONE values ("Frustata", 3);
insert into ACQUISIZIONE values ("Ruggito", 3);
insert into ACQUISIZIONE values ("Sonnifero", 3);
insert into ACQUISIZIONE values ("Velenpolvere", 3);
insert into ACQUISIZIONE values ("Petalodanza", 3);

# Charmander
insert into ACQUISIZIONE values ("Braciere", 4);
insert into ACQUISIZIONE values ("Graffio", 4);
insert into ACQUISIZIONE values ("Muro di Fumo", 4);
insert into ACQUISIZIONE values ("Ruggito", 4);
insert into ACQUISIZIONE values ("Dragospiro", 4);

# Charmeleon
insert into ACQUISIZIONE values ("Braciere", 5);
insert into ACQUISIZIONE values ("Graffio", 5);
insert into ACQUISIZIONE values ("Muro di Fumo", 5);
insert into ACQUISIZIONE values ("Ruggito", 5);
insert into ACQUISIZIONE values ("Dragospiro", 5);

# Charizard
insert into ACQUISIZIONE values ("Braciere", 6);
insert into ACQUISIZIONE values ("Graffio", 6);
insert into ACQUISIZIONE values ("Muro di Fumo", 6);
insert into ACQUISIZIONE values ("Ruggito", 6);
insert into ACQUISIZIONE values ("Dragospiro", 6);
insert into ACQUISIZIONE values ("Eterelama", 6);

# Squirtle
insert into ACQUISIZIONE values ("Azione", 7);
insert into ACQUISIZIONE values ("Pistolacqua", 7);
insert into ACQUISIZIONE values ("Ritirata", 7);
insert into ACQUISIZIONE values ("Rapigiro", 7);
insert into ACQUISIZIONE values ("Protezione", 7);

# Wartortle
insert into ACQUISIZIONE values ("Azione", 8);
insert into ACQUISIZIONE values ("Pistolacqua", 8);
insert into ACQUISIZIONE values ("Ritirata", 8);
insert into ACQUISIZIONE values ("Rapigiro", 8);
insert into ACQUISIZIONE values ("Protezione", 8);

# Blastoise
insert into ACQUISIZIONE values ("Azione", 9);
insert into ACQUISIZIONE values ("Pistolacqua", 9);
insert into ACQUISIZIONE values ("Ritirata", 9);
insert into ACQUISIZIONE values ("Rapigiro", 9);
insert into ACQUISIZIONE values ("Protezione", 9);
insert into ACQUISIZIONE values ("Cannonflash", 9);

# Pidgey
insert into ACQUISIZIONE values ("Azione", 16);
insert into ACQUISIZIONE values ("Turbosabbia", 16);
insert into ACQUISIZIONE values ("Raffica", 16);
insert into ACQUISIZIONE values ("Attacco Rapido", 16);
insert into ACQUISIZIONE values ("Agilità", 16);
insert into ACQUISIZIONE values ("Trespolo", 16);
insert into ACQUISIZIONE values ("Eterelama", 16);

# Pidgeotto
insert into ACQUISIZIONE values ("Azione", 17);
insert into ACQUISIZIONE values ("Turbosabbia", 17);
insert into ACQUISIZIONE values ("Raffica", 17);
insert into ACQUISIZIONE values ("Attacco Rapido", 17);
insert into ACQUISIZIONE values ("Agilità", 17);
insert into ACQUISIZIONE values ("Trespolo", 17);
insert into ACQUISIZIONE values ("Eterelama", 17);

# Pidgeot
insert into ACQUISIZIONE values ("Azione", 18);
insert into ACQUISIZIONE values ("Turbosabbia", 18);
insert into ACQUISIZIONE values ("Raffica", 18);
insert into ACQUISIZIONE values ("Attacco Rapido", 18);
insert into ACQUISIZIONE values ("Agilità", 18);
insert into ACQUISIZIONE values ("Trespolo", 18);
insert into ACQUISIZIONE values ("Eterelama", 18);

# Pikachu
insert into ACQUISIZIONE values ("Attacco Rapido", 25);
insert into ACQUISIZIONE values ("Ruggito", 25);
insert into ACQUISIZIONE values ("Tuonoshock", 25);
insert into ACQUISIZIONE values ("Tuononda", 25);
insert into ACQUISIZIONE values ("Agilità", 25);
insert into ACQUISIZIONE values ("Fulmine", 25);

# Raichu
insert into ACQUISIZIONE values ("Attacco Rapido", 26);
insert into ACQUISIZIONE values ("Ruggito", 26);
insert into ACQUISIZIONE values ("Tuonoshock", 26);
insert into ACQUISIZIONE values ("Tuononda", 26);
insert into ACQUISIZIONE values ("Agilità", 26);
insert into ACQUISIZIONE values ("Fulmine", 26);

# Sandshrew
insert into ACQUISIZIONE values ("Graffio", 27);
insert into ACQUISIZIONE values ("Turbosabbia", 27);
insert into ACQUISIZIONE values ("Rotolamento", 27);
insert into ACQUISIZIONE values ("Rapigiro", 27);
insert into ACQUISIZIONE values ("Agilità", 27);
insert into ACQUISIZIONE values ("Terremoto", 27);

# Sandslash
#insert into ACQUISIZIONE values ("Graffio", 28);
#insert into ACQUISIZIONE values ("Turbosabbia", 28);
#insert into ACQUISIZIONE values ("Rotolamento", 28);
#insert into ACQUISIZIONE values ("Rapigiro", 28);
#insert into ACQUISIZIONE values ("Agilità", 28);
#insert into ACQUISIZIONE values ("Terremoto", 28);

insert into PERMANENZA values (1, 1);
insert into PERMANENZA values (1, 2);
insert into PERMANENZA values (1, 3);
insert into PERMANENZA values (9, 4);
insert into PERMANENZA values (9, 5);
insert into PERMANENZA values (9, 6);
insert into PERMANENZA values (3, 7);
insert into PERMANENZA values (3, 8);
insert into PERMANENZA values (3, 9);
insert into PERMANENZA values (2, 16);
insert into PERMANENZA values (2, 17);
insert into PERMANENZA values (2, 18);
insert into PERMANENZA values (2, 25);
insert into PERMANENZA values (2, 26);
insert into PERMANENZA values (8, 27);

# Bulbasaur, Ivysaur, Venusaur
insert into EVOLUZIONE values (1, 2, 1);
insert into EVOLUZIONE values (2, 3, 1);

# Charmander, Charmeleon, Charizard
insert into EVOLUZIONE values (4, 5, 1);
insert into EVOLUZIONE values (5, 6, 1);

# Squirtle, Wartortle, Blastoise
insert into EVOLUZIONE values (7, 8, 1);
insert into EVOLUZIONE values (8, 9, 1);

# Pidgey, Pidgeotto, Pidgeot
insert into EVOLUZIONE values (16, 17, 1);
insert into EVOLUZIONE values (17, 18, 1);

# Pikachu, Raichu
insert into EVOLUZIONE values (25, 26, 2);