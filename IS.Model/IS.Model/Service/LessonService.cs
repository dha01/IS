using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Model.Item.Lesson;
using IS.Model.Repository.Lesson;

namespace IS.Model.Service
{
    /// <summary>
    /// Сервис для работы с занятиями.
    /// </summary>
    public class LessonService
    {
        #region Fields

        /// <summary>
        /// Репозиторий занятий.
        /// </summary>
        private ILessonRepository _lessonRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор без параметров.
        /// </summary>
        public LessonService()
        {
            _lessonRepository = new LessonRepository();
        }

        /// <summary>
        /// Конструктор класс.
        /// </summary>
        /// <param name="lesson_repository">Интерфейс репозитория занятий.</param>
        public LessonService(ILessonRepository lesson_repository)
        {
            _lessonRepository = lesson_repository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Получает занятия по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Задача.</returns>
        public LessonItem GetById(int id)
        {
            return _lessonRepository.Get(id);
        }

        /// <summary>
        /// Создает занятие.
        /// </summary>
        /// <param name="lesson">Занятие.</param>
        /// <returns>Идентификаторо созданного занятия.</returns>
        public int Create(LessonItem lesson)
        {
           var list = GetList().FindAll(x => x.Type == lesson.Type);
            if (list.Any())
            {
                lesson.Type = GetList().FindAll(x => x.Type == lesson.Type).Max(y => y.Type) + 1;
            }
            else
            {
                lesson.Discipline = 1;
            }

            return _lessonRepository.Create(lesson);
        }

        /// <summary>
        /// Измененяет данные о занятие.
        /// </summary>
        /// <param name="lesson">Занятие.</param>
        public void Update(LessonItem lesson)
        {

            if (GetById(lesson.Id) == null)
            {
                throw new Exception("Занятие не найдено.");
            }

            _lessonRepository.Update(lesson);
        }

        /// <summary>
        /// Удаляет занятие.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        public void Delete(int id)
        {
            _lessonRepository.Delete(id);
        }

        /// <summary>
        /// Меняет статус занятия.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        public void SetState(int id)
        {
            var lesson = _lessonRepository.Get(id);
            _lessonRepository.Update(lesson);
        }

        /// <summary>
        /// Получает список занятий.
        /// </summary>
        public List<LessonItem> GetList()
        {
            return _lessonRepository.GetList();
        }


        #endregion
    }
}
