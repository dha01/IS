using System;
using System.Transactions;
using IS.Model.Item.Team;
using IS.Model.Repository.Team;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Team
{
	/// <summary>
	/// Тесты для репозитория задач.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	public class TeamRepositoryTests
	{
		#region Fields

		/// <summary>
		/// Транзакция.
		/// </summary>
		private TransactionScope _transactionScope;

		/// <summary>
		/// Репозиторий задач.
		/// </summary>
		private TeamRepository _taskRepository;

		private TeamItem _task;
		private TeamItem _taskNew;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_teamRepository = new TeamRepository();

			_team = new TeamItem()
			{
				Author = "",
				Deadline = DateTime.Now.AddDays(7).Date,
				Created = DateTime.Now.Date,
				Performer = "",
				Header = "Тестирование демонстрационной задачи",
				IsOpen = true,
				IsPerform = false,
				Mem = "Описание",
				Number = 1,
				Priority = 0,
				Prefix = TaskPrefix.Refactoring
			}; 
			_teamNew = new TeamItem()
			{
				Author = "1",
				Deadline = DateTime.Now.AddDays(8).Date,
				Created = DateTime.Now.Date,
				Performer = "2",
				Header = "Тестирование демонстрационной задачи 2",
				IsOpen = false,
				IsPerform = true,
				Mem = "Описание2",
				Number = 2,
				Priority = 5,
				Prefix = TaskPrefix.Demo
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
		/// <param name="first_team"></param>
		/// <param name="second_team"></param>
		private void AreEqualTasks(TeamItem first_team, TeamItem second_team)
		{
			Assert.AreEqual(first_team.Id, second_team.Id);
            Assert.AreEqual(first_team.FullName, second_team.FullName);
            Assert.AreEqual(first_team.ShortName, second_team.ShortName);
            Assert.AreEqual(first_team.Faculty, second_team.Faculty);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет задачу.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_task.Id = _taskRepository.Create(_task);
			var result = _taskRepository.Get(_task.Id);
			AreEqualTasks(result, _task);

			_taskRepository.Delete(_task.Id);
			result = _taskRepository.Get(_task.Id);
			Assert.IsNull(result);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список всех задач.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnNotEmptyListWithTask()
		{
			_task.Id = _taskRepository.Create(_task);
			var result = _taskRepository.GetList().Find(x => x.Id == _task.Id);
			AreEqualTasks(result, _task);
		}

		#endregion
	}
}
