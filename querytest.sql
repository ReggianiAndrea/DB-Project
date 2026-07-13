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
