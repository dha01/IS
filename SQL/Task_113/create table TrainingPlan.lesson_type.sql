-- Создание схемы "TrainingPlan"
create schema TrainingPlan

-- Создание таблицы "TrainingPlan.lesson_type"
create table TrainingPlan.lesson_type
(
	lesson_type int identity (1,1) not null,
	code varchar(50) not null,
	memo varchar(max) not null,
	constraint PK__lesson_type primary key (lesson_type)
)

-- Добавляние записей в таблицу.
insert into TrainingPlan.lesson_type(code,memo)
	values
			('Lecture', 'Лекция'),
			('Practice', 'Практика'),
			('Laboratory', 'Лабораторная'),
			('Consultation', 'Консультация'),
			('Exam', 'Экзамен')
			