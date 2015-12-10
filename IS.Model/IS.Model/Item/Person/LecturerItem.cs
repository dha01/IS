using System;

namespace IS.Model.Item.Person
{
	/// <summary>
	/// Класс для хранения данных людей.
	/// </summary>
	public class LecturerItem : PersonItem
	{
		/// <summary>
		/// Кафедра.
		/// </summary>
		public int CathedraId { get; set; }
	}
}
