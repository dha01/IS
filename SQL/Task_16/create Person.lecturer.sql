--Создание схемы "Person"
create schema Person

--Создание таблицы "lecturer"
create table Person.lecturer
(
	lecturer int identity (1,1) not null,
	date_sobitiya varchar(255) not null,
	person int,
	cathedra int,
	act int,
	constraint PK__lecturer primary key (lecturer),
	constraint FK__lecturer__person foreign key (lecturer) references Person.person,
	constraint FK__lecturer__cafedra foreign key (lecturer) references Cathedra.cathedra,

)