using System.Transactions;
using IS.Model.Item.Specialty;
using IS.Model.Repository.Specialty;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Specialty
{
	/// <summary>
	/// Тесты для репозитория сепциальностей.
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
				FullName = "Название специальности",
				ShortName = "Спецальность",
				Code = "234"
			};
			_specialtyNew = new SpecialtyItem()
			{
				FullName = "Название специальности1",
				ShortName = "Спецальность1",
				Code = "2341"
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
			Assert.AreEqual(first_specialty.FullName, second_specialty.FullName);
			Assert.AreEqual(first_specialty.ShortName, second_specialty.ShortName);
			Assert.AreEqual(first_specialty.Code, second_specialty.Code);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет группу.
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