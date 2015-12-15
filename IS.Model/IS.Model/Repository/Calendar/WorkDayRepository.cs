using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Model.Helper;
using IS.Model.Item.Calendar;

namespace IS.Model.Repository.Calendar
{
    /// <summary>
    /// Интерфейс репозитория рабочих дней.
    /// </summary>
    public class WorkDayRepository : IWorkDayRepository
    {
        /// <summary>
        /// Получает задачу по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Задача.</returns>
        public WorkDayItem Get(int id)
        {
            using (var sqlh = new SqlHelper())
            {
                return sqlh.ExecMapping<WorkDayItem>(@"
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
	t.difficult Difficult,
	t.pull_request_url PullRequestUrl
from Task.task t
	join Task.task_prefix p on p.task_prefix = t.task_prefix
where t.task = @id", new { id });
            }
        }

        /// <summary>
        /// Обновляет данные по задаче.
        /// </summary>
        /// <param name="task">Задача.</param>
        public void Update(WorkDayItem task)
        {
            using (var sqlh = new SqlHelper())
            {
                sqlh.ExecNoQuery(@"
update Task.task
set
	number = @Number,
	task_prefix = (select top 1 p.task_prefix from Task.task_prefix p where p.code = @Prefix),
	header = @Header,
	mem = @Mem,
	deadline = @Deadline,
	priority = @Priority,
	performer = @Performer,
	author = @Author,
	is_perform = @IsPerform,
	is_open = @IsOpen,
	difficult = @Difficult,
	pull_request_url = @PullRequestUrl
where task = @Id", task);
            }
        }

        /// <summary>
        /// Создает новую задачу.
        /// </summary>
        /// <param name="task">Задача.</param>
        /// <returns>Идентификатор созданной задачи.</returns>
        public int Create(WorkDayItem task)
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
	performer,
	author,
	difficult,
	pull_request_url
)
values
(
	@Number,
	(select top 1 p.task_prefix from Task.task_prefix p where p.code = @Prefix),
	@Header,
	@Mem,
	@Deadline,
	@Priority,
	@Performer,
	@Author,
	@Difficult,
	@PullRequestUrl
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
where task = @id", new { id });
            }
        }

        /// <summary>
        /// Получает список всех задач.
        /// </summary>
        /// <returns>Список задач.</returns>
        public List<WorkDayItem> GetList()
        {
            using (var sqlh = new SqlHelper())
            {
                return sqlh.ExecMappingList<WorkDayItem>(@"
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
	t.difficult Difficult,
	t.pull_request_url PullRequestUrl
from Task.task t
	join Task.task_prefix p on p.task_prefix = t.task_prefix");
            }
        }
    }
}
