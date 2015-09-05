using System;
using System.Collections.Generic;
using System.Data;
using IS.Helper;
using IS.Model.Item.Access;

namespace IS.Model.Repository.Access
{
	public class UserRepository : IUserRepository
	{
		public UserItem Get(int id)
		{
			using (SqlHelper sqlh = new SqlHelper(@"
select
	u.[user] Id,
	u.login Login,
	u.password Password
from Access.[user] u
where u.[user] = @id"))
			{
				sqlh.AddWithValue("@id", id);
				var dt = sqlh.ExecTable();
				if (dt.Rows.Count == 0)
				{
					return null;
				}
				return new UserItem()
				{
					Id = (int)dt.Rows[0]["Id"],
					Login = (string)dt.Rows[0]["Login"],
					Password = (string)dt.Rows[0]["Password"]
				};
			}
		}

		public void Update(UserItem user)
		{
			using (SqlHelper sqlh = new SqlHelper(@"
update Access.[user]
set
	login = @Login,
	password = @Password
where [user] = @Id"))
			{
				sqlh.AddWithValue("@Id", user.Id);
				sqlh.AddWithValue("@Login", user.Login);
				sqlh.AddWithValue("@Password", user.Password);
				sqlh.ExecNoQuery();
			}
		}

		public int Create(UserItem user)
		{
			using (SqlHelper sqlh = new SqlHelper(@"
insert into Access.[user] (login, password)
values (@Login, @Password)

select SCOPE_IDENTITY()"))
			{
				sqlh.AddWithValue("@Login", user.Login);
				sqlh.AddWithValue("@Password", user.Password);
				return Convert.ToInt32(sqlh.ExecScalar());
			}
		}

		public void Delete(int id)
		{
			using (SqlHelper sqlh = new SqlHelper(@"
delete from Access.user
where [user] = @Id"))
			{
				sqlh.ExecNoQuery();
			}
		}

		public UserItem GetUserByLogin(string login)
		{
			using (SqlHelper sqlh = new SqlHelper(@"
select
	u.[user] Id,
	u.login Login,
	u.password Password
from Access.[user] u
where u.login = @login"))
			{
				sqlh.AddWithValue("@login", login);
				var dt = sqlh.ExecTable();
				if (dt.Rows.Count == 0)
				{
					return null;
				}
				return new UserItem()
				{
					Id = (int)dt.Rows[0]["Id"],
					Login = (string)dt.Rows[0]["Login"],
					Password = (string)dt.Rows[0]["Password"]
				};
			}
		}

		public List<UserItem> GetList()
		{
			using (SqlHelper sqlh = new SqlHelper(@"
select
	u.[user] Id,
	u.login Login,
	u.password Password
from Access.[user] u"))
			{
				var dt = sqlh.ExecTable();

				var list = new List<UserItem>();

				foreach (DataRow row in dt.Rows)
				{
					list.Add(new UserItem()
					{
						Id = (int)row["Id"],
						Login = (string)row["Login"],
						Password = (string)row["Password"]
					});
				}
				return list;
			}
		}
	}
}