using System;

namespace IS.Model.Item.Housing
{
	/// <summary>
	/// Класс для хранения данных по факультетам.
	/// </summary>
	public class HousingItem
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Полное название.
		/// </summary>
		public string FullName { get; set; }

		/// <summary>
		/// Сокращенное название.
		/// </summary>
		public string ShortName { get; set; }
	}
}

