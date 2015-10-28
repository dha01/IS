-- Создание схемы Auditory
create schema Auditory

-- Создание таблицы Auditory.auditory
create table Auditory.auditory(
	auditory int identity (1,1),
	number int not null,
	full_name varchar (255) not null,
	memo varchar (max) not null,
	housing int not null,
	lever int not null,
	capacity int not null 	
)

-- Добавление записи в таблицу Auditory.auditory
insert into Auditory.auditory(
	number,
	full_name,
	memo,
	housing,
	lever,
	capacity
	)
	values
	(1,
	'Аудитория информатики',
	'В аудитории присутствует 16 компьютеров, проектор, интерактивная доска',
	1,
	3,
	15
)

