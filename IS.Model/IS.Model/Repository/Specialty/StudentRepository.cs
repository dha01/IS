using System.Collections.Generic;
using IS.Model.Helper;
using IS.Model.Item.Student;

namespace IS.Model.Repository.Student
{
	/// <summary>
	/// Интерфейс репозитория задач.
	/// </summary>
	public class StudentRepository : IStudentRepository
	{
		/// <summary>
		/// Получает задачу по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Задача.</returns>
		public StudentItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<StudentItem>(@"
select
	st.student Id,
	st.last_name string,
	st.first_name string,
	st.father_name string,
	st.birthday datetime,
	st.team_id Id,
from Student.student st
where st.student = @id", new { id });
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
		/// Создает новую задачу.
		/// </summary>
		/// <param name="student">Задача.</param>
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
    @EvenDate
    @Id
    @Team
	1,
)

select scope_identity()", student);
			}
		}

		/// <summary>
		/// Удаляет данные о студентах.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			using (SqlHelper sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
delete from Person.student
where task = @id", new { id });
			}
		}

		/// <summary>
		/// Получает список всех задач.
		/// </summary>
		/// <returns>Список задач.</returns>
		public List<StudentItem> GetList()
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<StudentItem>(@"
select
	t.task Id,
	t.number Number,
	p.code Prefix,
	t.header Header,
	t.mem Mem,
	t.created Created,
	t.deadline Deadline,
	t.priority Priority,
	t.performer Performer,
	t.author Author,
	t.is_perform IsPerform,
	t.is_open IsOpen,
	t.difficult Difficult
from Task.task t
	join Task.task_prefix p on p.task_prefix = t.task_prefix");
			}
		}
	}
}
