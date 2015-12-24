using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Model.Item.Ram;

namespace IS.Model.Repository.Ram
{
	/// <summary>
	/// Интерфейс репозитория для работы с оперативной памятью.
	/// </summary>
	public interface IRamRepository : IRepository<RamItem>
	{
		/// <summary>
		/// Получает оперативную память по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
        /// <returns>Оперативная память.</returns>
		RamItem Get(int id);

		/// <summary>
		/// Обновляет данные по оперативной памяти.
		/// </summary>
		/// <param name="ram">Оперативная память.</param>
		void Update(RamItem ram);

		/// <summary>
		/// Создает новую оперативную память.
		/// </summary>
        /// <param name="ram">Оперативная память.</param>
		/// <returns>Идентификатор созданной оперативной памяти.</returns>
		int Create(RamItem ram);

		/// <summary>
		/// Удаляет оперативную память.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		void Delete(int id);

		/// <summary>
		/// Получает список всех единиц оперативной памяти.
		/// </summary>
		/// <returns>Список единиц оперативной памяти.</returns>
		List<RamItem> GetList();
	}
}
