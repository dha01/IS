using System.Collections.Generic;
using IS.Model.Item.Access;
using IS.Model.Item.Student;

namespace IS.Model.Repository.Student
{
	/// <summary>
	/// Интерфейс репозитория задач.
	/// </summary>
	public interface ITaskRepository : IRepository<StudentItem>
	{
		/// <summary>
		/// Получает задачу по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Задача.</returns>
		StudentItem Get(int id);

		/// <summary>
		/// Обновляет данные по задаче.
		/// </summary>
		/// <param name="student">Задача.</param>
		void Update(StudentItem student);

		/// <summary>
		/// Создает новую задачу.
		/// </summary>
		/// <param name="student">Задача.</param>
		/// <returns>Идентификатор созданной задачи.</returns>
		int Create(StudentItem student);

		/// <summary>
		/// Удаляет задачу.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		void Delete(int id);

		/// <summary>
		/// Получает список всех задач.
		/// </summary>
		/// <returns>Список задач.</returns>
		List<StudentItem> GetList();
	}
}