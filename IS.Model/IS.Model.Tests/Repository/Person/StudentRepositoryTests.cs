using System;
using System.Transactions;
using IS.Model.Item.Person;
using IS.Model.Item.Team;
using IS.Model.Repository.Person;
using IS.Model.Repository.Team;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Person
{
	/// <summary>
	/// Тесты для репозитория студентов.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	public class StudentRepositoryTests
	{
		#region Fields

		/// <summary>
		/// Транзакция.
		/// </summary>
		private TransactionScope _transactionScope;

		/// <summary>
		/// Репозиторий задач.
		/// </summary>
		private StudentRepository _studentRepository;
		private TeamRepository _teamRepository;

		private StudentItem _student;
		private StudentItem _studentNew;
		private TeamItem _team;
		private TeamItem _teamNew;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_studentRepository = new StudentRepository();
			_teamRepository = new TeamRepository();
			_team = new TeamItem(){CreateDate = DateTime.Now, Name = "ПЕ-22б"};
			_team.Id = _teamRepository.Create(_team);
			_student = new StudentItem()
			{
				LastName = "",
				FirstName = "",
				FatherName = "",
				Birthday = DateTime.Now,
				TeamId = _team.Id
			}; 

			_teamNew = new TeamItem(){CreateDate = DateTime.Now, Name = "ПЕ-21б"};
			_teamNew.Id = _teamRepository.Create(_teamNew);
			_studentNew = new StudentItem()
			{
				LastName = "",
				FirstName = "",
				FatherName = "",
				Birthday = DateTime.Now,
				TeamId = _teamNew.Id
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
		/// Проверяет еквивалентны ли два студента.
		/// </summary>
		/// <param name="first_student"></param>
		/// <param name="second_student"></param>
		private void AreEqualStudents(StudentItem first_student, StudentItem second_student)
		{
			Assert.AreEqual(first_student.Id, second_student.Id);
			Assert.AreEqual(first_student.LastName, second_student.LastName);
			Assert.AreEqual(first_student.FirstName, second_student.FirstName);
			Assert.AreEqual(first_student.FatherName, second_student.FatherName);
			Assert.AreEqual(first_student.Birthday, second_student.Birthday);
			Assert.AreEqual(first_student.TeamId, second_student.TeamId);
		}

		#endregion

		#region Create

		/// <summary>
		/// Зачисляет студента в группу.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			_student.Id = _studentRepository.Create(_student);
			var result = _studentRepository.Get(_student.Id);
			AreEqualStudents(result, _student);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет данные о студенте.
		/// </summary>
		[Test]
		public void Update_Void_ReturnChangedStudent()
		{
			_student.Id = _studentRepository.Create(_student);
			var result = _studentRepository.Get(_student.Id);
			AreEqualStudents(result, _student);

			_studentNew.Id = _student.Id;
			_studentRepository.Update(_studentNew);
			result = _studentRepository.Get(_student.Id);
			AreEqualStudents(result, _studentNew);

		}

		#endregion

		#region Delete

		/// <summary>
		/// Исключает студента.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_student.Id = _studentRepository.Create(_student);
			var result = _studentRepository.Get(_student.Id);
			AreEqualStudents(result, _student);

			_studentRepository.Delete(result);
			result = _studentRepository.Get(_student.Id);
			Assert.IsNull(result);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список студентов по индетификатору группы.
		/// </summary>
		[Test]
		public void GetListByTeam_Void_ReturnNotEmptyListWithStudent(int team_id)
		{
			_student.Id = _studentRepository.Create(_student);
			var result = _studentRepository.GetListByTeam(team_id).Find(x => x.Id == _student.Id);
			AreEqualStudents(result, _student);
		}

		#endregion
	}
}
