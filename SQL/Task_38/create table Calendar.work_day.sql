create schema Calendar

create table Calendar.work_day
(
	data Date not null,
	work_day_type int not null,
	work_week int not null
	constraint PK__calendar primary key (data),
	constraint FK__calendar__work_week foreign key (work_week) references Calendar.work_week,
	constraint FK__calendar__work_day_type foreign key (work_day_type) references Calendar.work_day_type
)

