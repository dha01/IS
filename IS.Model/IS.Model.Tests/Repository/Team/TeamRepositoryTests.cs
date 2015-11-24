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
				Name = "ПЕ-22б",
				CreateDate = DateTime.Now.Date
			}; 
			_teamNew = new TeamItem()
			{
				Name = "ПЕ-21б",
				CreateDate = DateTime.Now.AddYears(-1)
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
		/// <param name="first_team"></param>
		/// <param name="second_team"></param>
		private void AreEqualTeams(TeamItem first_team, TeamItem second_team)
		{
			Assert.AreEqual(first_team.Id, second_team.Id);
			Assert.AreEqual(first_team.Name, second_team.Name);
			Assert.AreEqual(first_team.CreateDate, second_team.CreateDate);
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает группу.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			_team.Id = _teamRepository.Create(_team);
			var result = _teamRepository.Get(_team.Id);
			AreEqualTeams(result, _team);
		}

		#endregion

		#region Update

	

		#endregion

		#region Delete

	

		#endregion

		#region GetList

	

		#endregion
	}
}
