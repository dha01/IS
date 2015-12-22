using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using IS.Model.Item.Access;
using IS.Model.Repository.Access;
using NUnit.Framework;
using IS.Model.Repository.Person;
using IS.Model.Item.Person;

namespace IS.Model.Tests.Repository.Access
{
	/// <summary>
	/// Тесты класса UserRepository.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	public class UserRepositoryTests
	{
		#region Fields

		private TransactionScope _transactionScope;
		private UserRepository _userRepository;

		#endregion

		#region Сonstants

		private const string LOGIN = "TestUser";
		private const string PASSWORD = "TestPassword";

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_userRepository = new UserRepository();
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

		#region Create

		/// <summary>
		/// Создает пользователя.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
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

		#endregion

		#region GetList

		[Test]
		public void GetList_Void_ReturnNotEmptyList()
		{
			var result = _userRepository.GetList();
			Assert.IsNotEmpty(result);
		}

		#endregion

		#region GetByPersonId

		/// <summary>
		/// Получает учетную запись по идентификатору персональных данных.
		/// </summary>
		[Test]
		public void GetByPersonId_Void_ReturnNotEmpty()
		{
			var person = new PersonItem()
			{
				Id = 1,
			};
			var result = _userRepository.GetByPersonId(person.Id);
			Assert.IsNull(result);
		}

		#endregion
	}
}
