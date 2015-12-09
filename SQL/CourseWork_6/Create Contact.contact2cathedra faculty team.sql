-- Создание таблицы для связи кафедр с контактами
create table Contact.contact2cathedra
(
	contact2cathedra int identity(1,1),
	contact int,
	cathedra int,
	constraint PK__contact2cathedra primary key (contact2cathedra),
	constraint FK__contact2cathedra__contact foreign key (contact) references Contact.contact,
	constraint FK__contact2cathedra__cathedra foreign key (cathedra) references Cathedra.cathedra
)

-- Создание таблицы для связи факультетов с контактами
create table Contact.contact2faculty
(
	contact2faculty int identity(1,1),
	contact int,
	faculty int,
	constraint PK__contact2faculty primary key (contact2faculty),
	constraint FK__contact2faculty__contact foreign key (contact) references Contact.contact,
	constraint FK__contact2faculty__person foreign key (faculty) references Faculty.faculty
)

-- Создание таблицы для связи групп с контактами
create table Contact.contact2team
(
	contact2team int identity(1,1),
	contact int,
	team int,
	constraint PK__contact2team primary key (contact2team),
	constraint FK__contact2team__contact foreign key (contact) references Contact.contact,
	constraint FK__contact2team__person foreign key (team) references Team.team
)