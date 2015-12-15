using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Model.Item.Task;

namespace IS.Model.Item.Calendar
{
    /// <summary>
    /// Класс для хранения данных о семестре.
    /// </summary>
    public class WorkDayItem
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Идентификатор дня.
        /// </summary>
        public WorkDayPrefix WorkDateType { get; set; }
        
        /// <summary>
        /// Идентификатор недели.
        /// </summary>
        public int WorkWeek { get; set; }
        
    }
    /// <summary>
    /// Префикс задачи.
    /// </summary>
    public enum WorkDayPrefix
    {
        /// <summary>
        /// Рабочий день.
        /// </summary>
        Work,

        /// <summary>
        /// Сокращенный день.
        /// </summary>
        Abbreviated,

        /// <summary>
        /// Праздничный день.
        /// </summary>
        Holiday,

        /// <summary>
        /// Выходной день.
        /// </summary>
        Weekend

    }
}
