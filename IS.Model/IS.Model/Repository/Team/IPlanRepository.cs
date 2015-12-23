using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Model.Item.Team;

namespace IS.Model.Repository.Team
{
	/// <summary>
	/// Интерфейс репозитория учебного плана группы.
	/// </summary>
	public interface IPlanRepository : IRepository<PlanItem>
	{
		/// <summary>
		/// Получает учебный план группы по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Учебный план.</returns>
		PlanItem Get(int id);

		/// <summary>
		/// Обновляет учебный план по группе.
		/// </summary>
		/// <param name="plan">Учебный план.</param>
		void Update(PlanItem plan);

		/// <summary>
		/// Создает новый учебный план.
		/// </summary>
		/// <param name="plan">Учебный план.</param>
		/// <returns>Идентификатор созданного учебного плана.</returns>
		int Create(PlanItem plan);

		/// <summary>
		/// Удаляет учебный план.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		void Delete(int id);

		/// <summary>
		/// Получает список всех учебных планов.
		/// </summary>
		/// <returns>Список учебных планов.</returns>
		List<PlanItem> GetList();
	}
}