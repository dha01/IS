using System;

namespace IS.Model.Item.Team
{
	/// <summary>
	/// Класс для хранения данных о сущности групп.
	/// </summary>
	public class TeamItem
    {
		/// <summary>
		/// Идентификатор группы.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название группы.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Дата создания группы.
		/// </summary>
		public DateTime? Create_date { get; set; }

		/// <summary>
		/// Идентификатор образовательной программы.
		/// </summary>
		public int Specialty_detail { get; set; }
	}
}
