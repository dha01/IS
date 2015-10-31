create schema Team

create table Team.team
(
	team int identity,
	name varchar(50) not null,
	create_date date,
	specialty_detail int,
	constraint PK__team primary key (team),
	constraint FK__team__specialty_detail foreign key (specialty_detail) references Specialty.specialty_detail
)

insert into Team.team
		(name,
		create_date)
	values
		(
		'ПЕ-22б',
		'2012-09-27'
		)
