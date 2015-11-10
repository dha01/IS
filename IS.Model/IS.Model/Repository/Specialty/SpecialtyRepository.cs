using IS.Model.Helper;
using IS.Model.Item.Specialty;

namespace IS.Model.Repository.Specialty
{
	/// <summary>
	/// Интерфейс репозитория специальностей.
	/// </summary>
	public class SpecialtyRepository : ISpecialtyRepository
	{
		/// <summary>
		/// Получает специальность по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Специальность.</returns>
		public SpecialtyItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<SpecialtyItem>(@"
select
	s.specialty Id,
	s.full_name FullName,
	s.short_name ShortName,
	s.code Code
from Specialty.specialty s
where s.specialty = @id", new { id });
			}
		}

		/// <summary>
		/// Обновляет данные по специальности.
		/// </summary>
		/// <param name="specialty">Специальность.</param>
		public void Update(SpecialtyItem specialty)
		{

		}

		/// <summary>
		/// Создает новую специальность.
		/// </summary>
		/// <param name="specialty">Специальность.</param>
		/// <returns>Идентификатор созданной специальности.</returns>
		public int Create(SpecialtyItem specialty)
		{
			return 0;
		}

		/// <summary>
		/// Удаляет специальность.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{

		}
	} 
}

