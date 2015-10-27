-- Создание схемы "Specialty.specialty"
create schema Specialty

-- Создание таблицы "Specialty.specialty"
create table Specialty.specialty
(
	Specialty int identity (1,1) not null,
	Name varchar(255) not null,
	short_name varchar(30) not null,
	Kod_Specialty int not null,
	cathedra int not null,
	constraint PK__Specialty primary key (Specialty),
	constraint FK__specialty__cathedra foreign key (cathedra) references Cathedra.cathedra
)
