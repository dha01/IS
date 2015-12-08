using System;
using System.Collections.Generic;
using IS.Model.Item.Auditory;
using IS.Model.Repository.Auditory;
using IS.Model.Service;
using Moq;
using NUnit.Framework;

namespace IS.Model.Tests.Service
{
	/// <summary>
	/// Тесты для сервиса аудиторий.
	/// </summary>
	[Category("Unit")]
	[TestFixture]
	public class AuditoryServiceTests
	{
		#region Fields

		/// <summary>
		/// Сервис аудиторий.
		/// </summary>
		private AuditoryService _auditoryService;

		/// <summary>
		/// Репозиторий аудиторий.
		/// </summary>
		private IAuditoryRepository _auditoryRepository;

		/// <summary>
		/// Тестовая аудитория.
		/// </summary>
		private AuditoryItem _auditory;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_auditoryRepository = Mock.Of<IAuditoryRepository>();
			_auditoryService = new AuditoryService(_auditoryRepository);

			_auditory = new AuditoryItem()
			{
				/*Id = 1,
				Author = "",
				Deadline = DateTime.Now.AddDays(7).Date,
				Created = DateTime.Now.Date,
				Performer = "",
				Header = "Тестирование демонстрационной аудиторийи",
				IsOpen = true,
				IsPerform = false,
				Mem = "Описание",
				Number = 1,
				Priority = 0,
				Prefix = AuditoryPrefix.Refactoring*/
			}; 
		}

		#endregion

		#region AuditoryService

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		[Test]
		public void AuditoryService_Void_Success()
		{
			var s = new AuditoryService();
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает аудиторийу.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			var list = new List<AuditoryItem>(){ _auditory };
			
			Mock.Get(_auditoryRepository).Setup(x => x.Create(_auditory)).Returns(_auditory.Id);
			Mock.Get(_auditoryRepository).Setup(x => x.GetList()).Returns(list);

			var result = _auditoryService.Create(_auditory);
			Assert.AreEqual(result, _auditory.Id);
		}

/*		/// <summary>
		/// Создает аудиторию с пустым заголовком.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Header' не должно быть пустым.")]
		[Test]
		public void Create_EmptyHeader_ReturnException()
		{
			_auditory.Header = null;
			_auditoryService.Create(_auditory);
		}

		/// <summary>
		/// Создает аудиторийу с пустым описанием.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Mem' не должно быть пустым.")]
		[Test]
		public void Create_EmptyMem_ReturnException()
		{
			_auditory.Mem = null;
			_auditoryService.Create(_auditory);
		}
*/
		#endregion

		#region Update

		/// <summary>
		/// Изменяет данные о аудитории.
		/// </summary>
		[Test]
		public void Update_Void_Success()
		{
			Mock.Get(_auditoryRepository).Setup(x => x.Get(_auditory.Id)).Returns(_auditory);
			_auditoryService.Update(_auditory);
		}

/*		/// <summary>
		/// Изменяет заголовок на пустой.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Header' не должно быть пустым.")]
		[Test]
		public void Update_EmptyHeader_ReturnException()
		{
			_auditory.Header = null;
			_auditoryService.Update(_auditory);
		}

		/// <summary>
		/// Изменяет описание на пустое.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Mem' не должно быть пустым.")]
		[Test]
		public void Update_EmptyMem_ReturnException()
		{
			_auditory.Mem = null;
			_auditoryService.Update(_auditory);
		}

		/// <summary>
		/// Изменяет описание на пустое.
		/// </summary>
		[ExpectedException(ExpectedMessage = "аудиторийа не найдена.")]
		[Test]
		public void Update_AuditoryNotExists_ReturnException()
		{
			Mock.Get(_auditoryRepository).Setup(x => x.Get(_auditory.Id)).Returns((AuditoryItem)null);
			_auditoryService.Update(_auditory);
		}
*/
		#endregion

		#region Delete

		/// <summary>
		/// Удаляет аудиторию.
		/// </summary>
		[Test]
		public void Delete_Void_Success()
		{
			_auditoryService.Delete(_auditory.Id);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список аудиторий.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnAuditoryList()
		{
			var list = new List<AuditoryItem> { _auditory };

			Mock.Get(_auditoryRepository).Setup(x => x.GetList()).Returns(list);
			var result = _auditoryService.GetList();

			Assert.AreEqual(result.Count, list.Count);
		}

		#endregion
	}
}
