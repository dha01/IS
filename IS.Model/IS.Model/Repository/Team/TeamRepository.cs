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
	t.create_date CreateDate,
from Team.Team t
where t.Team = @id", new { id });

			}
		}

		/// <summary>
		/// Обновляет данные по группе.
		/// </summary>
		/// <param name="Team">Группу.</param>
		public void Update(TeamItem Team)
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
		/// <param name="Team">Группу.</param>
		/// <returns>Идентификатор созданной группу.</returns>
		public int Create(TeamItem Team)
		{
			return 0;
		}

		/// <summary>
		/// Удаляет группу.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{

		}

		/// <summary>
		/// Получает список всех группу.
		/// </summary>
		/// <returns>Список группу.</returns>
		public List<TeamItem> GetList()
		{
			return null;
		}
	}
}