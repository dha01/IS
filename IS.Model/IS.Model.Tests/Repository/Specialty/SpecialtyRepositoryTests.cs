using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using IS.Model.Item.Specialty;
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
			_specialtyRepository = new SpecialtyRepository();

			_specialty = new SpecialtyItem()
			{
				FullName = "Программное обеспечение вычислительной техники и автоматизированных систем",
				ShortName = "Ифн",
				Code = "230105"
			};
			_specialtyNew = new SpecialtyItem()
			{
				FullName = "Сисадмин",
				ShortName = "Сис",
				Code = "123456"
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
		/// <param name="first_specialty">Первая специальность.</param>
		/// <param name="second_specialty">Вторая специальность.</param> 
		private void AreEqualSpecialtys(SpecialtyItem first_specialty, SpecialtyItem second_specialty)
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
			AreEqualSpecialtys(result, _specialty);

			_specialtyNew.Id = _specialty.Id;
			_specialtyRepository.Update(_specialtyNew);
			result = _specialtyRepository.Get(_specialty.Id);
			AreEqualSpecialtys(result, _specialtyNew);

		}

		#endregion
	}
}
