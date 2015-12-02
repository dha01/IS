using System.Collections.Generic;
using IS.Model.Helper;
using IS.Model.Item.Person;

namespace IS.Model.Repository.Person
{
    class LecturerRepository : IPersonRepository
    {
        public PersonItem Get(int id)
        {
            using (var sqlh = new SqlHelper())
            {
                return sqlh.ExecMapping<PersonItem>(@"
select
	p.person Id,
	p.last_name LastName,
	p.first_name FirstName,
	p.father_name FatherName,
	p.birthday Birthday
from Person.person p
	join Person.GetLecturerByDate(getdate()) l on p.person = l.person");
            }
        }
    }
}
