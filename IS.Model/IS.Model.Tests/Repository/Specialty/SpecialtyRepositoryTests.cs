using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using IS.Model.Item.Specialty;
using IS.Model.Repository.Cathedra;
using IS.Model.Repository.Specialty;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Specialty
{
	/// <summary>
	/// Тесты для репозитория специальностей.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	public class SpecialtyRepositoryTests
	{
		#region Fields

		/// <summary>
		/// Транзакция.
		/// </summary>
		private TransactionScope _transactionScope;

		/// <summary>
		/// Репозиторий специальностей.
		/// </summary>
		private SpecialtyRepository _specialtyRepository;
		private CathedraRepository _cathedraRepository;

		private SpecialtyItem _specialty;
		private SpecialtyItem _specialtyNew;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_cathedraRepository = new CathedraRepository();
			_specialtyRepository = new SpecialtyRepository();

			_specialty = new SpecialtyItem()
			{
				FullName = "Программное обеспечение вычислительной техники и автоматизированных систем",
				ShortName = "Ифн",
				Code = "230105",
				CathedraId = _cathedraRepository.GetList().First().Id
			};
			_specialtyNew = new SpecialtyItem()
			{
				FullName = "Сисадмин",
				ShortName = "Сис",
				Code = "123456",
				CathedraId = _cathedraRepository.GetList().Last().Id
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
		/// Проверяет эквивалентны ли две специальности.
		/// </summary>
		/// <param name="first_specialty">Первая специальность для сравнения.</param>
		/// <param name="second_specialty">Вторая специальность для сравнения.</param>
		private void AreEqualSpecialties(SpecialtyItem first_specialty, SpecialtyItem second_specialty)
		{
			Assert.AreEqual(first_specialty.Id, second_specialty.Id);
			Assert.AreEqual(first_specialty.FullName, second_specialty.FullName);
			Assert.AreEqual(first_specialty.ShortName, second_specialty.ShortName);
			Assert.AreEqual(first_specialty.Code, second_specialty.Code);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет параметры специальности.
		/// </summary>
		[Test]
		public void Update_Void_ReturnChangedSpecialty()
		{
			_specialty.Id = _specialtyRepository.Create(_specialty);
			var result = _specialtyRepository.Get(_specialty.Id);
			AreEqualSpecialties(result, _specialty);

			_specialtyNew.Id = _specialty.Id;
			_specialtyRepository.Update(_specialtyNew);
			result = _specialtyRepository.Get(_specialty.Id);
			AreEqualSpecialties(result, _specialtyNew);

		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет специальность.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_specialty.Id = _specialtyRepository.Create(_specialty);
			var result = _specialtyRepository.Get(_specialty.Id);
			AreEqualSpecialties(result, _specialty);

			_specialtyRepository.Delete(_specialty.Id);
			result = _specialtyRepository.Get(_specialty.Id);
			Assert.IsNull(result);
		}

		#endregion
	}
}
