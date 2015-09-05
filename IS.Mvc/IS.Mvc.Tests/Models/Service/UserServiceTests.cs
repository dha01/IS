using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Mvc.Models.Item.Access;
using IS.Mvc.Models.Repository.Access;
using IS.Mvc.Models.Service;
using Moq;
using NUnit.Framework;
namespace IS.Mvc.Models.Service.Tests
{
	[TestFixture]
	public class UserServiceTests
	{
		private UserService _userService;

		private IUserRepository _userRepository;

		private const string LOGIN = "TestUser";
		private const string PASSWORD = "TestPassword";

		[SetUp]
		public void SetUp()
		{
			_userRepository = Mock.Of<IUserRepository>();
			_userService = new UserService(_userRepository);
		}
		
		[Test]
		public void CreateTest()
		{
			var user = new UserItem()
			{
				Login = LOGIN,
				Password = PASSWORD
			};

			Mock.Get(_userRepository).Setup(x => x.Create(user)).Returns(document);
			Assert.Fail();
		}
	}
}
