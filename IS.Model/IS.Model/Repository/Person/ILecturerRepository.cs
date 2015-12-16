using System.Collections.Generic;
using IS.Model.Item.Access;
using IS.Model.Item.Person;

namespace IS.Model.Repository.Person
{
    /// <summary>
    /// Интерфейс репозитория преподавателей.
    /// </summary>
    public interface ILecturerRepository : IRepository<LecturerItem>
    {
        /// <summary>
        /// Получает преподавателя по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Преподаватель.</returns>
        LecturerItem Get(int id);

        /// <summary>
        /// Создает нового преподавателя.
        /// </summary>
        /// <param name="lecturer">Задача.</param>
        /// <returns>Идентификатор созданного преподавателя.</returns>
        int Create(LecturerItem lecturer);

        /// <summary>
        /// Удаляет человека.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        void Delete(LecturerItem lecturer);

        /// <summary>
        /// Получает список всех преподавателей.
        /// </summary>
        /// <returns>Список преподавателей.</returns>
        List<LecturerItem> GetList();
    }
}