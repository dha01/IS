using System;
using System.Transactions;
using IS.Model.Item.Team;
using IS.Model.Repository.Team;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Team
{
	/// <summary>
	/// Тесты для репозитория групп.
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
		private TeamRepository _teamRepository;

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
			_teamRepository = new TeamRepository();

			_team = new TeamItem()
			{
                Name = "PE-21b",
                CreateDate = DateTime.Now,
			}; 
			_teamNew = new TeamItem()
			{
                Name = "PE-22b",
                CreateDate = DateTime.Now.AddYears(-3),
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
		/// Проверяет эквивалентны ли две группы.
		/// </summary>
		/// <param name="first_team">Первая группа для сравнения.</param>
		/// <param name="second_team">Вторая группа для сравнения.</param>
		private void AreEqualTeams(TeamItem first_team, TeamItem second_team)
		{
            Assert.AreEqual(first_team.Id, second_team.Id);
            Assert.AreEqual(first_team.Name, second_team.Name);
            Assert.AreEqual(first_team.CreateDate, second_team.CreateDate);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет группу.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_team.Id = _teamRepository.Create(_team);
			var result = _teamRepository.Get(_team.Id);
			AreEqualTeams(result, _team);

			_teamRepository.Delete(_team.Id);
			result = _teamRepository.Get(_team.Id);
			Assert.IsNull(result);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список всех групп.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnNotEmptyListWithTeam()
		{
			_team.Id = _teamRepository.Create(_team);
			var result = _teamRepository.GetList().Find(x => x.Id == _team.Id);
			AreEqualTeams(result, _team);
		}

		#endregion
	}
}
