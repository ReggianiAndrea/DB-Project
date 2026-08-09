-- sbloccare un utente
update amicizia
set bloccato = false
where idgiocatore = 1 
and idgiocatoreamico = 2;


-- aggiungere un pokemon visto
insert into avvistamento (idgiocatore, numeropokemon)
values (1, 7);


-- listing di pokemon che si evolvono tramite il metodo evolutivo specificato
select p.numeropokemon, p.nome as pokemonstadiocorrente, evo.nome as pokemonevoluto, m.nome as metodoevolutivo
from pokemon p
join evoluzione e on p.numeropokemon = e.numeropokemonstadiocorrente
join pokemon evo on e.numeropokemonstadiosuccessivo = evo.numeropokemon
join metodo_evolutivo m on e.idmetodo = m.idmetodo
where m.nome = "Livello";


-- listing di pokemon che hanno l'elemento specificato
select p.numeropokemon, p.nome as nomepokemon, e1.tipologia as elementoprimario, e2.tipologia as elementosecondario
from pokemon p
join elemento e1 on p.idelementoprimario = e1.idelemento
left join elemento e2 on p.idelementosecondario = e2.idelemento
where e1.tipologia = "Fuoco" 
   or e2.tipologia = "Fuoco";


-- visualizzare quali pokemon shiny possiede un allenatore
select ep.idesemplare, p.nome as speciepokemon, ep.nomeallenatore, ep.livello, ep.sesso
from esemplare_pokemon ep
join pokemon p on ep.numeropokemon = p.numeropokemon
where ep.idgiocatoreproprietario = 1 
and ep.cromatico = true;


-- numero di utenti che hanno almeno un pokemon shiny
select 
    count(distinct ep.idgiocatoreproprietario) as numeroutenticonshiny
from esemplare_pokemon ep
where ep.cromatico = true;


-- aggiungere un pokemon nel database
-- 1. inserimento del set statistiche
insert into set_statistiche (
    idstatistiche, puntisalute, attacco, difesa, attaccospeciale, difesaspeciale, velocita
) values (
    null, 45, 49, 65, 49, 65, 45
);

-- 2. inserimento del pokemon (usa last_insert_id() per agganciare le statistiche appena create)
insert into pokemon (
    numeropokemon, specie, nome, descrizionepokemon, altezza, peso, impronta, immagine, 
    coloredominante, idelementoprimario, idelementosecondario, idstatistiche, nomeabilita
) values (
    152, "Foglia", "Chikorita", "Ama crogiolarsi al sole. Usa la foglia sulla testa per trovare posti caldi.", 
    0.9, 6.4, "Bestia", "152.png", "Verde", 
    6, null, last_insert_id(), "Erbaiuto"
);