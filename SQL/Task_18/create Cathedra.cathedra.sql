--Создание схемы "Cathedra"
create schema Cathedra

--Создание таблицы "cathedra"
create table Cathedra.cathedra(
	cathedra int identity (1,1),
	full_name varchar(255),
	short_name varchar(30),
	faculty varchar(255),
	primary key (cathedra)
)
