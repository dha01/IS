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

        /// <summary>
        /// Полное название.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Сокращенное название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Сокращенное название.
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// Сокращенное название.
        /// </summary>
        public string Memo { get; set; }
    }
}

