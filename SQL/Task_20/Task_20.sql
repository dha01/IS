-- Создание схемы "Specialty.specialty_detail"
create schema Specialty

-- Создание таблицы "Specialty.specialty_detail"
create table Specialty.specialty
(
	Specialty_detail int identity (1,1) not null,
	specialty int not null,
	col_semestr int not null,
	srock_obuch int not null,
	qualification int not null,
	form_of_study varchar(255) not null,
	pay_space int not null,
	lowcost_space int not null,

	constraint PK__Specialty_detail primary key (Specialty_detail),
	constraint FK__specialty__cathedra foreign key (specialty) references specialty.specialty,
	constraint FK__specialty__cathedra foreign key (qualification) references qualification.qualification,
	constraint FK__specialty__cathedra foreign key (form_of_study) references form_of_study.form_of_study,
)
