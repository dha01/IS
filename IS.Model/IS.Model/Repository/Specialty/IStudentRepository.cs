using System.Collections.Generic;
using IS.Model.Item.Student;

namespace IS.Model.Repository.Student
{
	/// <summary>
	/// Интерфейс репозитория студентов.
	/// </summary>
	public interface IStudentRepository : IRepository<StudentItem>
	{
		/// <summary>
		/// Получает список студентов по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Задача.</returns>
		StudentItem Get(int id);

		/// <summary>
		/// Обновляет данные по студентам.
		/// </summary>
		/// <param name="student">Студенты.</param>
		void Update(StudentItem student);

		/// <summary>
		/// Добаляет данные о новых студентах.
		/// </summary>
		/// <param name="student">Студенты.</param>
		/// <returns>Идентификатор созданных студентов.</returns>
		int Create(StudentItem student);

		/// <summary>
		/// Удаляет данные о студентах.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		void Delete(int id);

		/// <summary>
		/// Получает список всех студентов.
		/// </summary>
		/// <returns>Список студентов.</returns>
		List<StudentItem> GetList();
	}
}