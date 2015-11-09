using System;

namespace IS.Model.Item.Discipline
{
	/// <summary>
	/// Класс для хранения данных по дисциплинам.
	/// </summary>
	public class DisciplineItem
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Короткое название.
		/// </summary>
		public int Short_name { get; set; }

		/// <summary>
		/// Полное название.
		/// </summary>
		public string Full_name { get; set; }

		/// <summary>
		/// Описание.
		/// </summary>
		public string Mem { get; set; }
	}
}
