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
