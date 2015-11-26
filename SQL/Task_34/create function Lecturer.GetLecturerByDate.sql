-- Создание табличной функции "Lecturer.GetLecturerByDate"
/*
create function Person.GetLecturerByDate
( @date datetime )
returns table
as
return 
select
	l.person,
	l.cathedra
from Person.lecturer l
where l.event_date <= @date
group by l.person, l.cathedra
having sum(l.act) = 1
*/

select
	p.person Id,
	p.last_name LastName,
	p.first_name FirstName,
	p.father_name FatherName,
	p.birthday Birthday
from Person.Person p
join Person.GetLecturerByDate(GETDATE()) on p.person = Person.GetLecturerByDate.person