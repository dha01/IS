-- Создание таблицы TrainingPlan.team_plan
create table TrainingPlan.team_plan
(
	team_plan int identity (1,1),
	name varchar(max) not null,
	team int not null,
	semester int not null,
	lesson_type int not null,
	discipline int not null,
	auditory int not null,
	constraint PK__team_plan primary key (team_plan),
	constraint FK__team_plan__team foreign key (team) references Team.team,
	constraint FK__team_plan__semester foreign key (semester) references Calendar.semester,
	constraint FK__team_plan__lesson_type foreign key (lesson_type) references TrainingPlan.lesson_type,
	constraint FK__team_plan__discipline foreign key (discipline) references Discipline.discipline,
	constraint FK__team_plan__auditory foreign key (auditory) references Auditory.auditory
)