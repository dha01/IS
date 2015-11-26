﻿using System.Collections.Generic;
using IS.Model.Helper;
using IS.Model.Item.Team;

namespace IS.Model.Repository.Team
{
	/// <summary>
	/// Интерфейс репозитория группы.
	/// </summary>
	public class TeamRepository : ITeamRepository
	{
		/// <summary>
		/// Получает группу по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Группу.</returns>
		public TeamItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<TeamItem>(@"
select
	t.team Id,
	t.name Name,
	t.create_date CreateDate
from Team.team t
where t.team = @id", new { id });

			}
		}

		/// <summary>
		/// Обновляет данные по группе.
		/// </summary>
		/// <param name="team">Группу.</param>
		public void Update(TeamItem team)
		{
            using (var sqlh = new SqlHelper())
            {
                sqlh.ExecNoQuery(@"
update TeamItem.Team
set
	name = @Name
    create_date = @CreateDate
where Team = @Id", team);
            }
		}

		/// <summary>
		/// Создает новую группу.
		/// </summary>
		/// <param name="team">Группу.</param>
		/// <returns>Идентификатор созданной группу.</returns>
		public int Create(TeamItem team)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into Team.Team
(
	name,
	create_date
)
values
(
	@Name,
	@CreateDate
)

select scope_identity()", team);
			}
		}

		/// <summary>
		/// Удаляет группу.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
<<<<<<< HEAD
			using (SqlHelper sqlh = new SqlHelper())
			{
				sqlh.ExecMapping<TeamItem>(@"
delete from Team.team
where team = @id", new { id });
			}
=======
            
>>>>>>> remotes/origin/feature/task_71_Fokeev_add_TeamRepository.Update
		}

		/// <summary>
		/// Получает список всех группу.
		/// </summary>
		/// <returns>Список группу.</returns>
		public List<TeamItem> GetList()
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<TeamItem>(@"
select
	t.team Id,
	t.name Name,
	t.create_date CreateDate
from Team.team t
");
			}
		}
	}
}