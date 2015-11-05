-- Создание таблицы-справочника Task.task-state
create table Task.task_state (
		task_state int identity,
		name nvarchar(255) not null,
		code varchar(30) not null,
		memo varchar(max),
		constraint PK__task_state primary key (discipline),
);

-- Добавление записи в таблицу Task.task_state
insert into Task.task_state
		(name,
		code,
		memo)
values 
		('В процессе выполнения', 'Progress', 'Задача находится в процессе выполнения'),
		('Выполнена', 'Complete', 'Задача выполненена'),
		('Ожидает проверки', 'Wait', 'Задача ожидает проверки')