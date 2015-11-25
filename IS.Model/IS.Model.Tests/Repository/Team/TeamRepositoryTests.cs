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
		private TeamRepository _TeamRepository;

		private TeamItem _Team;
		private TeamItem _TeamNew;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_TeamRepository = new TeamRepository();

			_Team = new TeamItem()
			{
				Name = "1",
				CreateDate= DateTime.Now.Date,
				
			};
			_TeamNew = new TeamItem()
			{
				Name = "2",
				CreateDate = DateTime.Now.Date,
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
		/// <param name="first_Team"></param>
		/// <param name="second_Team"></param>
		private void AreEqualTeams(TeamItem first_Team, TeamItem second_Team)
		{
			Assert.AreEqual(first_Team.Id, second_Team.Id);
			Assert.AreEqual(first_Team.Name, second_Team.Name);
			Assert.AreEqual(first_Team.CreateDate, second_Team.CreateDate);
		
		}

		#endregion
		#region GetList

		/// <summary>
		/// Получает список всех задач.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnNotEmptyListWithTeam()
		{
			_Team.Id = _TeamRepository.Create(_Team);
			var result = _TeamRepository.GetList().Find(x => x.Id == _Team.Id);
			AreEqualTeams(result, _Team);
		}

		#endregion
	}
}

