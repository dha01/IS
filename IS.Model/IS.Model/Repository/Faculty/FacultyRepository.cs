using System.Collections.Generic;
using IS.Model.Helper;
using IS.Model.Item.Faculty;

namespace IS.Model.Repository.Faculty
{
	/// <summary>
	/// Интерфейс репозитория факультетов.
	/// </summary>
	public class FacultyRepository : IFacultyRepository
	{
		/// <summary>
		/// Получает факультет по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Факультет.</returns>
		public FacultyItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<FacultyItem>(@"
select
	d.faculty Id,
	d.full_name Fullname,
	d.short_name Shortname
from Faculty.faculty d
where d.faculty = @id", new {id});
			}
		}
		/// <summary>
		/// Обновляет данные по факультету.
		/// </summary>
		/// <param name="faculty">Факультет.</param>
		public void Update(FacultyItem faculty)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
update Faculty.faculty
set
	full_name = @Fullname,
	short_name = @Shortname
where faculty = @Id", faculty);
			}
		}
		/// <summary>
		/// Создает новый факультет.
		/// </summary>
		/// <param name="faculty">Факультет.</param>
		/// <returns>Идентификатор созданного факультета.</returns>
		public int Create(FacultyItem faculty)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into Faculty.faculty
(
	full_name,
	short_name
)
values
(
	@Fullname,
	@Shortname
)

select scope_identity()", faculty);
			}
		}
		/// <summary>
		/// Удаляет факультет.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			using (SqlHelper sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
delete from Faculty.faculty
where faculty = @id", new { id });
			}
		}

		/// <summary>
		/// Получает список всех факультетов.
		/// </summary>
		/// <returns>Список факультетов.</returns>
		public List<FacultyItem> GetList()
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<FacultyItem>(@"
select
	d.faculty Id,
	d.full_name Fullname,
	d.short_name Shortname
from Faculty.faculty d
	");
			}
		}
	}
}
