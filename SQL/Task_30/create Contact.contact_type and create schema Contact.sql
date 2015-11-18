-- �������� ����� "Contact"
create schema Contact

-- �������� ������� "contact_type"
create table Contact.contact_type
(
	contact_type int identity not null,
	code varchar(50) not null,
	memo varchar(max) not null,
	constraint PK__contact_type primary key (contact_type)
)
-- ���������� ������� � �������.
insert into Contact.contact_type(code,memo)
	values
			('MobilePhone', '��������� �������'),
			('CityPhone', '��������� �������'),
			('Skype', '�����'),
			('Facebook', '�������'),
			('VK', '���������'),
			('Steam', '����'),
			('Twitter', '�������'),
			('Instagram', '���������')