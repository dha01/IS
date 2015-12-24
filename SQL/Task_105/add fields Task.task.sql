alter table Task.task 
	add 
		person_performer int null,
		person_author int null,
		constraint FK__task_person_performer foreign key(person_performer) references Person.person,
		constraint FK__task_person_author foreign key(person_author) references Person.person


