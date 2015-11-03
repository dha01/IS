-- Создание таблицы "Task.task_state_log"
create table Task.task_state_log 
(
	task int identity not null,
	task_state int not null,
	event_date datetime not null default getdate(),
	constraint PK__task primary key (task),
	constraint FK__task__task_state foreign key (task_state) references Task.task_state
)