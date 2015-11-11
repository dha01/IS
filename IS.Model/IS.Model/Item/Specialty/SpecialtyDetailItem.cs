using System;

namespace IS.Model.Item.Specialty
{    /// <summary>
    /// Класс для хранения данных о сущности образовательной системы.
    /// </summary>
    public class SpecialtyDetailItem
    {
        /// <summary>
        /// Идентификатор образовательной программы.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Полное название специальности.
        /// </summary>
        public int SpecialtyDetail { get; set; }

        /// <summary>
        /// Текущая дата.
        /// </summary>
        public DateTime ActualDate { get; set; }

        /// <summary>
        /// Код специальности.
        /// </summary>
        public int Specialty { get; set; }

        /// <summary>
        /// Номер семестра.
        /// </summary>
        public int SemestrCount { get; set; }

        /// <summary>
        /// Период обучения.
        /// </summary>
        public int TrainingPeriod { get; set; }

        /// <summary>
        /// Количество платных мест.
        /// </summary>
        public int PaySpace { get; set; }

        /// <summary>
        /// Количество бюджетных мест.
        /// </summary>
        public int LowcostSpace { get; set; }

    }
    /// <summary>
    /// Квалификация.
    /// </summary>
    public enum Qualification
    {
        Bachelor,
        Master,
        Expert
    }

    /// <summary>
    /// Форма обучения.
    /// </summary>
    public enum FormStudy
    {
        FullTime,
        Distance
    }
}
