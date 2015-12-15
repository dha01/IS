using System;
using System.Transactions;
using IS.Model.Item.Person;
using IS.Model.Repository.Person;
using NUnit.Framework;
using IS.Model.Item.Cathedra;
using IS.Model.Item.Faculty;
using IS.Model.Repository.Cathedra;
using IS.Model.Repository.Faculty;

namespace IS.Model.Tests.Repository.Person
{
	/// <summary>
	/// Тесты для репозитория преподавателей.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	class LecturerRepositoryTest
	{
		#region Fields

		/// <summary>
		/// Транзакция.
		/// </summary>
		private TransactionScope _transactionScope;

		/// <summary>
		/// Репозиторий преподавателей.
		/// </summary>
		private LecturerRepository _lecturerRepository;
		private FacultyRepository _facultyRepository;
		private CathedraRepository _cathedraRepository;
		private PersonRepository _personRepository;

		private PersonItem _person;
		private PersonItem _personNew;
		private LecturerItem _lecturer;
		private FacultyItem _faculty;
		private LecturerItem _lecturerNew;
		private CathedraItem _cathedra;
		
		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_lecturerRepository = new LecturerRepository();
			_cathedraRepository = new CathedraRepository();
			_facultyRepository = new FacultyRepository();
			_personRepository = new PersonRepository();

			_faculty = new FacultyItem()
			{
				FullName = "Информационный",
				ShortName = "И",
			};

			_cathedra = new CathedraItem()
			{
				FullName = "Информациионных систем и технологий",
				ShortName = "ИСиТ",
				FacultyId = _facultyRepository.Create(_faculty)
			};

			_person = new PersonItem()
			{
				Birthday = DateTime.Now.AddDays(2).Date,
				FatherName = "Сидорович",
				FirstName = "Сидор",
				LastName = "Сидоров",
			};

			_lecturer = new LecturerItem()
			{
				CathedraId = _cathedraRepository.Create(_cathedra),
				Birthday = _person.Birthday,
				FatherName = _person.FatherName,
				FirstName = _person.FirstName,
				Id = _personRepository.Create(_person),
				LastName = _person.LastName,
			};

			_personNew = new PersonItem()
			{
				Birthday = DateTime.Now.AddDays(3).Date,
				FatherName = "Петрович",
				FirstName = "Петр",
				LastName = "Петров",
			};
			_lecturerNew = new LecturerItem()
			{
				CathedraId = _cathedraRepository.Create(_cathedra),
				Birthday = _personNew.Birthday,
				FatherName = _personNew.FatherName,
				FirstName = _personNew.FirstName,
				Id = _personRepository.Create(_person),
				LastName = _personNew.LastName
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
		/// Проверяет эквивалентны ли два преподавателя.
		/// </summary>
		/// <param name="firstLecturer">Первый преподаватель.</param>
		/// <param name="secondLecturer">Второй преподаватель.</param>
		private void AreEqualPerson(LecturerItem firstLecturer, LecturerItem secondLecturer)
		{
			Assert.AreEqual(firstLecturer.Id, secondLecturer.Id);
			Assert.AreEqual(firstLecturer.LastName, secondLecturer.LastName);
			Assert.AreEqual(firstLecturer.FirstName, secondLecturer.FirstName);
			Assert.AreEqual(firstLecturer.FatherName, secondLecturer.FatherName);
			Assert.AreEqual(firstLecturer.Birthday, secondLecturer.Birthday);
			Assert.AreEqual(firstLecturer.CathedraId, secondLecturer.CathedraId);
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает преподавателя.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			_lecturer.Id = _lecturerRepository.Create(_lecturer);
			var result = _lecturerRepository.Get(_lecturer.Id);
			AreEqualPerson(result, _lecturer);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет преподавателя.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_lecturer.Id = _lecturerRepository.Create(_lecturer);
			var result = _lecturerRepository.Get(_lecturer.Id);
			AreEqualPerson(result, _lecturer);
			_lecturerRepository.Delete(_lecturer);
			result = _lecturerRepository.Get(_lecturer.Id);
			Assert.IsNull(result);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список всех преподавателей.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnNotEmptyListWithPerson()
		{
			_lecturer.Id = _lecturerRepository.Create(_lecturer);
			var result = _lecturerRepository.GetList().Find(x => x.Id == _lecturer.Id);
			AreEqualPerson(result, _lecturer);
		}

		#endregion
	}
}
