using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Model.Item.Contact;

namespace IS.Model.Item.Team
{
	/// <summary>
	/// Расширенный класс для хранения контактов групп.
	/// </summary>
	public class TeamInfoItem : TeamItem
	{
		/// <summary>
		/// Список контактов.
		/// </summary>
		public List<ContactItem> ContactsList { get; set; }
	}
}
