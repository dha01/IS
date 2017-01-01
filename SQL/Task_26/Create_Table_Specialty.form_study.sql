-- Создание схемы "Specialty"
create schema Specialty

-- Создание таблицы "form_study"
create table Specialty.form_study
(
--Необходимо составить запрос для создания таблицы-справочника(подобная таблица Task.task_prefix) 
--Specialty.form_study в базе данных.

--Так же требуется запрос на создание схемы Specialty.

--Необходимо добавить формы обучения:
--1. Очная;
--2. Заочная;

--Минимальный набор полей в таблице:

--1. Название;
--2. Код;
--3. Описание;

	form_study int identity not null,
	code varchar(30) not null,
	memo varchar(255) not null,

	constraint PK__form_study primary key (form_study),
	constraint FK__specialty__form_study foreign key (form_study) references Specialty.form_study
)
go

insert into Specialty.form_study(code,memo)
values
	('FullTime','Очная форма обучения'),
	('HalfTime','заочная форма обучения')