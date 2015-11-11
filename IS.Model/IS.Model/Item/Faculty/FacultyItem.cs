using System;

namespace IS.Model.Item.Faculty
{
	/// <summary>
	/// Класс для хранения данных по факультетам.
	/// </summary>
	public class FacultyItem
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Полное название.
		/// </summary>
		public string Fullname { get; set; }

		/// <summary>
		/// Сокращенное название.
		/// </summary>
		public string Shortname { get; set; }
	}
}

