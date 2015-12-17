using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IS.Model.Item.Person
{
	public class PersonInfoItem : PersonItem
	{
		/// <summary>
		/// Группа.
		/// </summary>
		public int? TeamId { get; set; }

		/// <summary>
		/// Должность.
		/// </summary>
		public int? CathedraId { get; set; }
	}
}
