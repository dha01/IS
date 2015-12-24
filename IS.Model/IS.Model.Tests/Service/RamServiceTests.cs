using System;
using System.Collections.Generic;
using IS.Model.Item.Ram;
using IS.Model.Repository.Ram;
using IS.Model.Service;
using Moq;
using NUnit.Framework;

namespace IS.Model.Tests.Service
{
	/// <summary>
	/// Тесты для сервиса оперативной памяти.
	/// </summary>
	[Category("Unit")]
	[TestFixture]
	public class RamServiceTests
	{
		#region Fields

		/// <summary>
		/// Сервис оперативной памяти.
		/// </summary>
		private RamService _ramService;

		/// <summary>
		/// Репозиторий оперативной памяти.
		/// </summary>
		private IRamRepository _ramRepository;

		/// <summary>
		/// Тестовая единица.
		/// </summary>
		private RamItem _ram;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_ramRepository = Mock.Of<IRamRepository>();
            _ramService = new RamService(_ramRepository);

			_ram = new RamItem()
			{
                Name = "First",
                RamType = RamType.Dimm,
                Manufacturer = Manufacturer.Corsair,
                Capacity = 1,
                Voltage = 1,
                Frequency = 1,
                Throughput = 1
			}; 
		}

		#endregion

		#region RamService

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		[Test]
		public void RamService_Void_Success()
		{
			var s = new RamService();
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает единицу оперативной памяти.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			var list = new List<RamItem>(){ _ram };
            Mock.Get(_ramRepository).Setup(x => x.Create(_ram)).Returns(_ram.Id);
            Mock.Get(_ramRepository).Setup(x => x.GetList()).Returns(list);
			var result = _ramService.Create(_ram);
			Assert.AreEqual(result, _ram.Id);
		}

		/// <summary>
		/// Создает оперативную память с пустым именем.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Name' не должно быть пустым.")]
		[Test]
		public void Create_EmptyName_ReturnException()
		{
			_ram.Name = null;
			_ramService.Create(_ram);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет данные об оперативной памяти.
		/// </summary>
		[Test]
		public void Update_Void_Success()
		{
			Mock.Get(_ramRepository).Setup(x => x.Get(_ram.Id)).Returns(_ram);
			_ramService.Update(_ram);
		}

		/// <summary>
		/// Изменяет имя на пустое.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Name' не должно быть пустым.")]
		[Test]
		public void Update_EmptyName_ReturnException()
		{
			_ram.Name = null;
			_ramService.Update(_ram);
		}

		/// <summary>
		/// Обновляет единицу в пустую.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Элемент не найден.")]
		[Test]
		public void Update_TaskNotExists_ReturnException()
		{
			Mock.Get(_ramRepository).Setup(x => x.Get(_ram.Id)).Returns((RamItem)null);
			_ramService.Update(_ram);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет единицу оперативной памяти.
		/// </summary>
		[Test]
		public void Delete_Void_Success()
		{
			_ramService.Delete(_ram.Id);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список единиц оперативной памяти.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnTaskList()
		{
			var list = new List<RamItem> { _ram };

			Mock.Get(_ramRepository).Setup(x => x.GetList()).Returns(list);
			var result = _ramService.GetList();

			Assert.AreEqual(result.Count, list.Count);
		}

		#endregion
	}
}
