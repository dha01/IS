using System.Collections.Generic;
using IS.Model.Item.Calendar;

namespace IS.Model.Repository.Calendar
{
	/// <summary>
	/// Интерфейс репозитория задач.
	/// </summary>
	public interface IWorkWeekRepository : IRepository<WorkWeekItem>
	{
		/// <summary>
		/// Получает рабочую неделю по индификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Рабочая неделя.</returns>
		WorkWeekItem Get(int id);

		/// <summary>
		/// Обновляет данные по рабочей неделе.
		/// </summary>
		/// <param name="work_week">Рабочая неделя.</param>
		void Update(WorkWeekItem work_week);

		/// <summary>
		/// Создает новую рабочую неделю.
		/// </summary>
		/// <param name="work_week">Рабочая неделя.</param>
		/// <returns>Идентификатор рабочей недели.</returns>
		int Create(WorkWeekItem work_week);

		/// <summary>
		/// Удаляет задачу.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		void Delete(int id);

		/// <summary>
		/// Получает список всех задач.
		/// </summary>
		/// <returns>Список задач.</returns>
		List<WorkWeekItem> GetList();
	}
}
