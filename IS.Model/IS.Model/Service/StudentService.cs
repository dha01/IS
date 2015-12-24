using System;
using System.Collections.Generic;
using System.Linq;
using IS.Model.Item.Person;
using IS.Model.Item.Team;
using IS.Model.Repository.Person;
using IS.Model.Repository.Team;

namespace IS.Model.Service
{
	/// <summary>
	/// Сервис для работы со студентами.
	/// </summary>
	public class StudentService
	{
		#region Fields

		/// <summary>
		/// Репозиторий студентов.
		/// </summary>
		private IStudentRepository _studentRepository;

		#endregion

		#region Constructors

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		public StudentService()
		{
			_studentRepository = new StudentRepository();
		}

		/// <summary>
		/// Конструктор класс.
		/// </summary>
		/// <param name="cathedra_repository">Интерфейс репозитория кафедр.</param>
		public StudentService(IStudentRepository student_repository)
		{
			_studentRepository = student_repository;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Получает студента по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Задача.</returns>
		public StudentItem GetById(int id)
		{
			return _studentRepository.Get(id);
		}

		/// <summary>
		/// Зачисляет студента в группу.
		/// </summary>
		/// <param name="cathedra">Студенты.</param>
		/// <returns>Идентификатор созданной задачи.</returns>
		public int Create(StudentItem student)
		{
			return _studentRepository.Create(student);
		}

		/// <summary>
		/// Удаляет кафедру.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(StudentItem student)
		{
			_studentRepository.Delete(student);
		}

		/// <summary>
		/// Получает список студентов по индетификатору группы.
		/// </summary>
		public List<StudentItem> GetListByTeam(int team_id)
		{
			return _studentRepository.GetListByTeam(team_id);
		}

		#endregion
	}
}