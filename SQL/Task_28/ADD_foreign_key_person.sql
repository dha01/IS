alter table Access.user
add
	person int identity(1,1)
	constraint FK_Person foreign key (person)
	references Person.person (person)