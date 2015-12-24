using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using IS.Model.Item.Ram;
using IS.Model.Repository.Ram;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Ram
{
	/// <summary>
	/// Тесты для репозитория учбных курсов.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	public class RamRepositoryTests
	{
		#region Fields

		/// <summary>
		/// Транзакция.
		/// </summary>
		private TransactionScope _transactionScope;

		/// <summary>
		/// Репозиторий курсов.
		/// </summary>
        private RamRepository _ramRepository;

        private RamItem _ram;
        private RamItem _ramNew;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
            _ramRepository = new RamRepository();

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
			_ramNew = new RamItem()
			{
                Name = "Second",
                RamType = RamType.Ddr,
                Manufacturer = Manufacturer.Kingmax,
                Capacity = 2,
                Voltage = 2,
                Frequency = 2,
                Throughput = 2
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
		/// Проверяет эквивалентны ли два учебных курса.
		/// </summary>
		/// <param name="first_ram">Первый учебный курс</param>
		/// <param name="second_ram">Второй учебный курс</param>
		private void AreEqualRam(RamItem first_ram, RamItem second_ram)
		{
			Assert.AreEqual(first_ram.Id, second_ram.Id);
            Assert.AreEqual(first_ram.Name, second_ram.Name);
            Assert.AreEqual(first_ram.Capacity, second_ram.Capacity);
            Assert.AreEqual(first_ram.Voltage, second_ram.Voltage);
            Assert.AreEqual(first_ram.Frequency, second_ram.Frequency);
            Assert.AreEqual(first_ram.Throughput, second_ram.Throughput);
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает учебный курс.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			_ram.Id = _ramRepository.Create(_ram);
			var result = _ramRepository.Get(_ram.Id);
			AreEqualRam(result, _ram);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет параметры учебного курса.
		/// </summary>
		[Test]
		public void Update_Void_ReturnChangedRam()
		{
			_ram.Id = _ramRepository.Create(_ram);
			var result = _ramRepository.Get(_ram.Id);
			AreEqualRam(result, _ram);

			_ramNew.Id = _ram.Id;
			_ramRepository.Update(_ramNew);
			result = _ramRepository.Get(_ram.Id);
			AreEqualRam(result, _ramNew);

		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет курс.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_ram.Id = _ramRepository.Create(_ram);
			var result = _ramRepository.Get(_ram.Id);
			AreEqualRam(result, _ram);

			_ramRepository.Delete(_ram.Id);
			result = _ramRepository.Get(_ram.Id);
			Assert.IsNull(result);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список всех учебных курсов.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnNotEmptyListWithRam()
		{
			_ram.Id = _ramRepository.Create(_ram);
			var result = _ramRepository.GetList().Find(x => x.Id == _ram.Id);
			AreEqualRam(result, _ram);
		}

		#endregion
	}
}
