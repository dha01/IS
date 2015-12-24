-- Создание схемы TrainingPlan
create schema TrainingPlan

-- Создание таблицы TrainingPlan.specialty_semester_plan
create table TrainingPlan.specialty_semester_plan(
	specialty_semester_plan int identity (1,1) not null,
	discipline int not null,
	specialty_detail int not null,
	semester int not null,
	lesson_type int not null,
	plan_time int not null,
	constraint PK__specialty_semester_plan primary key (specialty_semester_plan),
	constraint FK__specialty_semester_plan__discipline foreign key (discipline) references Discipline.discipline,
	constraint FK__specialty_semester_plan__specialty_detail foreign key (specialty_detail) references Specialty.specialty_detail,
	constraint FK__specialty_semester_plan__semester foreign key (semester) references Calendar.semester,
	constraint FK__specialty_semester_plan__lesson_type foreign key (lesson_type) references TrainingPlan.lesson_type,
)

-- Добавление записи в таблицу TrainingPlan.specialty_semester_plan
insert into TrainingPlan.specialty_semester_plan (
	discipline,
	specialty_detail,
	semester,
	lesson_type,
	plan_time
	)
	values
	(1,
	1,
	2,
	3,
	144
    )