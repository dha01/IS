-- Создание схемы TrainingPlan
create schema TrainingPlan
go

-- Создание таблицы TrainingPlan.lesson2team
create table TrainingPlan.lesson2team(	
	lesson2team int identity,
	lesson int not null,
	team int not null,
	constraint PK__lesson2team primary key (lesson2team),
	constraint FK__lesson2team__team foreign key (team) references Team.team,
	constraint FK__lesson2team__lesson foreign key (lesson) references TraningPlan.lesson
)