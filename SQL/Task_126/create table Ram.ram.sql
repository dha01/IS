-- Создание схемы "Ram"
create schema Ram

-- Создание таблицы "Ram"
create table Ram.ram
(
	id int identity (1,1) not null,
	name nvarchar(255) not null,
	ram_type int not null,
	manufacturer int not null,
	capacity int not null,
	voltage int not null,
	frequency int not null,
	throughput int not null,
	constraint PK__ram primary key (id),
	constraint FK__ram__ram_type foreign key (ram_type) references Ram.ram_type,
	constraint FK__ram__manufacturer foreign key (manufacturer) references Ram.manufacturer
)







