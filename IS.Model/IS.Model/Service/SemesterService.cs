using System;
using System.Collections.Generic;
using System.Linq;
using IS.Model.Item.Calendar;
using IS.Model.Repository.Calendar;

namespace IS.Model.Service
{
    /// <summary>
    /// Сервис для работы с семестром.
    /// </summary>
    public class SemesterService
    {
        #region Fields

        /// <summary>
        /// Репозиторий семестров.
        /// </summary>
        private ISemesterRepository _semesterRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор без параметров.
        /// </summary>
        public SemesterService()
        {
            _semesterRepository = new SemesterRepository();
        }

        /// <summary>
        /// Конструктор класс.
        /// </summary>
        /// <param name="semester_repository">Интерфейс репозитория семестров.</param>
        public SemesterService(ISemesterRepository semester_repository)
        {
            _semesterRepository = semester_repository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Получает семестр по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Семестр.</returns>
        public SemesterItem GetById(int id)
        {
            return _semesterRepository.Get(id);
        }

        /// <summary>
        /// Создает семестр.
        /// </summary>
        /// <param name="semester">Семестр.</param>
        /// <returns>Идентификатор созданного семестра.</returns>
        public int Create(SemesterItem semester)
        {
            if (DateTime (semester.FromDate))
            {
                throw new Exception("Поле 'FromDate' не должно быть пустым.");
            }

            if (DateTime (semester.TrimDate))
            {
                throw new Exception("Поле 'TrimDate' не должно быть пустым.");
            }

            return _semesterRepository.Create(semester);
        }

        /// <summary>
        /// Измененяет данные о кафедре.
        /// </summary>
        /// <param name="cathedra">Кафедра.</param>
        public void Update(SemesterItem cathedra)
        {
            if (string.IsNullOrEmpty(semester.FromDate))
            {
                throw new Exception("Поле 'FullName' не должно быть пустым.");
            }

            if (string.IsNullOrEmpty(semester.TrimDate))
            {
                throw new Exception("Поле 'ShortName' не должно быть пустым.");
            }

            if (GetById(semester.Id) == null)
            {
                throw new Exception("Кафедра не найдена.");
            }

            _semesterRepository.Update(cathedra);
        }

        /// <summary>
        /// Удаляет семестр.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        public void Delete(int id)
        {
            _semesterRepository.Delete(id);
        }

        /// <summary>
        /// Получает список семестров.
        /// </summary>
        public List<SemesterItem> GetList()
        {
            return _semesterRepository.GetList();
        }

        #endregion
    }
}
