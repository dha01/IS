using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using IS.Model.Item.Comment;
using IS.Model.Repository.Comment;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Comment
{
	/// <summary>
	/// Тесты для репозитория комментариев.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	public class CommentRepositoryTests
	{
		#region Fields

		/// <summary>
		/// Транзакция.
		/// </summary>
		private TransactionScope _transactionScope;

		/// <summary>
		/// Репозиторий комментариев.
		/// </summary>
		private CommentRepository _commentRepository;

		private CommentItem _comment;
		private CommentItem _commentNew;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_commentRepository = new CommentRepository();

			_comment = new CommentItem()
			{
				AddDate = DateTime.Now.Date, 
				Person = 2,
				Text = "Задача номер 1",
				Task = 1
			};
			_commentNew = new CommentItem()
			{
				AddDate = DateTime.Now.AddYears(-1).Date,
				Person = 1,
				Text = "Задача номер 2",
				Task = 2
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
		/// Проверяет еквивалентны ли два комментария.
		/// </summary>
		/// <param name="first_comment"></param>
		/// <param name="second_comment"></param>
		private void AreEqualComments(CommentItem first_comment, CommentItem second_comment)
		{
			Assert.AreEqual(first_comment.Id, second_comment.Id);
			Assert.AreEqual(first_comment.AddDate, second_comment.AddDate);
			Assert.AreEqual(first_comment.Person, second_comment.Person);
			Assert.AreEqual(first_comment.Text, second_comment.Text);
			Assert.AreEqual(first_comment.Task, second_comment.Task);
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает комментарий.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			_comment.Id = _commentRepository.Create(_comment);
			var result = _commentRepository.Get(_comment.Id);
			AreEqualComments(result, _comment);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет параметры комментария.
		/// </summary>
		[Test]
		public void Update_Void_ReturnChangedComment()
		{
			_comment.Id = _commentRepository.Create(_comment);
			var result = _commentRepository.Get(_comment.Id);
			AreEqualComments(result, _comment);

			_commentNew.Id = _comment.Id;
			_commentRepository.Update(_commentNew);
			result = _commentRepository.Get(_comment.Id);
			AreEqualComments(result, _commentNew);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет комментарий.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_comment.Id = _commentRepository.Create(_comment);
			var result = _commentRepository.Get(_comment.Id);
			AreEqualComments(result, _comment);

			_commentRepository.Delete(_comment.Id);
			result = _commentRepository.Get(_comment.Id);
			Assert.IsNull(result);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список всех комментариев.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnNotEmptyListWithComment()
		{
			_comment.Id = _commentRepository.Create(_comment);
			var result = _commentRepository.GetList().Find(x => x.Id == _comment.Id);
			AreEqualComments(result, _comment);
		}

		#endregion
	}
}
