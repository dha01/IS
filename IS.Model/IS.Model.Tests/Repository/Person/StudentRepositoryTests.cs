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
	/// Тесты для репозитория задач.
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
		/// Проверяет еквивалентны ли две задачи.
		/// </summary>
		/// <param name="first_task"></param>
		/// <param name="second_task"></param>
		private void AreEqualStudents(StudentItem first_task, StudentItem second_task)
		{
			Assert.AreEqual(first_task.Id, second_task.Id);
			Assert.AreEqual(first_task.Author, second_task.Author);
			Assert.AreEqual(first_task.Deadline, second_task.Deadline);
			Assert.AreEqual(first_task.Performer, second_task.Performer);
			Assert.AreEqual(first_task.Header, second_task.Header);
			Assert.AreEqual(first_task.IsOpen, second_task.IsOpen);
			Assert.AreEqual(first_task.IsPerform, second_task.IsPerform);
			Assert.AreEqual(first_task.Mem, second_task.Mem);
			Assert.AreEqual(first_task.Number, second_task.Number);
			Assert.AreEqual(first_task.Priority, second_task.Priority);
			Assert.AreEqual(first_task.Prefix, second_task.Prefix);
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает задачу.
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
		/// Изменяет параметры задачи.
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
		/// Удаляет задачу.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_student.Id = _studentRepository.Create(_student);
			var result = _studentRepository.Get(_student.Id);
			AreEqualStudents(result, _student);

			_studentRepository.Delete(_student.Id);
			result = _studentRepository.Get(_student.Id);
			Assert.IsNull(result);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список всех задач.
		/// </summary>
		[Test]
		public void GetListByTeam_Void_ReturnNotEmptyListWithStudent(team_id)
		{
			_student.Id = _studentRepository.Create(_student);
			var result = _studentRepository.GetListByTeam(team_id).Find(x => x.Id == _student.Id);
			AreEqualStudents(result, _student);
		}

		#endregion
	}
}
