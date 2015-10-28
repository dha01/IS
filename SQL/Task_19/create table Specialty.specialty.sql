-- Создание схемы "Specialty"
create schema Specialty

-- Создание таблицы "Specialty.specialty"
create table Specialty.specialty
(
	specialty int identity (1,1) not null,
	full_name varchar(255) not null,
	short_name varchar(30) not null,
	code nvarchar(30) not null,
	cathedra int not null,
	constraint PK__Specialty primary key (specialty),
	constraint FK__specialty__cathedra foreign key (cathedra) references Cathedra.cathedra)


insert into Specialty.specialty(full_name,short_name,code,cathedra)
     values
           ('Информатика','Ифн','34654','45655454')




