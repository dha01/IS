using System;

namespace IS.Model.Item.Task
{
    /// <summary>
    /// Класс для хранения данных людей.
    /// </summary>
    public class PersonItem
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string Father { get; set; }

        /// <summary>
        /// День рождения.
        /// </summary>
        public DateTime Birthday { get; set; }

    }


}
