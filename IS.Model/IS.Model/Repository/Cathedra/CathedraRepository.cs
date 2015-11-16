using System.Collections.Generic;
using IS.Model.Helper;
using IS.Model.Item.Cathedra;

namespace IS.Model.Repository.Cathedra
{
    /// <summary>
    /// Интерфейс репозитория кафедр.
    /// </summary>
    public class CathedraRepository : ICathedraRepository
    {
        /// <summary>
        /// Получает кафедру по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Кафедра.</returns>
        public CathedraItem Get(int id)
        {
            using (var sqlh = new SqlHelper())
            {
                return sqlh.ExecMapping<CathedraItem>(@"
select
	d.сathedra Id,
	d.full_name FullName,
	d.short_name ShortName
from Cathedra.сathedra d
where d.сathedra = @id", new { id });
            }
        }

        /// <summary>
        /// Обновляет данные у кафедры.
        /// </summary>
        /// <param name="person">Кафедра.</param>
        void Update(CathedraItem сathedra);

        /// <summary>
        /// Создает новую кафедру.
        /// </summary>
        /// <param name="сathedra">Кафедра.</param>
        /// <returns>Идентификатор созданной кафедры.</returns>
        int Create(CathedraItem сathedra);

        /// <summary>
        /// Удаляет кафедру.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        void Delete(int id);

        /// <summary>
        /// Получает список всех кафедр.
        /// </summary>
        /// <returns>Список кафедр.</returns>
        public List<CathedraItem> GetList()
        {
            using (var sqlh = new SqlHelper())
            {
                return sqlh.ExecMappingList<CathedraItem>(@"
select
	d.faculty Id,
	d.full_name FullName,
	d.short_name ShortName
from Cathedra.сathedra d");
            }
        }
    }
}