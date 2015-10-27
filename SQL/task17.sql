create schema Faculty

create table Faculty.faculty
(
	faculty int identity(1,1),
	full_Name varchar(255),
	short_Name varchar(30),
	primary key (faculty)
)

/*Добавление записи*/
insert into Faculty.faculty
           (full_Name
           ,short_Name)
     values
           (
			'мама мыла раму',
			'рарара'
		   )
delete from Faculty.faculty
	where faculty=1






