-- �������� ����� "Auditory"
create schema Auditory

-- �������� ������� "Auditory.housing"
create table Auditory.housing
(
	housing int identity,
	number int not null,
	name nvarchar(30) not null,
	level int not null,
	memo nvarchar(max) not null
)


