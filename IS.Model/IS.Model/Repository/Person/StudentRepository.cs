using System.Collections.Generic;
using IS.Model.Helper;
using IS.Model.Item.Person;

namespace IS.Model.Repository.Person
{
	/// <summary>
	/// Интерфейс репозитория задач.
	/// </summary>
	public class StudentRepository : IStudentRepository
	{
		/// <summary>
		/// Получает студента по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Задача.</returns>
		public StudentItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<StudentItem>(@"
	select* from Person.GetStudentByDate (getdate())");
			}
		}

		/// <summary>
		/// Обновляет данные по задаче.
		/// </summary>
		/// <param name="student">Задача.</param>
		public void Update(StudentItem student)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
update Person.student
set
	last_name = @LastName,
	first_name = @FirstName,
	father_name = @Father Name,
	birthday = @Birthday,
where student = @Id", student);
			}
		}

		/// <summary>
		/// Зачисление студента в группу.
		/// </summary>
		/// <param name="student">Студенты.</param>
		/// <returns>Идентификатор созданной задачи.</returns>
		public int Create(StudentItem student)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into Person.srudent
(
    event_date
    person
    team
	act
)
values
(
    getdate()
    @Id
    @TeamId
	1,
)

select scope_identity()", student);
			}
		}

		/// <summary>
		/// Исключение студента из группы.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{ }

		/// <summary>
		/// Исключение студента из группы.
		/// </summary>
		/// <param name="student">Студенты.</param>
		public void Delete(StudentItem student)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecScalar<int>(@"
insert into Person.srudent
(
    event_date
    person
    team
	act
)
values
(
    getdate()
    @Id
    @TeamId
	-1,
)

select scope_identity()", student);
			}
		}

		/// <summary>
		/// Получает список всех студентов.
		/// </summary>
		/// <returns>Список студентов.</returns>
		public List<StudentItem> GetList()
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<StudentItem>(@"
select
	st.student Id,
	st.last_name string,
	st.first_name string,
	st.father_name string,
	st.birthday datetime,
	st.team_id Id,
from Student.student st
where st.team = @id", new { });
			}
		}

		/// <summary>
		/// Получает список студентов по индетификатору группы.
		/// </summary>
		/// <param name="team_id">Список студентов.</param>
		public List<StudentItem> GetListByTeam(int team_id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<StudentItem>(@"
select
	st.student Id,
	st.last_name string,
	st.first_name string,
	st.father_name string,
	st.birthday datetime,
	st.team_id Id,
from Student.student st
where st.team = @TeamId", new { team_id });
			}
		}
	}
}
