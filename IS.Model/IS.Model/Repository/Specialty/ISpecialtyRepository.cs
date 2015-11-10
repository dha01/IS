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
        }
}

