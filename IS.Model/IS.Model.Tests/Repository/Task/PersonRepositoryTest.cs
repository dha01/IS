using System;
using System.Transactions;
using IS.Model.Item.Task;
using IS.Model.Repository.Task;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Task
{
    /// <summary>
    /// Тесты для репозитория людей.
    /// </summary>
    [Category("Integration")]
    [TestFixture]
    public class PersonRepositoryTest
    {
        #region Fields

        /// <summary>
        /// Транзакция.
        /// </summary>
        private TransactionScope _transactionScope;

        /// <summary>
        /// Репозиторий людей.
        /// </summary>
        private PersonRepository _personRepository;

        private TaskItem _person; 
        private TaskItem _personNew;

        #endregion

        #region SetUp

        /// <summary>
        /// Выполняется перед каждым тестом.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _transactionScope = new TransactionScope();
            _personRepository = new PersonRepository();

            _person = new TaskItem()
            {
                Author = "",
                Deadline = DateTime.Now.AddDays(7).Date,
                Created = DateTime.Now.Date,
                Performer = "",
                Header = "Тестирование людей",
                IsOpen = true,
                IsPerform = false,
                Mem = "Описание",
                Number = 1,
                Priority = 0,
                Prefix = TaskPrefix.Refactoring
            };
            _personNew = new TaskItem()
            {
                Author = "1",
                Deadline = DateTime.Now.AddDays(8).Date,
                Created = DateTime.Now.Date,
                Performer = "2",
                Header = "Тестирование людей 2",
                IsOpen = false,
                IsPerform = true,
                Mem = "Описание2",
                Number = 2,
                Priority = 5,
                Prefix = TaskPrefix.Demo
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
        /// Проверяет еквивалентны ли две задачи.
        /// </summary>
        /// <param name="first_task"></param>
        /// <param name="second_task"></param>
        private void AreEqualTasks(TaskItem first_task, TaskItem second_task)
        {
            Assert.AreEqual(first_task.Id, second_task.Id);
            Assert.AreEqual(first_task.Author, second_task.Author);
            Assert.AreEqual(first_task.Deadline, second_task.Deadline);
            Assert.AreEqual(first_task.Performer, second_task.Performer);
            Assert.AreEqual(first_task.Header, second_task.Header);
            Assert.AreEqual(first_task.IsOpen, second_task.IsOpen);
            Assert.AreEqual(first_task.IsPerform, second_task.IsPerform);
            Assert.AreEqual(first_task.Mem, second_task.Mem);
            Assert.AreEqual(first_task.Number, second_task.Number);
            Assert.AreEqual(first_task.Priority, second_task.Priority);
            Assert.AreEqual(first_task.Prefix, second_task.Prefix);
        }

        #endregion

        #region Create

        /// <summary>
        /// Создает человека.
        /// </summary>
        [Test]
        public void Create_Void_ReturnId()
        {
            _person.Id = _personRepository.Create(_person);
            var result = _personRepository.Get(_person.Id);
            AreEqualTasks(result, _person);
        }

        #endregion

        #region Update

        /// <summary>
        /// Изменяет параметры человека.
        /// </summary>
        [Test]
        public void Update_Void_ReturnChangedTask()
        {
            _person.Id = _personRepository.Create(_person);
            var result = _personRepository.Get(_person.Id);
            AreEqualTasks(result, _person);

            _personNew.Id = _person.Id;
            _personRepository.Update(_personNew);
            result = _personRepository.Get(_person.Id);
            AreEqualTasks(result, _personNew);

        }

        #endregion

        #region Delete

        /// <summary>
        /// Удаляет человека.
        /// </summary>
        [Test]
        public void Delete_Void_ReturnNull()
        {
            _person.Id = _personRepository.Create(_person);
            var result = _personRepository.Get(_person.Id);
            AreEqualTasks(result, _person);

            _personRepository.Delete(_person.Id);
            result = _personRepository.Get(_person.Id);
            Assert.IsNull(result);
        }

        #endregion

        #region GetList

        /// <summary>
        /// Получает список всех людей.
        /// </summary>
        [Test]
        public void GetList_Void_ReturnNotEmptyListWithTask()
        {
            _person.Id = _personRepository.Create(_person);
            var result = _personRepository.GetList().Find(x => x.Id == _person.Id);
            AreEqualTasks(result, _person);
        }

        #endregion
    }
}
