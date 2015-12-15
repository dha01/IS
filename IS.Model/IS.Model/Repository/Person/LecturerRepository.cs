using System.Collections.Generic;
using IS.Model.Helper;
using IS.Model.Item.Person;

namespace IS.Model.Repository.Person
{
	public class LecturerRepository : ILecturerRepository
	{
		/// <summary>
		/// Получает преподавателя по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Преподаватель.</returns>
		public LecturerItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<LecturerItem>(@"
select
	p.person Id,
	p.last_name LastName,
	p.first_name FirstName,
	p.father_name FatherName,
	p.birthday Birthday,
	l.cathedra CathedraId
from Person.person p
	join Person.GetLecturerByDate(getdate()) l on p.person = l.person
where p.person = @id", new {id});
			}
		}

		/// <summary>
		/// Создает нового преподавателя.
		/// </summary>
		/// <param name="lecturer">Преподаватель.</param>
		/// <returns>Идентификатор созданного преподавателя.</returns>
		public int Create(LecturerItem lecturer) // Изменить
	{
		using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into Person.lecturer
(
	event_date,
	act,
	person,
	cathedra
)
values
(
	getdate(),
	1,
	@Id,
	@CathedraId
)
select @Id", lecturer);
			}
	}
		/// <summary>
		/// Удаляет преподавателя.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(LecturerItem lecturer)
		{
			using (SqlHelper sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
insert into Person.lecturer
(
	event_date,
	act,
	person,
	cathedra
)
values
(
	getdate(),
	-1,
	@Id,
	@CathedraId
)
select @Id", lecturer);
			}
		}

		/// <summary>
		/// Получает список всех преподавателей.
		/// </summary>
		/// <returns>Список преподавателей.</returns>
		public List<LecturerItem> GetList()
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<LecturerItem>(@"
select
	p.person Id,
	p.last_name LastName,
	p.first_name FirstName,
	p.father_name FatherName,
	p.birthday Birthday,
	l.cathedra CathedraId
from Person.person p
	join Person.GetLecturerByDate(getdate()) l on p.person = l.person");
			}
		}
	}
}
