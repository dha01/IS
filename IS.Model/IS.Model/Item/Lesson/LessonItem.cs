using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IS.Model.Item.Lesson
{
    /// <summary>
	/// Класс для хранения данных по занятиям.
	/// </summary>
    public class LessonItem
    {
        /// <summary>
		/// Идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Идентификатор дисциплины.
		/// </summary>
		public int Discipline { get; set; }

        /// <summary>
        /// Идентификатор типа занятия
        /// </summary>
        public LessonType Type { get; set; }

		/// <summary>
		/// Идентификатор рабочего дня.
		/// </summary>
		public int WorkDay { get; set; }

        /// <summary>
		/// Время начала занятия.
		/// </summary>
		public DateTime FromTime { get; set; }

        /// <summary>
		/// Время окончания занятия.
		/// </summary>
		public DateTime TrimeTime { get; set; }
    }

    /// <summary>
    /// Тип занятия.
    /// </summary>
    public enum LessonType
    {
        /// <summary>
        /// Лекция.
        /// </summary>
        Lecture,
        /// <summary>
        /// Практика.
        /// </summary>
        Practice,
        /// <summary>
        /// Лабараторная.
        /// </summary>
        Laboratory,
        /// <summary>
        /// Консультация.
        /// </summary>
        Consultation,
        /// <summary>
        /// Экзамен.
        /// </summary>
        Exam
    }
}
