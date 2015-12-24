-- Создание схемы "Ram"
create schema Ram

-- Создание таблицы "Ram.manufacturer"
create table Ram.manufacturer
(
	manufacturer int identity (1,1) not null,
	code varchar(50) not null,
	memo varchar(max) not null,
	constraint PK__manufacturer primary key (manufacturer)
)

insert into Ram.manufacturer(code, memo)
	values
		('Kingston', 'Kingston'),
		('Corsair', 'Corsair'),
		('Kingmax', 'Kingmax')