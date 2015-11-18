using System;
using System.Transactions;
using IS.Model.Item.Person;
using IS.Model.Repository.Person;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Housing
{
	/// <summary>
	/// Тесты для репозитория людей.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	public class HousingRepositoryTest
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
			_housingRepository = new PersonRepository();

			_housing = new PersonItem()
			{
				Id = 1,
				LastName = "Иванов",
				FirstName = "Василий",
				Birthday = DateTime.Now.Date,
				FatherName = "Иванович"
				
			};
			_housingNew = new PersonItem()
			{
				Id = 1,
				LastName = "Пупкин",
				FirstName = "Сергей",
				Birthday = DateTime.Now.Date,
				FatherName = "Петрович"
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
		/// Проверяет эквивалентны ли два человека.
		/// </summary>
		/// <param name="first_person"></param>
		/// <param name="second_person"></param>
		private void AreEqualPerson(PersonItem first_person, PersonItem second_person)
		{
			Assert.AreEqual(first_person.Id, second_person.Id);
			Assert.AreEqual(first_person.LastName, second_person.LastName);
			Assert.AreEqual(first_person.FirstName, second_person.FirstName);
			Assert.AreEqual(first_person.FatherName, second_person.FatherName);
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
			_housing.Id = _housingRepository.Create(_housing);
			var result = _housingRepository.Get(_housing.Id);
			AreEqualHousing(result, _housing);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет параметры человека.
		/// </summary>
		[Test]
		public void Update_Void_ReturnChangedPerson()
		{
			_housing.Id = _housingRepository.Create(_housing);
			var result = _housingRepository.Get(_housing.Id);
			AreEqualHousing(result, _housing);
			_housingNew.Id = _housing.Id;
			_housingRepository.Update(_housingNew);
			result = _housingRepository.Get(_housing.Id);
			AreEqualHousing(result, _housingNew);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет человека.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_housing.Id = _housingRepository.Create(_housing);
			var result = _housingRepository.Get(_housing.Id);
			AreEqualHousing(result, _housing);
			_housingRepository.Delete(_housing.Id);
			result = _housingRepository.Get(_housing.Id);
			Assert.IsNull(result);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список всех людей.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnNotEmptyListWithPerson()
		{
			_housing.Id = _housingRepository.Create(_housing);
			var result = _housingRepository.GetList().Find(x => x.Id == _housing.Id);
			AreEqualHousing(result, _housing);
		}

		#endregion
	}
}
