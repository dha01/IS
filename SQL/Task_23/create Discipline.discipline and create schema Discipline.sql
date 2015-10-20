--Создание схемы Discipline
create schema  Discipline

--Создание таблицы Discipline.discipline
create table Discipline.discipline (
	discipline int identity(1,1),
	short_name varchar(30) NOT NULL,
	full_name varchar(255) NOT NULL,
	mem varchar(max),
	primary key (discipline)
);

--Добавление записи в таблицу Discipline.discipline
insert into Discipline.discipline
           (short_name,
            full_name,
            mem)
     values
           ('СТП',
		    'Современные технологии программирования',
			'Одним из перспективных направлений создания программного обеспечения повышенной безопасности является использование объектно-ориентированного программирования, идущего на смену структурному программированию. Применение объектно-ориентированного программирования (ООП) позволяет разделить фазы описания и фазы реализации абстрактных типов данных. Два выделенных модуля допускают раздельную компиляцию. В модуле описания задаются имена и типы внутренних защищенных и внешних данных, а также перечень процедур (методов) с описанием типов и количества параметров для них. В модуле реализации находятся собственно процедуры, обрабатывающие данные. Такое разделение повышает надежность программирования, так как доступ к внутренним данным возможен только с помощью процедур, перечисленных в мо- дуле описания. Это позволяет определять большую часть ошибок в обработке абстрактного типа данных на этапе компиляции, а не на этапе выполнения. Анализ программных средств на наличие закладок облегчается, так как допустимые действия с абстрактными данными задаются в модуле описания, а не в теле процедур. '
		   );



