-- Создание схемы TrainingPlan
create schema TrainingPlan
go

-- Создание таблицы TrainingPlan.lesson2lecturer
create table TrainingPlan.lesson2lecturer(	
	lesson2lecturer int identity,
	lesson int not null,
	person int not null,
	constraint PK__lesson primary key (lesson),
	constraint FK__lesson2lecturer__person foreign key (person) references Person.person
)