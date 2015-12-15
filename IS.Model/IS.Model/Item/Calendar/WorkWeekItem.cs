using System;

namespace IS.Model.Item.Calendar
{
	/// <summary>
	/// Класс для хранения данных о календаря.
	/// </summary>
	public class WorkWeekItem
	{
		/// <summary>
		/// Идентификатор рабочей недели.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Дата начала недели.
		/// </summary>
		public DateTime FromDate { get; set; }

		/// <summary>
		/// Дата конца недели.
		/// </summary>
		public DateTime TrimDate { get; set; }
		
		/// <summary>
		/// Идентификатор семестра.
		/// </summary>
		public int SemesterId { get; set; }
	}
}

