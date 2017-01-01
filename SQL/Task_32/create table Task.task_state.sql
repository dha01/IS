-- �������� �������-����������� Task.task-state
create table Task.task_state (
		task_state int identity,
		name nvarchar(255) not null,
		code varchar(30) not null,
		memo varchar(max),
		constraint PK__task_state primary key (task_state),
);

-- ���������� ������ � ������� Task.task_state
insert into Task.task_state
		(name,
		code,
		memo)
values 
		('� �������� ����������', 'Progress', '������ ��������� � �������� ����������'),
		('���������', 'Complete', '������ �����������'),
		('������� ��������', 'Wait', '������ ������� ��������')
