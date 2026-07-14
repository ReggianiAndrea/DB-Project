-- Aggiungere un amico

insert into amicizia
values (1, 2, false);

-- Bloccare un utente

update amicizia
set bloccato = true
where idgiocatore = 1
and idgiocatoreamico = 2;

-- Mostrare amici con un certo pokemon preferito

select am.idgiocatore, am.nickname, am.immagine
from amicizia a
join giocatore am
join esemplare_pokemon e on am.idesemplarepreferito = e.idesemplare
join pokemon p on p.numeropokemon = e.numeropokemon
where a.idgiocatore = 1
and e.numeropokemon = 1
and a.bloccato = false;

-- Ottenere linea evolutiva di un pokemon

with recursive base as (
	select e.nome, p.nome evo, p.numeropokemon nevo, m.nome metodo
	from pokemon p
    join evoluzione ev on ev.numeropokemonstadiosuccessivo = p.numeropokemon
    join metodo_evolutivo m on m.idmetodo = ev.idmetodo
    join pokemon e on ev.numeropokemonstadiocorrente = e.numeropokemon
	where e.numeropokemon = (
		with recursive base as (
			select p.numeropokemon, p.nome, e.nome evo
			from pokemon p
			left join evoluzione ev on ev.numeropokemonstadiocorrente = p.numeropokemon
			left join pokemon e on ev.numeropokemonstadiosuccessivo = e.numeropokemon
			where p.numeropokemon = 4
			union all
			select p.numeropokemon, p.nome, e.nome
			from pokemon p
			left join evoluzione ev on ev.numeropokemonstadiocorrente = p.numeropokemon
			inner join base e on ev.numeropokemonstadiosuccessivo = e.numeropokemon
		)
		select numeropokemon from base order by numeropokemon limit 1
    )
	union all
	select e.evo, p.nome, p.numeropokemon, m.nome
	from pokemon p
    join evoluzione ev on ev.numeropokemonstadiosuccessivo = p.numeropokemon
    join metodo_evolutivo m on m.idmetodo = ev.idmetodo
    inner join base e on ev.numeropokemonstadiocorrente = e.nevo
)
select nome, evo, metodo from base;

-- Lista di pokemon di un certo bioma

select p.numeropokemon, p.nome
from pokemon p
join permanenza pr on pr.numeropokemon = p.numeropokemon
join bioma b on pr.idbioma = b.idbioma
where b.idbioma = 1;

-- Lista di pokemon che possono imparare una certa mossa

select p.numeropokemon, p.nome
from pokemon p
join acquisizione a on a.numeropokemon = p.numeropokemon
join mossa m on a.nomemossa = m.nomemossa
where m.nomemossa = "Azione";

-- Elementi più comuni tra pokemon di uno stesso bioma variante con possibilità di scegliere il bioma

select count(e.idelemento) numeropokemon, e.tipologia
from pokemon p
join permanenza pr on pr.numeropokemon = p.numeropokemon
join bioma b on pr.idbioma = b.idbioma
join elemento e on p.idelementoprimario = e.idelemento or p.idelementosecondario = e.idelemento
where b.idbioma = 2
group by e.idelemento
order by numeropokemon desc;

-- Elementi più comuni tra pokemon di uno stesso bioma

select count(e.idelemento) numeropokemon, e.tipologia, b.habitat
from pokemon p
join permanenza pr on pr.numeropokemon = p.numeropokemon
join bioma b on pr.idbioma = b.idbioma
join elemento e on p.idelementoprimario = e.idelemento or p.idelementosecondario = e.idelemento
group by e.idelemento, b.idbioma
order by numeropokemon desc;

-- Lista metodi evolutivi più comuni

select count(m.idmetodo) numeropokemon, m.nome
from pokemon p
join evoluzione e on e.numeropokemonstadiocorrente = p.numeropokemon
join pokemon evo on e.numeropokemonstadiosuccessivo = evo.numeropokemon
join metodo_evolutivo m on e.idmetodo = m.idmetodo
group by m.idmetodo
order by numeropokemon desc;