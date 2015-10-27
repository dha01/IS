-- Создание схемы "Person"
create schema Person

-- Создание таблицы "Person.student "
create table Person.student 
(
	student int identity not null,
	event_date datetime not null,
	person int not null,
	group_id int not null,
	event_type tinyint,
	constraint PK__student primary key (student),
	constraint FK__person__student foreign key (person) references Person.person
)