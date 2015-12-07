-- Создание схемы TrainingPlan
create schema TrainingPlan
go

-- Создание таблицы TrainingPlan.lesson
create table TrainingPlan.lesson2auditory(
	lesson2auditory int identity,
	lesson int not null,
	auditory int not null  
	constraint PK__lesson primary key (lesson),
	constraint FK__lesson2auditory__auditory foreign key (auditory) references Auditory.auditory
)	