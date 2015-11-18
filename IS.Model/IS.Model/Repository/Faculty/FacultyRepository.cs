﻿using System.Collections.Generic;
using IS.Model.Helper;
using IS.Model.Item.Housing;

namespace IS.Model.Repository.Housing
{
	/// <summary>
	/// Репозиторий факультетов.
	/// </summary>
	public class HousingRepository : IHousingRepository
	{
		/// <summary>
		/// Получает факультет по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Факультет.</returns>
		public HousingItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<HousingItem>(@"
select
	d.faculty Id,
	d.full_name FullName,
	d.short_name ShortName
from Faculty.faculty d
where d.faculty = @id", new {id});
			}
		}

		/// <summary>
		/// Обновляет данные по факультету.
		/// </summary>
		/// <param name="faculty">Факультет.</param>
		public void Update(HousingItem faculty)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
update Faculty.faculty
set
	full_name = @FullName,
	short_name = @ShortName
where faculty = @Id", faculty);
			}
		}

		/// <summary>
		/// Создает новый факультет.
		/// </summary>
		/// <param name="faculty">Факультет.</param>
		/// <returns>Идентификатор созданного факультета.</returns>
		public int Create(HousingItem faculty)
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
	@FullName,
	@ShortName
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
		public List<HousingItem> GetList()
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<HousingItem>(@"
select
	d.faculty Id,
	d.full_name FullName,
	d.short_name ShortName
from Faculty.faculty d");
			}
		}
	}
}
