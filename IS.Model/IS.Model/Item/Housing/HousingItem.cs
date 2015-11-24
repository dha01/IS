using System;

namespace IS.Model.Item.Housing
{
	/// <summary>
	/// Класс для хранения данных по корпусам.
	/// </summary>
	public class HousingItem
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int Id { get; set; }

<<<<<<< HEAD
		/// <summary>
		/// Номер корпуса.
		/// </summary>
		public int Number { get; set; }

		/// <summary>
		/// Имя корпуса.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Этаж.
		/// </summary>
		public int Level { get; set; }
		/// <summary>
		/// Краткое описание
		/// </summary>
		public string Memo { get; set; }
	}
=======
        /// <summary>
        /// Номер корпуса.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Имя корпуса.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Этаж.
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// Краткое описание.
        /// </summary>
        public string Memo { get; set; }
    }
>>>>>>> 965f4bff1a576ec3457648f659e6e6fe3e64e2b6
}

