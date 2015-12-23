using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using IS.Model.Item.Lesson;
using IS.Model.Repository.Lesson;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Lesson
{
    /// <summary>
    /// Тесты для репозитория занятий.
    /// </summary>
    [Category("Integration")]
    [TestFixture]
    public class LessonRepositoryTest
    {
        #region Fields

        /// <summary>
        /// Транзакция.
        /// </summary>
        private TransactionScope _transactionScope;

        /// <summary>
        /// Репозиторий занятий.
        /// </summary>
        private LessonRepository _lessonRepository;

        private LessonItem _lesson;
        private LessonItem _lessonNew;

        #endregion

        #region SetUp

        /// <summary>
        /// Выполняется перед каждым тестом.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _transactionScope = new TransactionScope();
            _lessonRepository = new LessonRepository();

            _lesson = new LessonItem()
            {
                Discipline = 3,
               Type = LessonType.Laboratory,
               WorkDay = 1,
               FromTime = new DateTime(20150612),
               TrimeTime = new DateTime(20150803)
            };
            _lessonNew = new LessonItem()
            {
                Discipline = 2,
               Type = LessonType.Lecture,
               WorkDay = 2,
               FromTime = new DateTime(20150613),
               TrimeTime = new DateTime(20150804)
            };
        }

        #endregion

        #region TearDown

        /// <summary>
        /// Выполняется после каждого теста.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            _transactionScope.Dispose();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Проверяет еквивалентны ли два занятия.
        /// </summary>
        /// <param name="first_lesson"></param>
        /// <param name="second_lesson"></param>
        private void AreEqualLesson(LessonItem first_lesson, LessonItem second_lesson)
        {
            Assert.AreEqual(first_lesson.Id, second_lesson.Id);
            Assert.AreEqual(first_lesson.Discipline, second_lesson.Discipline);
            Assert.AreEqual(first_lesson.Type, second_lesson.Type);
            Assert.AreEqual(first_lesson.WorkDay, second_lesson.WorkDay);
            Assert.AreEqual(first_lesson.FromTime, second_lesson.FromTime);
            Assert.AreEqual(first_lesson.TrimeTime, second_lesson.TrimeTime);
        }

        #endregion

        #region Create

        /// <summary>
        /// Создает занятие.
        /// </summary>
        [Test]
        public void Create_Void_ReturnId()
        {
            _lesson.Id = _lessonRepository.Create(_lesson);
            var result = _lessonRepository.Get(_lesson.Id);
            AreEqualLesson(result, _lesson);
        }

        #endregion

        #region Update

        /// <summary>
        /// Изменяет параметры занятия.
        /// </summary>
        [Test]
        public void Update_Void_ReturnChangedLesson()
        {
            _lesson.Id = _lessonRepository.Create(_lesson);
            var result = _lessonRepository.Get(_lesson.Id);
            AreEqualLesson(result, _lesson);

            _lessonNew.Id = _lesson.Id;
            _lessonRepository.Update(_lessonNew);
            result = _lessonRepository.Get(_lesson.Id);
            AreEqualLesson(result, _lessonNew);

        }

        #endregion

        #region Delete

        /// <summary>
        /// Удаляет занятие.
        /// </summary>
        [Test]
        public void Delete_Void_ReturnNull()
        {
            _lesson.Id = _lessonRepository.Create(_lesson);
            var result = _lessonRepository.Get(_lesson.Id);
            AreEqualLesson(result, _lesson);

            _lessonRepository.Delete(_lesson.Id);
            result = _lessonRepository.Get(_lesson.Id);
            Assert.IsNull(result);
        }

        #endregion

        #region GetList

        /// <summary>
        /// Получает список всех занятий.
        /// </summary>
        [Test]
        public void GetList_Void_ReturnNotEmptyListWithLesson()
        {
            _lesson.Id = _lessonRepository.Create(_lesson);
            var result = _lessonRepository.GetList().Find(x => x.Id == _lesson.Id);
            AreEqualLesson(result, _lesson);
        }

        #endregion
    }
}
