using System.Collections.Generic;
using System.Data;
using IS.Model.Helper;
using IS.Model.Item.Access;

namespace IS.Model.Repository.Access
{
	/// <summary>
	/// Класс репозитория ролей.
	/// </summary>
	public class RoleRepository : IRoleRepository
	{
		/// <summary>
		/// Получает роль по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Роль.</returns>
		public RoleItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<RoleItem>(@"
select
	r.role Id,
	r.code Code,
	r.mem Mem
from Access.role r
where r.role = @Id", new { id });
			}
		}

		/// <summary>
		/// Обновляет данные по роли.
		/// </summary>
		/// <param name="role">Роль.</param>
		public void Update(RoleItem role)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
update Access.role
set
	code = @Code,
	mem = @Mem
where role = @Id", role);
			}
		}

		/// <summary>
		/// Создает новую роль.
		/// </summary>
		/// <param name="role">Роль.</param>
		/// <returns>Идентификатор созданной роли.</returns>
		public int Create(RoleItem role)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into Access.role
(
	code,
	mem
)
values
(
	@Code,
	@Mem
)

select scope_identity()", role);
			}
		}

		/// <summary>
		/// Удаляет роль.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			using (SqlHelper sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
delete from Access.role
where role = @Id", new { id });
			}
		}

		/// <summary>
		/// Получает список всех ролей.
		/// </summary>
		/// <returns>Список ролей.</returns>
		public List<RoleItem> GetList()
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<RoleItem>(@"
select
	r.role Id,
	r.code Code,
	r.mem Mem
from Access.role r");
			}
		}

		/// <summary>
		/// Получает список ролей по пользователю.
		/// </summary>
		/// <param name="user">Пользователь.</param>
		/// <returns>Список ролей.</returns>
		public List<RoleItem> GetListByUser(UserItem user)
		{
			List<RoleItem> listRole = new List<RoleItem>();
			
			using (var sqlh = new SqlHelper())
			{
				listRole = sqlh.ExecMappingList<RoleItem>(@"
select
	r.role Id,
	r.code Code,
	r.mem Mem
from Access.[user] u
	join Access.user2role u2r on u2r.[user] = u.[user]
	join Access.role r on r.role = u2r.role
where u.[user] = @Id", user);
			}

			listRole.ForEach(delegate(RoleItem role)
			{
				listRole.AddRange(GetListByOwnerRole(role));
			});

			return listRole;
		}

		/// <summary>
		/// Получает роль по коду.
		/// </summary>
		/// <param name="code">Код.</param>
		/// <returns>Список ролей.</returns>
		public RoleItem GetByCode(string code)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<RoleItem>(@"
select
	r.role Id,
	r.code Code,
	r.mem Mem
from Access.role r
where r.code = @Code", new { code });
			}
		}

		/// <summary>
		/// Получает список подролей по роли.
		/// </summary>
		/// <param name="role">Роль.</param>
		/// <returns>Список ролей.</returns>
		public List<RoleItem> GetListByOwnerRole(RoleItem role)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<RoleItem>(@"
select
	r.role Id,
	r.code Code,
	r.mem Mem
from Access.role r
	join Access.role_member m on m.role_offer = r.role
where m.role_owner = @Id", role);
			}
		}

		/// <summary>
		/// Добавляет подроль.
		/// </summary>
		/// <param name="owner_id">Идентификатор роли.</param>
		/// <param name="offer_id">Идентификатор подроли.</param>
		public void CreateMemberRole(int owner_id, int offer_id)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
insert into Access.role_member
(
	role_owner,
	role_offer
)
values
(
	@owner_id,
	@offer_id
)", new {owner_id, offer_id});
			}
		}
	}
}