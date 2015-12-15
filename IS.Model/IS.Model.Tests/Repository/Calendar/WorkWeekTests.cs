using System;
using System.Transactions;
using IS.Model.Item.Calendar;
using IS.Model.Repository.Calendar;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Calendar
{
	/// <summary>
	/// Тесты для репозитория календарь.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	public class WorkWeekRepositoryTests
	{
		#region Fields

		/// <summary>
		/// Транзакция.
		/// </summary>
		private TransactionScope _transactionScope;

		/// <summary>
		/// Репозиторий календарь.
		/// </summary>
		private WorkWeekRepository _work_weekRepository;

		private WorkWeekItem _work_week;
		private WorkWeekItem _work_weekNew;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_work_weekRepository = new WorkWeekRepository();

			_work_week = new WorkWeekItem()
			{
				FromDate = DateTime.Now.Date,
				TrimDate = DateTime.Now.Date
			};
			_work_weekNew = new WorkWeekItem()
			{
				FromDate = DateTime.Now.Date,
				TrimDate = DateTime.Now.Date
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
		/// <param name="first_work_week"></param>
		/// <param name="second_work_week"></param>
		private void AreEqualTasks(WorkWeekItem first_work_week, WorkWeekItem second_work_week)
		{
			Assert.AreEqual(first_work_week.Id, second_work_week.Id);
			Assert.AreEqual(first_work_week.FromDate, second_work_week.FromDate);
			Assert.AreEqual(first_work_week.TrimDate, second_work_week.TrimDate);
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает задачу.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			_work_week.Id = _work_weekRepository.Create(_work_week);
			var result = _work_weekRepository.Get(_work_week.Id);
			AreEqualTasks(result, _work_week);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет параметры задачи.
		/// </summary>
		[Test]
		public void Update_Void_ReturnChangedWorkWeek()
		{
			_work_week.Id = _work_weekRepository.Create(_work_week);
			var result = _work_weekRepository.Get(_work_week.Id);
			AreEqualTasks(result, _work_week);

			_work_weekNew.Id = _work_week.Id;
			_work_weekRepository.Update(_work_weekNew);
			result = _work_weekRepository.Get(_work_week.Id);
			AreEqualTasks(result, _work_weekNew);

		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет задачу.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_work_week.Id = _work_weekRepository.Create(_work_week);
			var result = _work_weekRepository.Get(_work_week.Id);
			AreEqualTasks(result, _work_week);

			_work_weekRepository.Delete(_work_week.Id);
			result = _work_weekRepository.Get(_work_week.Id);
			Assert.IsNull(result);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список всех задач.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnNotEmptyListWithTask()
		{
			_work_week.Id = _work_weekRepository.Create(_work_week);
			var result = _work_weekRepository.GetList().Find(x => x.Id == _work_week.Id);
			AreEqualTasks(result, _work_week);
		}

		#endregion
	}
}