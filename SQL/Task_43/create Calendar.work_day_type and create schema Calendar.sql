-- �������� ����� Calendar
create schema Calendar

-- �������� ������� "work_day_type"
create table Calendar.work_day_type(
	work_day_type int identity not null,
	code varchar(50) not null,
	memo varchar(max) not null,
	constraint PK__work_day_type primary key (work_day_type)
)

-- ���������� ������� � �������
insert into Calendar.work_day_type(code,memo)
    values
			('Work', '������� ����'),
			('Abbreviated', '����������� ����'),
			('Holiday', '����������� ����'),
			('Weekend', '�������� ����')