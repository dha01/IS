create schema Team

create table Team.team
(
	team int identity,
	name varchar(50) not null,
	data date,
	specialty int,
	constraint PK__team primary key (team),
	constraint FK__team__specialty foreign key (specialty) references Specialty.specialty_detail
)

insert into Team.team
		(name,
		data)
	values
		(
		'ПЕ-22б',
		'2012-09-27'
		)

delete from Team.team
	where team=11
