using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using IS.Model.Item.Access;
using IS.Mvc.Models.Service;

namespace IS.Mvc.Models
{
	public class Access
	{
		private static AccessService _accessService;

		static Access()
		{
			_accessService = new AccessService();
		}
		
		public static bool UserInRole(UserItem user, RoleItem role)
		{
			return _accessService.UserInRole(user, role);
		}

		public static bool CheckRole(RoleItem role)
		{
			var user = _accessService.GetCurrentUser();
			if (user == null)
			{
				return false;
			}
			return UserInRole(user, role);
		}

		public static bool CheckRole(string role)
		{
			return true;
		}

		public static UserItem CurrentUser 
		{
			get { return _accessService.GetCurrentUser(); }
		}
	}
}