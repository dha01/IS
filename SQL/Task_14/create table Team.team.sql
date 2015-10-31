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
<<<<<<< feature/Task_14_Pozdeeva
		'ПЕ-21б',
		'1999-06-12'
		)
=======
		'ПЕ-22б',
		'2012-09-27'
		)

>>>>>>> local
