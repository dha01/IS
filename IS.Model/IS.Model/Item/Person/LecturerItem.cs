using System;

namespace IS.Model.Item.Person
{
	/// <summary>
	/// Класс для хранения данных преподавателей.
	/// </summary>
	public class LecturerItem : PersonItem
	{
		/// <summary>
		/// Идентификатор кафедры.
		/// </summary>
		public int? CathedraId { get; set; }
	}
}
