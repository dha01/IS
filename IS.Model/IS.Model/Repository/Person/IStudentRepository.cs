using System.Collections.Generic;
using IS.Model.Item.Person;

namespace IS.Model.Repository.Person
{
	/// <summary>
	/// Интерфейс репозитория студентов.
	/// </summary>
	public interface IStudentRepository : IRepository<StudentItem>
	{
		/// <summary>
		/// Получает студента по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Список студентов.</returns>
		StudentItem Get(int id);

		/// <summary>
		/// Обновляет данные о студентах.
		/// </summary>
		/// <param name="student">Список студентов.</param>
		void Update(StudentItem student);

		/// <summary>
		/// Зачисление студента в группу.
		/// </summary>
		/// <param name="student">Список студентов.</param>
		/// <returns>Идентификатор зачисленных студентов.</returns>
		int Create(StudentItem student);

		/// <summary>
		/// Исключение студента из группы.
		/// </summary>
		/// <param name="student">Список студентов.</param>
		void Delete(StudentItem student);

		/// <summary>
		/// Получает список всех студентов.
		/// </summary>
		/// <returns>Список студентов.</returns>
		List<StudentItem> GetList();

		/// <summary>
		/// Получает список студентов по индетификатору группы.
		/// </summary>
		/// <param name="team_id">Список студентов.</param>
		List<StudentItem> GetListByTeam( int team_id );
	}
}