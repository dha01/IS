using System;

namespace IS.Model.Item.Team
{
	/// <summary>
	/// Класс для хранения данных по учебному плану для группы.
	/// </summary>
	public class PlanItem
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Идентификатор группы.
		/// </summary>
		public int Team { get; set; }

		/// <summary>
		/// Идентификатор семестра.
		/// </summary>
		public int Semester { get; set; }

		/// <summary>
		/// Идентификатор типа занятия.
		/// </summary>
		public int LessonType { get; set; }

		/// <summary>
		/// Идентификатор дисциплины.
		/// </summary>
		public int Discipline { get; set; }

		/// <summary>
		/// Идентификатор аудитории.
		/// </summary>
		public int Auditory { get; set; }
	}
}