using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Model.Item.Access;
using IS.Model.Item.Specialty;

namespace IS.Model.Repository.Specialty
{
	
		/// <summary>
		/// Интерфейс репозитория специальностей.
		/// </summary>
		public interface ISpecialtyRepository : IRepository<SpecialtyItem>
		{
			/// <summary>
			/// Получает специальность по идентификатору.
			/// </summary>
			/// <param name="id">Идентификатор.</param>
			/// <returns>Специальность.</returns>
			SpecialtyItem Get(int id);

			/// <summary>
			/// Обновляет данные по специальности.
			/// </summary>
			/// <param name="specialty">Специальность.</param>
			void Update(SpecialtyItem specialty);

			/// <summary>
			/// Создает новую специальность.
			/// </summary>
			/// <param name="specialty">Специальность.</param>
			/// <returns>Идентификатор созданной специальности.</returns>
			int Create(SpecialtyItem specialty);

			/// <summary>
			/// Удаляет специальность.
			/// </summary>
			/// <param name="id">Идентификатор.</param>
			void Delete(int id);
		}
}

