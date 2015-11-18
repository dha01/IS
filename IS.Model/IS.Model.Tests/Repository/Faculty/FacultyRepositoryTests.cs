﻿using System;
using System.Transactions;
using IS.Model.Item.Housing;
using IS.Model.Repository.Housing;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Faculty
{
	/// <summary>
	/// Тесты для репозитория факультетов.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	public class FacultyRepositoryTests
	{
		#region Fields

		/// <summary>
		/// Транзакция.
		/// </summary>
		private TransactionScope _transactionScope;

		/// <summary>
		/// Репозиторий факультетов.
		/// </summary>
		private HousingRepository _facultyRepository;

		private HousingItem _faculty;
		private HousingItem _facultyNew;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_facultyRepository = new HousingRepository();
			_faculty = new HousingItem()
			{
				Number = "Экономический",
				Level = "Э",
			};
			_facultyNew = new HousingItem()
			{
				Number = "Социальный",
				Level = "С",
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
		/// Проверяет эквивалентны ли два факультета.
		/// </summary>
		/// <param name="first_faculty"></param>
		/// <param name="second_faculty"></param>
		private void AreEqualFaculties(HousingItem first_faculty, HousingItem second_faculty)
		{
			Assert.AreEqual(first_faculty.Id, second_faculty.Id);
			Assert.AreEqual(first_faculty.Number, second_faculty.Number);
			Assert.AreEqual(first_faculty.Level, second_faculty.Level);
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает факультет.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			_faculty.Id = _facultyRepository.Create(_faculty);
			var result = _facultyRepository.Get(_faculty.Id);
			AreEqualFaculties(result, _faculty);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет параметры факультета.
		/// </summary>
		[Test]
		public void Update_Void_ReturnChangedFaculty()
		{
			_faculty.Id = _facultyRepository.Create(_faculty);
			var result = _facultyRepository.Get(_faculty.Id);
			AreEqualFaculties(result, _faculty);
			_facultyNew.Id = _faculty.Id;
			_facultyRepository.Update(_facultyNew);
			result = _facultyRepository.Get(_faculty.Id);
			AreEqualFaculties(result, _facultyNew);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет факультет.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_faculty.Id = _facultyRepository.Create(_faculty);
			var result = _facultyRepository.Get(_faculty.Id);
			AreEqualFaculties(result, _faculty);
			_facultyRepository.Delete(_faculty.Id);
			result = _facultyRepository.Get(_faculty.Id);
			Assert.IsNull(result);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список всех факультетов.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnNotEmptyListWithFaculty()
		{
			_faculty.Id = _facultyRepository.Create(_faculty);
			var result = _facultyRepository.GetList().Find(x => x.Id == _faculty.Id);
			AreEqualFaculties(result, _faculty);
		}

		#endregion
	}
}
