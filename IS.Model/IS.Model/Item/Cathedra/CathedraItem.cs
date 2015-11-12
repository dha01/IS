using System;

namespace IS.Model.Item.Cathedra
{
	/// <summary>
	/// Класс для хранения данных о кафедре.
	/// </summary>
	class CathedraItem
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Полное имя кафедры.
		/// </summary>
		public string FullName { get; set; }

		/// <summary>
		/// Сокращенное имя кафедры.
		/// </summary>
		public string ShortName { get; set; }
	}
}
