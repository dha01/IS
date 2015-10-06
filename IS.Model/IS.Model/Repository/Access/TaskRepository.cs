using System.Collections.Generic;
using IS.Helper;
using IS.Model.Item.Task;

namespace IS.Model.Repository.Access
{
	/// <summary>
	/// Интерфейс репозитория задач.
	/// </summary>
	public class TaskRepository : ITaskRepository
	{
		/// <summary>
		/// Получает задачу по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Задача.</returns>
		public TaskItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<TaskItem>(@"
select
	t.task Id,
	t.number Number,
	t.task_prefix Prefix,
	t.header Header,
	t.mem Mem,
	t.created Created,
	t.deadline Deadline,
	t.priority Priority,
	t.executer Executer,
	t.author Author,
	t.is_perform IsPerform,
	t.is_open IdOpen
from Task.task t
where t.task = @id", new { id });
			}
		}

		/// <summary>
		/// Обновляет данные по задаче.
		/// </summary>
		/// <param name="task">Задача.</param>
		public void Update(TaskItem task)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
update Task.task
set
	number = @Number,
	task_prefix = @Prefix,
	header = @Header,
	mem = @Mem,
	deadline = @Deadline,
	priority = @Priority,
	executer = @Executer,
	author = @Author,
	is_perform = @IsPerform,
	is_open = @IdOpen
where task = @Id", task);
			}
		}

		/// <summary>
		/// Создает новую задачу.
		/// </summary>
		/// <param name="task">Задача.</param>
		/// <returns>Идентификатор созданной задачи.</returns>
		public int Create(TaskItem task)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into Task.task
(
	number,
	task_prefix,
	header,
	mem,
	deadline,
	priority,
	executer,
	author,
	is_perform,
	is_open
)
values
(
	@Number,
	@Prefix,
	@Header,
	@Mem,
	@Deadline,
	@Priority,
	@Executer,
	@Author,
	@IsPerform,
	@IdOpen
)

select scope_identity()", task);
			}
		}

		/// <summary>
		/// Удаляет задачу.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			using (SqlHelper sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
delete from Task.task
where task = @Id");
			}
		}

		/// <summary>
		/// Получает список всех задач.
		/// </summary>
		/// <returns>Список задач.</returns>
		public List<TaskItem> GetList()
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<TaskItem>(@"
select
	t.task Id,
	t.number Number,
	t.task_prefix Prefix,
	t.header Header,
	t.mem Mem,
	t.created Created,
	t.deadline Deadline,
	t.priority Priority,
	t.executer Executer,
	t.author Author,
	t.is_perform IsPerform,
	t.is_open IdOpen
from Task.task t");
			}
		}
	}
}
