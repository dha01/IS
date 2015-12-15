using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using IS.Model.Item.Calendar;
using IS.Model.Repository.Calendar;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Calendar
{

    /// <summary>
    /// Тесты для репозитория рабочих дней.
    /// </summary>
    [Category("Integration")]
    [TestFixture]
    public class WorkDayRepositoryTests
    {
        #region Fields

        /// <summary>
        /// Транзакция.
        /// </summary>
        private TransactionScope _transactionScope;

        /// <summary>
        /// Репозиторий рабочих дней.
        /// </summary>
        private WorkDayRepository _workDayRepository;

        private WorkDayItem _workDay;
        private WorkDayItem _workDayNew;

        #endregion

        #region SetUp

        /// <summary>
        /// Выполняется перед каждым тестом.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _transactionScope = new TransactionScope();
            _workDayRepository = new WorkDayRepository();

            _workDay = new WorkDayItem()
            {
                Date = DateTime.Now.Date,
                WorkDateType = WorkDayPrefix.Holiday,
                WorkWeek = 0,
            };
            _workDayNew = new WorkDayItem()
            {
                Date = DateTime.Now.Date.AddDays(120),
                WorkDateType = WorkDayPrefix.Work,
                WorkWeek = 0,
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
        /// Проверяет еквивалентны ли два дня.
        /// </summary>
        /// <param name="first_wrkDay">Первый рабочий день.</param>
        /// <param name="second_workDay">Второй рабочий день.</param>
        private void AreEqualWorkDay(WorkDayItem first_workDay, WorkDayItem second_workDay)
        {
            Assert.AreEqual(first_workDay.Id, second_workDay.Id);
            Assert.AreEqual(first_workDay.Date, second_workDay.Date);
            Assert.AreEqual(first_workDay.WorkDateType, second_workDay.WorkDateType);
        }

        #endregion

        #region Create

        /// <summary>
        /// Создает рабочий день.
        /// </summary>
        [Test]
        public void Create_Void_ReturnId()
        {
            _workDay.Id = _workDayRepository.Create(_workDay);
            var result = _workDayRepository.Get(_workDay.Id);
            AreEqualWorkDay(result, _workDay);
        }

        #endregion

        #region Update

        /// <summary>
        /// Изменяет параметры рабочего дня.
        /// </summary>
        [Test]
        public void Update_Void_ReturnChangedWorkDay()
        {
            _workDay.Id = _workDayRepository.Create(_workDay);
            var result = _workDayRepository.Get(_workDay.Id);
            AreEqualWorkDay(result, _workDay);

            _workDayNew.Id = _workDay.Id;
            _workDayRepository.Update(_workDayNew);
            result = _workDayRepository.Get(_workDay.Id);
            AreEqualWorkDay(result, _workDayNew);

        }

        #endregion

        #region Delete

        /// <summary>
        /// Удаляет рабочий день.
        /// </summary>
        [Test]
        public void Delete_Void_ReturnNull()
        {
            _workDay.Id = _workDayRepository.Create(_workDay);
            var result = _workDayRepository.Get(_workDay.Id);
            AreEqualWorkDay(result, _workDay);

            _workDayRepository.Delete(_workDay.Id);
            result = _workDayRepository.Get(_workDay.Id);
            Assert.IsNull(result);
        }

        #endregion

        #region GetList

        /// <summary>
        /// Получает список всех рабочих дней.
        /// </summary>
        [Test]
        public void GetList_Void_ReturnNotEmptyListWithWorkDay()
        {
            _workDay.Id = _workDayRepository.Create(_workDay);
            var result = _workDayRepository.GetList().Find(x => x.Id == _workDay.Id);
            AreEqualWorkDay(result, _workDay);
        }

        #endregion
    }
}
