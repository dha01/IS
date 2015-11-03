create schema Faculty 
--Создание схемы Faculty

create table Faculty.faculty
(
	faculty int identity(1,1),
	full_name varchar(255),
	short_name varchar(30),
	primary key (faculty)
)

--Добавление записи
insert into Faculty.faculty(full_name,short_name)
values
		(
			'Информатика и вычислительная техника',
			'ИВТ'
		)






