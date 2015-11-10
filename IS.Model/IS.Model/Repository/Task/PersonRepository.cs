using System.Collections.Generic;
using IS.Model.Helper;
using IS.Model.Item.Task;

namespace IS.Model.Repository.Task
{
    /// <summary>
    /// Интерфейс репозитория людей.
    /// </summary>
    public class PersonRepository : ITaskRepository
    {
        /// <summary>
        /// Получает человека по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Человека.</returns>
        public TaskItem Get(int id)
        {
            using (var sqlh = new SqlHelper())
            {
                return sqlh.ExecMapping<TaskItem>(@"
select
	p.person Id,
	p.last_name LastName,
	p.first_name Name,
	p.father_name Feather,
    p.birthday Birthday
from Person.Person p
where p.person = @id", new { id });
            }
        }

        /// <summary>
        /// Обновляет данные у человека.
        /// </summary>
        /// <param name="task">Человека.</param>
        public void Update(TaskItem person)
        {
            using (var sqlh = new SqlHelper())
            {
                sqlh.ExecNoQuery(@"
update Person.person
set
	last_name = @LastName,
	first_name = @Name,
	father_name = @Feather,
    birthday = @Birthday
where task = @Id", person);
            }
        }

        /// <summary>
        /// Создает нового человека.
        /// </summary>
        /// <param name="task">Задача.</param>
        /// <returns>Идентификатор созданного человека.</returns>
        public int Create(TaskItem person)
        {
            using (var sqlh = new SqlHelper())
            {
                return sqlh.ExecScalar<int>(@"
insert into Person.person
(
	last_name,
	first_name,
	father_name,
    birthday
)
values
(
	@LastName,
    @Name,
    @Feather,
    @Birthday
)

select scope_identity()", person);
            }
        }

        /// <summary>
        /// Удаляет человека.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        public void Delete(int id)
        {
            using (SqlHelper sqlh = new SqlHelper())
            {
                sqlh.ExecNoQuery(@"
delete from Person.person
where person = @id", new { id });
            }
        }

        /// <summary>
        /// Получает список всех людей.
        /// </summary>
        /// <returns>Список людей.</returns>
        public List<TaskItem> GetList()
        {
            using (var sqlh = new SqlHelper())
            {
                return sqlh.ExecMappingList<TaskItem>(@"
select
	p.person Id,
	p.last_name LastName,
	p.first_name Name,
	p.father_name Feather,
    p.birthday Birthday
from Person.Person p
	");
            }
        }
    }
}
