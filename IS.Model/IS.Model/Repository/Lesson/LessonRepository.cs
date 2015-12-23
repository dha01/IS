using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Model.Helper;
using IS.Model.Item.Lesson;

namespace IS.Model.Repository.Lesson
{
    /// <summary>
    /// Интерфейс репозитория занятий.
    /// </summary>
    public class LessonRepository : ILessonRepository
    {
        /// <summary>
        /// Получает занятие по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Занятие.</returns>
        public LessonItem Get(int id)
        {
            using (var sqlh = new SqlHelper())
            {
                return sqlh.ExecMapping<LessonItem>(@"
select
    t.lesson Id,
    t.from_time FromTime,
    t.trim_time TrimTime,
    t.discipline Discipline,
    l.lesson_type LessonType,
	l.code Type
    c.work_day WorkDay
from
    TrainingPlan.lesson t
    join TrainingPlan.lesson_type l on l.lesson_type=t.lesson_type
    join Calendar.work_day c on c.work_day=t.work_day
where 
    t.lesson = @id", new {id});

            }
        }

        /// <summary>
        /// Обновляет данные по занятию.
        /// </summary>
        /// <param name="lesson">Занятие.</param>
        public void Update(LessonItem lesson)
        {
            using (var sqlh = new SqlHelper())
            {
                sqlh.ExecNoQuery(@"
update TrainingPlan.lesson
set
	from_time = @FromTime,
	trim_time = @TrimTime,
	discipline = @Discipline,
	lesson_type = (select top 1 l.lesson_type from TrainingPlan.lesson_type l where l.code = @Type),
    work_day = @WorkDay,
where lesson = @Id", lesson);
            }
        }

        /// <summary>
        /// Создает новое занятие.
        /// </summary>
        /// <param name="lesson">Занятие.</param>
        /// <returns>Идентификатор созданного занатия.</returns>
        public int Create(LessonItem lesson)
        {
            using (var sqlh = new SqlHelper())
            {
                return sqlh.ExecScalar<int>(@"
insert into Lesson.lesson
(
	from_time,
	trim_time,
	discipline,
	lesson_type,
	work_day
)
values
(
	@FromTime,
	@TrimTime,
	@Discipline,
	(select top 1 l.lesson_type from TrainingPlan.lesson_type l where l.code = @Type),
	@WorkDay
)

select scope_identity()", lesson);
            }
        }

        /// <summary>
        /// Удаляет занятие.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        public void Delete(int id)
        {
            using (SqlHelper sqlh = new SqlHelper())
            {
                sqlh.ExecNoQuery(@"
delete from Lesson.lesson
where lesson = @id", new { id });
            }
        }

        /// <summary>
        /// Получает список всех занятий.
        /// </summary>
        /// <returns>Список занятий.</returns>
        public List<LessonItem> GetList()
        {
            using (var sqlh = new SqlHelper())
            {
                return sqlh.ExecMappingList<LessonItem>(@"
select
    t.lesson Id,
    t.from_time FromTime,
    t.trim_time TrimTime,
    t.discipline Discipline,
    l.lesson_type LessonType,
	l.code Type
    c.work_day WorkDay
from
    TrainingPlan.lesson t
    join TrainingPlan.lesson_type l on l.lesson_type=t.lesson_type
    join Calendar.work_day c on c.work_day=t.work_day");
            }
        }
    }
}
