using System;

namespace IS.Model.Item.Ram
{
	/// <summary>
	/// Класс для хранения данных о сущности оперативной памяти.
	/// </summary>
	public class RamItem
	{
		/// <summary>
		/// Идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
        /// Название модели.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
        /// Тип модели.
		/// </summary>
		public RamType RamType { get; set; }

		/// <summary>
        /// Производитель.
		/// </summary>
		public Manufacturer Manufacturer { get; set; }

		/// <summary>
        /// Объем пямяти в мб.
		/// </summary>
		public int Capacity { get; set; }

        /// <summary>
        /// Напряжение питания.
        /// </summary>
        public int Voltage { get; set; }

        /// <summary>
        /// Тактовая частота в МГц.
        /// </summary>
        public int Frequency { get; set; }

        /// <summary>
        /// Пропускная способность в Мб/с.
        /// </summary>
        public int Throughput { get; set; }
	}

    /// <summary>
    /// Тип модели.
    /// </summary>
    public enum RamType
    {
        /// <summary>
        /// Модель DIMM.
        /// </summary>
        Dimm,

        /// <summary>
        /// Модель DDR.
        /// </summary>
        Ddr,

        /// <summary>
        /// Модель DDR2.
        /// </summary>
        Ddr2,

        /// <summary>
        /// Модель DDR3.
        /// </summary>
        Ddr3
    }

    /// <summary>
    /// Производитель.
    /// </summary>
    public enum Manufacturer
    {
        /// <summary>
        /// Kingston.
        /// </summary>
        Kingston,

        /// <summary>
        /// Corsair.
        /// </summary>
        Corsair,

        /// <summary>
        /// Kingmax.
        /// </summary>
        Kingmax
    }
}
