using System.Collections.Generic;
using IS.Model.Helper;
using IS.Model.Item.Team;

namespace IS.Model.Repository.Team
{
	/// <summary>
	/// Репозиторий учебных планов по группе.
	/// </summary>
	public class PlanRepository : IPlanRepository
	{
		/// <summary>
		/// Получает учебный план по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Учебный план.</returns>
		public PlanItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<PlanItem>(@"
select
	t.team_plan Id,
	t.name Name,
	t.team Team,
	t.semester Semester,
	t.lesson_type LessonType,
	t.discipline Discipline,
	t.auditory Auditory
from TrainingPlan.team_plan t
where t.team_plan = @id", new { id });
			}
		}

		/// <summary>
		/// Обновляет данные по учебному плану.
		/// </summary>
		/// <param name="plan">Учебный план.</param>
		public void Update(PlanItem plan)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
update TrainingPlan.team_plan
set
	name = @Name,
	team = @Team,
	semester = @Semester,
	lesson_type = @LessonType,
	discipline = @Discipline,
	auditory = @Auditory
where team_plan = @Id", plan);
			}
		}

		/// <summary>
		/// Создает новый учебный план.
		/// </summary>
		/// <param name="plan">Учебный план.</param>
		/// <returns>Идентификатор созданного учебного плана.</returns>
		public int Create(PlanItem plan)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into TrainingPlan.team_plan
(
	name,
	team,
	semester,
	lesson_type,
	discipline,
	auditory
)
values
(
	@Name,
	@Team,
	@Semester,
	@LessonType,
	@Discipline,
	@Auditory
)
select scope_identity()", plan);
			}
		}

		/// <summary>
		/// Удаляет учебный план.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			using (SqlHelper sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
delete from TrainingPlan.team_plan
where team_plan = @id", new { id });
			}
		}

		/// <summary>
		/// Получает список всех учебных планов.
		/// </summary>
		/// <returns>Список учебных планов.</returns>
		public List<PlanItem> GetList()
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<PlanItem>(@"
select
	t.team_plan Id,
	t.name Name,
	t.team Team,
	t.semester Semester,
	t.lesson_type LessonType,
	t.discipline Discipline,
	t.auditory Auditory
from TrainingPlan.team_plan t");
			}
		}
	}
}