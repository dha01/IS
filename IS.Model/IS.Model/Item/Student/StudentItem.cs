using System;
using IS.Model.Item.Person;

namespace IS.Model.Item.Student
{
    /// <summary>
    /// Класс для хранения данных о сущности студентов.
    /// </summary>
    public class StudentItem : PersonItem
    {
        /// <summary>
        /// Идентификатор группы.
        /// </summary>
        public int Team { get; set; }
    }
}