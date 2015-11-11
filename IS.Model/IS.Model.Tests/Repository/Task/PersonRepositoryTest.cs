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

        private PersonItem _person; 
        private PersonItem _personNew;

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

            _person = new PersonItem()
            {
                Id = 1,
                LastName = "",
                FirstName = "",
                Birthday = DateTime.Now.Date,
                Father = ""
                
            };
            _personNew = new PersonItem()
            {
                Id = 1,
                LastName = "",
                FirstName = "",
                Birthday = DateTime.Now.Date,
                Father = ""
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
        /// <param name="first_person"></param>
        /// <param name="second_person"></param>
        private void AreEqualTasks(PersonItem first_person, PersonItem second_person)
        {
            Assert.AreEqual(first_person.Id, second_person.Id);
            Assert.AreEqual(first_person.LastName, second_person.LastName);
            Assert.AreEqual(first_person.FirstName, second_person.FirstName);
            Assert.AreEqual(first_person.Father, second_person.Father);
            Assert.AreEqual(first_person.Birthday, second_person.Birthday);
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
