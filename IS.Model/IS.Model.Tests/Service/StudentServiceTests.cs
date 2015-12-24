using System;
using System.Collections.Generic;
using IS.Model.Item.Person;
using IS.Model.Repository.Person;
using IS.Model.Service;
using Moq;
using NUnit.Framework;

namespace IS.Model.Tests.Service
{
	/// <summary>
	/// Тесты для сервиса студентов.
	/// </summary>
	[Category("Unit")]
	[TestFixture]
	public class StudentServiceTests
	{
		#region Fields

		/// <summary>
		/// Сервис студентов.
		/// </summary>
		private StudentService _studentService;

		/// <summary>
		/// Репозиторий студентов.
		/// </summary>
		private IStudentRepository _studentRepository;

		/// <summary>
		/// Тестовый студент.
		/// </summary>
		private StudentItem _student;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_studentRepository = Mock.Of<IStudentRepository>();
			_studentService = new StudentService(_studentRepository);

			_student = new StudentItem()
			{
				LastName = "Егоров",
				FirstName = "Виталий",
				FatherName = "Игоревич",
				Birthday = DateTime.Now,
				TeamId = 1
			};
		}

		#endregion

		#region CathedraService

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		[Test]
		public void StudentService_Void_Success()
		{
			var s = new StudentService();
		}

		#endregion

		#region Create

		/// <summary>
		/// Зачисление студента в группу.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			var list = new List<StudentItem>() { _student };

			Mock.Get(_studentRepository).Setup(x => x.Create(_student)).Returns(_student.Id);
			Mock.Get(_studentRepository).Setup(x => x.GetList()).Returns(list);

			var result = _studentService.Create(_student);
			Assert.AreEqual(result, _student.Id);
		}

		/// <summary>
		/// Создает студента с пустым полем "LastName".
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'LastName' не должно быть пустым.")]
		[Test]
		public void Create_EmptyFullName_ReturnException()
		{
			_student.LastName = null;
			_studentService.Create(_student);
		}

		/// <summary>
		/// Создает студента с пустым полем "FirstName".
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'FirstName' не должно быть пустым.")]
		[Test]
		public void Create_EmptyShortName_ReturnException()
		{
			_student.FirstName = null;
			_studentService.Create(_student);
		}

		/// <summary>
		/// Создает студента с пустым полем "FatherName".
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'FatherName' не должно быть пустым.")]
		[Test]
		public void Create_EmptyShortName_ReturnException()
		{
			_student.FatherName = null;
			_studentService.Create(_student);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Исключение студента из группы.
		/// </summary>
		[Test]
		public void Delete_Void_Success()
		{
			_studentService.Delete(_student);
		}

		#endregion

		#region GetListByTeam

		/// <summary>
		/// Получает список студентов по индетификатору группы.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnTaskList()
		{
			var list = new List<StudentItem> { _student };

			Mock.Get(_studentRepository).Setup(x => x.GetListByTeam(_student.TeamId)).Returns(list);
			var result = _studentService.GetListByTeam(_student.TeamId);

			Assert.AreEqual(result.Count, list.Count);
		}

		#endregion

	}
}