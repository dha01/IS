using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Model.Item.Calendar;

namespace IS.Model.Repository.Calendar
{
    /// <summary>
    /// Интерфейс репозитория рабочих дней.
    /// </summary>
    public interface IWorkDayRepository
    {
        /// <summary>
        /// Получает рабочий день по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Семестр.</returns>
        WorkDayItem Get(int id);

        /// <summary>
        /// Обновляет данные по рабочим дням.
        /// </summary>
        /// <param name="WorkDay">Рабочий день.</param>
        void Update(WorkDayItem WorkDay);

        /// <summary>
        /// Создает новый рабочий день.
        /// </summary>
        /// <param name="work_day">Рабочий день.</param>
        /// <returns>Идентификатор созданного рабочего дня.</returns>
        int Create(WorkDayItem work_day);

        /// <summary>
        /// Удаляет рабочий день.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        void Delete(int id);

        /// <summary>
        /// Получает список всех рабочих дней.
        /// </summary>
        /// <returns>Список рабочих дней.</returns>
        List<WorkDayItem> GetList();
    }
}
