-- Создание схемы "Calendar"
create schema Calendar
-- Создание таблицы "Calendar.work_day"
create table Calendar.work_day
(
	work_day int identity not null,
	date date not null,
 	work_day_type int not null,
	work_week int not null
	constraint PK__calendar primary key (work_day),
 	constraint FK__calendar__work_week foreign key (work_week) references Calendar.work_week,
 	constraint FK__calendar__work_day_type foreign key (work_day_type) references Calendar.work_day_type
)