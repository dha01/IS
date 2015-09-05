using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using IS.Mvc.Models.Item.Access;
using IS.Mvc.Models.Repository.Access;
using NUnit.Framework;

namespace IS.Mvc.Tests.Models.Repository.Access
{
	[Category("Integration")]
	[TestFixture]
	public class UserRepositoryTests
	{
		private TransactionScope _transactionScope;
		private UserRepository _userRepository;

		private const string LOGIN = "TestUser";
		private const string PASSWORD = "TestPassword";
		
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_userRepository = new UserRepository();
		}

		[TearDown]
		public void TearDown()
		{
			_transactionScope.Dispose();
		}
		
		[Test]
		public void Create()
		{
			var user = new UserItem()
			{
				Login = LOGIN,
				Password = PASSWORD
			};

			int id = _userRepository.Create(user);

			var result = _userRepository.Get(id);

			Assert.AreEqual(result.Id, id);
			Assert.AreEqual(result.Login, user.Login);
			Assert.AreEqual(result.Password, user.Password);
		}
	}
}
