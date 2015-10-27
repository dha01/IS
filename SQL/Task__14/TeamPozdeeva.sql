create schema Team

create table Team.team
(
	team int identity,
	name varchar(50) not null,
	data datetime,
	programma int,
	constraint PK__team primary key (team),
	constraint FK__team__programma foreign key (programma) references Team.team
)

insert into Team.team
		(name,
		data)
	values
		(
		'ое-22А',
		'10.10.2011'
		)
	 