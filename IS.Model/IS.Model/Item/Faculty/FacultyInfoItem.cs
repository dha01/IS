using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Model.Item.Contact;

namespace IS.Model.Item.Faculty
{
	/// <summary>
	/// Расширенный класс для хранения контактов факультетов.
	/// </summary>
	public class FacultyInfoItem : FacultyItem
	{
		/// <summary>
		/// Список контактов.
		/// </summary>
		public List<ContactItem> ContactsList { get; set; }
	}
}
