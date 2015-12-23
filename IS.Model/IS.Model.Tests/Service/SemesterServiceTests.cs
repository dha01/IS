using System;
using System.Collections.Generic;
using IS.Model.Item.Calendar;
using IS.Model.Repository.Calendar;
using IS.Model.Service;
using Moq;
using NUnit.Framework;

namespace IS.Model.Tests.Service
{
	/// <summary>
	/// Тесты для сервиса семестра.
	/// </summary>
	[Category("Unit")]
	[TestFixture]
	public class SemesterServiceTests
	{
		#region Fields

		/// <summary>
		/// Сервис семестров.
		/// </summary>
		private SemesterService _semesterService;

		/// <summary>
		/// Репозиторий семестров.
		/// </summary>
		private ISemesterRepository _semesterRepository;

		/// <summary>
		/// Тестовый семестр.
		/// </summary>
		private SemesterItem _semester;
		private DateTime FromDate;
		private DateTime TrimDate;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_semesterRepository = Mock.Of<ISemesterRepository>();
			_semesterService = new SemesterService(_semesterRepository);

			_semester = new SemesterItem()
			{
				FromDate = DateTime.Now.Date,
				TrimDate = DateTime.Now.AddDays(120).Date
			};
		}

		#endregion

		#region SemesterService

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		[Test]
		public void SemesterService_Void_Success()
		{
			var s = new SemesterService();
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает семестр.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			var list = new List<SemesterItem>() { _semester };

			Mock.Get(_semesterRepository).Setup(x => x.Create(_semester)).Returns(_semester.Id);
			Mock.Get(_semesterRepository).Setup(x => x.GetList()).Returns(list);

			var result = _semesterService.Create(_semester);
			Assert.AreEqual(result, _semester.Id);
		}


		#endregion

		#region Update

		/// <summary>
		/// Изменяет данные о семестре.
		/// </summary>
		[Test]
		public void Update_Void_Success()
		{
			Mock.Get(_semesterRepository).Setup(x => x.Get(_semester.Id)).Returns(_semester);
			_semesterService.Update(_semester);
		}

		/// <summary>
		/// Изменяет не существующий семестр.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Семестр не найден.")]
		[Test]
		public void Update_SemesterNotExists_ReturnException()
		{
			Mock.Get(_semesterRepository).Setup(x => x.Get(_semester.Id)).Returns((SemesterItem)null);
			_semesterService.Update(_semester);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет семестр.
		/// </summary>
		[Test]
		public void Delete_Void_Success()
		{
			_semesterService.Delete(_semester.Id);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список семестров.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnTaskList()
		{
			var list = new List<SemesterItem> { _semester };

			Mock.Get(_semesterRepository).Setup(x => x.GetList()).Returns(list);
			var result = _semesterService.GetList();

			Assert.AreEqual(result.Count, list.Count);
		}

		#endregion

	}
}

