using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Model.Item.Lesson;
using IS.Model.Repository.Lesson;
using IS.Model.Service;
using Moq;
using NUnit.Framework;

namespace IS.Model.Tests.Service
{
    /// <summary>
    /// Тесты для сервиса занятий.
    /// </summary>
    [Category("Unit")]
    [TestFixture]
    public class LessonServiceTests
    {
        #region Fields

        /// <summary>
        /// Сервис занятий.
        /// </summary>
        private LessonService _lessonService;

        /// <summary>
        /// Репозиторий занятий.
        /// </summary>
        private ILessonRepository _lessonRepository;

        /// <summary>
        /// Тестовое занятие.
        /// </summary>
        private LessonItem _lesson;

        #endregion

        #region SetUp

        /// <summary>
        /// Выполняется перед каждым тестом.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _lessonRepository = Mock.Of<ILessonRepository>();
            _lessonService = new LessonService(_lessonRepository);

            _lesson = new LessonItem()
            {
                Id = 1,
                Discipline = 3,
                Type = LessonType.Laboratory,
                WorkDay = 1,
                FromTime = new DateTime(20150612),
                TrimeTime = new DateTime(20150803)
            };
        }

        #endregion

        #region TaskService

        /// <summary>
        /// Конструктор без параметров.
        /// </summary>
        [Test]
        public void LessonService_Void_Success()
        {
            var s = new LessonService();
        }

        #endregion

        #region Create

        /// <summary>
        /// Создает занятие.
        /// </summary>
        [Test]
        public void Create_Void_ReturnId()
        {
            var list = new List<LessonItem>() { _lesson };

            Mock.Get(_lessonRepository).Setup(x => x.Create(_lesson)).Returns(_lesson.Id);
            Mock.Get(_lessonRepository).Setup(x => x.GetList()).Returns(list);

            var result = _lessonService.Create(_lesson);
            Assert.AreEqual(result, _lesson.Id);
        }

        #endregion

        #region Update

        /// <summary>
        /// Изменяет данные о занятие.
        /// </summary>
        [Test]
        public void Update_Void_Success()
        {
            Mock.Get(_lessonRepository).Setup(x => x.Get(_lesson.Id)).Returns(_lesson);
            _lessonService.Update(_lesson);
        }

        /// <summary>
        /// Изменяет описание на пустое.
        /// </summary>
        [ExpectedException(ExpectedMessage = "Занятие не найдено.")]
        [Test]
        public void Update_TaskNotExists_ReturnException()
        {
            Mock.Get(_lessonRepository).Setup(x => x.Get(_lesson.Id)).Returns((LessonItem)null);
            _lessonService.Update(_lesson);
        }

        #endregion

        #region Delete

        /// <summary>
        /// Удаляет занятие.
        /// </summary>
        [Test]
        public void Delete_Void_Success()
        {
            _lessonService.Delete(_lesson.Id);
        }

        #endregion

        #region GetList

        /// <summary>
        /// Получает список занятий.
        /// </summary>
        [Test]
        public void GetList_Void_ReturnLessonList()
        {
            var list = new List<LessonItem> { _lesson };

            Mock.Get(_lessonRepository).Setup(x => x.GetList()).Returns(list);
            var result = _lessonService.GetList();

            Assert.AreEqual(result.Count, list.Count);
        }

        #endregion
    }
}
