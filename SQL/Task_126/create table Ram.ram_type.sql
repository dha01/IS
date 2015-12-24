-- Создание схемы "Ram"
create schema Ram

-- Создание таблицы "Ram.ram_type"
create table Ram.ram_type
(
	ram_type int identity (1,1) not null,
	code varchar(50) not null,
	memo varchar(max) not null,
	constraint PK__ram_type primary key (ram_type)
)