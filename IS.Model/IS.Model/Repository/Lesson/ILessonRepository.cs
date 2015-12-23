using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Model.Item.Access;
using IS.Model.Item.Lesson;

namespace IS.Model.Repository.Lesson
{
    /// <summary>
    /// Интерфейс репозитория задач.
    /// </summary>
    public interface ILessonRepository : IRepository<LessonItem>
    {
        /// <summary>
        /// Получает занятие по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Занятие.</returns>
        LessonItem Get(int id);

        /// <summary>
        /// Обновляет данные по занятиям.
        /// </summary>
        /// <param name="lesson">Занятие.</param>
        void Update(LessonItem lesson);

        /// <summary>
        /// Создает новое занятие.
        /// </summary>
        /// <param name="lesson">Занятие.</param>
        /// <returns>Идентификатор созданного занятия.</returns>
        int Create(LessonItem lesson);

        /// <summary>
        /// Удаляет занятие.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        void Delete(int id);

        /// <summary>
        /// Получает список всех занятий.
        /// </summary>
        /// <returns>Список занятий.</returns>
        List<LessonItem> GetList();
    }
}
