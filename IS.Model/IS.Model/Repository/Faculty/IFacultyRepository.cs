using System.Collections.Generic;
using IS.Model.Item.Access;
using IS.Model.Item.Housing;

namespace IS.Model.Repository.Housing
{
	/// <summary>
	/// Интерфейс репозитория факультетов.
	/// </summary>
	public interface IHousingRepository : IRepository<HousingItem>
	{
		/// <summary>
		/// Получает факультет по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Факультет.</returns>
		HousingItem Get(int id);

		/// <summary>
		/// Обновляет данные по факультету.
		/// </summary>
		/// <param name="faculty">Факультет.</param>
		void Update(HousingItem faculty);

		/// <summary>
		/// Создает новый факультет.
		/// </summary>
		/// <param name="faculty">Факультет.</param>
		/// <returns>Идентификатор созданного факультета.</returns>
		int Create(HousingItem faculty);

		/// <summary>
		/// Удаляет задачу.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		void Delete(int id);

		/// <summary>
		/// Получает список всех факультетов.
		/// </summary>
		/// <returns>Список факультетов.</returns>
		List<HousingItem> GetList();
	}
}
