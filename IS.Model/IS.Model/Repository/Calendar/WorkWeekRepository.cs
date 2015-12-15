
using System.Collections.Generic;
using IS.Model.Helper;
using IS.Model.Item.Calendar;


namespace IS.Model.Repository.Calendar
{
	/// <summary>
	/// Интерфейс репозитория рабочих недель.
	/// </summary>
	public class WorkWeekRepository : IWorkWeekRepository
	{
		/// <summary>
		/// Получает рабочую неделью по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Задача.</returns>
		public WorkWeekItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<WorkWeekItem>(@"
select 
	w.work_week Id,
	w.from_date FromDate,
	w.trim_date TrimDate,
	w.semester SemesterId
from Calendar.work_week w");
			}
		}

		/// <summary>
		/// Обновляет данные по дням недели.
		/// </summary>
		/// <param name="work_week">Задача.</param>
		public void Update(WorkWeekItem work_week)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
update Calendar.work_week
set
	from_date = @FromDate,
	trim_date = @TrimDate,
	semester = @SemesterId
where  work_week = @Id", work_week);
			}
		}

		/// <summary>
		/// Создает новый день недели.
		/// </summary>
		/// <param name="work_week">День недели.</param>
		/// <returns>Идентификатор созданного дня недели</returns>
		public int Create(WorkWeekItem work_week)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into Calendar.work_week
(	
	from_date,
	trim_date,
	semester
)
values
(
	@FromDate,
	@TrimDate,
	@SemesterId
)

select scope_identity()", work_week);
			}
		}

		/// <summary>
		/// Удаляет день недели.
		/// </summary>
		/// <param name="id">день недели.</param>
		public void Delete(int id)
		{
			using (SqlHelper sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
delete from Calendar.work_week
where work_week = @id", new { id });
			}
		}

		/// <summary>
		/// Получает список всех задач.
		/// </summary>
		/// <returns>Список задач.</returns>
		public List<WorkWeekItem> GetList()
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<WorkWeekItem>(@"
select
	w.work_week Id,
	w.from_date FromDate,
	w.trim_date TrimDate,
	w.semester SemestrId
from Calendar.work_week w");
			}
		}
	}
}
