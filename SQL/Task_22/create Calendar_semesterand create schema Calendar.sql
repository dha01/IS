-- Создание схемы Calendar
create schema Calendar

-- Создание таблицы Calendar.semester
create table Calendar.semester(
	Calendar_semester int identity (1,1),
	day_begin_sem date not null,
	day_end_sem date not null,
	constraint PK__Calendar_semester primary key (Calendar_semester),
	)

-- Добавление записи в таблицу Calendar.semester
insert into Calendar.semester(
	day_begin_sem,
	day_end_sem
	)
	values
	('01.09.2015',
	'01.06.2016'
    )