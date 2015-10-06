using System.Collections.Generic;
using System.Data;
using IS.Model.Helper;
using IS.Model.Item.Access;

namespace IS.Model.Repository.Access
{
	public class RoleRepository : IRoleRepository
	{
		public RoleItem Get(int id)
		{
			using (SqlHelper sqlh = new SqlHelper(@"
select
	r.role Id,
	r.code Code,
	r.mem Mem
from Access.role r
where r.role = @Id"))
			{
				sqlh.AddWithValue("@Id", id);
				var dt = sqlh.ExecTable();
				if (dt.Rows.Count == 0)
				{
					return null;
				}
				return new RoleItem()
				{
					Id = (int)dt.Rows[0]["Id"],
					Code = (string)dt.Rows[0]["Code"],
					Mem = (string)dt.Rows[0]["Mem"]
				};
			}
		}

		public void Update(RoleItem role)
		{
			using (SqlHelper sqlh = new SqlHelper(@"
update Access.role
set
	code = @Code,
	mem = @Mem
where role = @Id"))
			{
				sqlh.AddWithValue("@Id", role.Id);
				sqlh.AddWithValue("@Code", role.Code);
				sqlh.AddWithValue("@Mem", role.Mem);
				sqlh.ExecNoQuery();
			}
		}

		public int Create(RoleItem role)
		{
			using (SqlHelper sqlh = new SqlHelper(@"
insert into Access.role(code, mem)
values (@Code, @Mem)

select SCOPE_IDENTITY()
"))
			{
				sqlh.AddWithValue("@Code", role.Code);
				sqlh.AddWithValue("@Mem", role.Mem);
				return (int)sqlh.ExecScalar();
			}
		}

		public void Delete(int id)
		{
			using (SqlHelper sqlh = new SqlHelper(@"
delete from Access.role
where role = @Id"))
			{
				sqlh.ExecNoQuery();
			}
		}

		public List<RoleItem> GetList()
		{
			using (SqlHelper sqlh = new SqlHelper(@"
select
	r.role Id,
	r.code Code,
	r.mem Mem
from Access.role r"))
			{
				var dt = sqlh.ExecTable();
				
				var list = new List<RoleItem>();

				foreach (DataRow row in dt.Rows)
				{
					list.Add(new RoleItem()
					{
						Id = (int)row["Id"],
						Code = (string)row["Code"],
						Mem = (string)row["Mem"]
					});
				}
				return list;
			}
		}

		public List<RoleItem> GetListByUser(UserItem user)
		{
			using (SqlHelper sqlh = new SqlHelper(@"
select
	r.role Id,
	r.code Code,
	r.mem Mem
from Access.[user] u
	join Access.user2role u2r on u2r.[user] = u.[user]
	join Access.role r on r.role = u2r.role
where u.[user] = @Id"))
			{
				sqlh.AddWithValue("Id", user.Id);
				var dt = sqlh.ExecTable();

				var list = new List<RoleItem>();

				foreach (DataRow row in dt.Rows)
				{
					list.Add(new RoleItem()
					{
						Id = (int)row["Id"],
						Code = (string)row["Code"],
						Mem = (string)row["Mem"]
					});
				}
				return list;
			}
		}

		public RoleItem GetByCode(string code)
		{
			using (SqlHelper sqlh = new SqlHelper(@"
select
	r.role Id,
	r.code Code,
	r.mem Mem
from Access.role r
where r.code = @Code"))
			{
				sqlh.AddWithValue("@Code", code);
				var dt = sqlh.ExecTable();
				if (dt.Rows.Count == 0)
				{
					return null;
				}
				return new RoleItem()
				{
					Id = (int)dt.Rows[0]["Id"],
					Code = (string)dt.Rows[0]["Code"],
					Mem = (string)dt.Rows[0]["Mem"]
				};
			}
		}
	}
}