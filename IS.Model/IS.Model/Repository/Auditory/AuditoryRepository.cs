﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Model.Item.Auditory;
using IS.Model.Helper;

namespace IS.Model.Repository.Auditory
{
    /// <summary>
    /// Класс репозитория аудиторий.
    /// </summary>
    public class AuditoryRepository : IAuditoryRepository
    {
        /// <summary>
        /// Получает аудиторию по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns>Аудитория.</returns>
        public AuditoryItem Get(int id)
        {
            using (var sqlh = new SqlHelper())
            {
                return sqlh.ExecMapping<AuditoryItem>(@"
select
	a.auditory Id,
	a.number Number,
	a.full_name FullName,
	a.memo Memo,
	a.level Level,
	a.capacity Capacity
from Auditory.auditory a
where a.auditory = @id", new { id });
            }
        }

        /// <summary>
        /// Обновляет данные по аудитории.
        /// </summary>
        /// <param name="auditory">Аудитория.</param>
        public void Update(AuditoryItem auditory)
        {

        }

        /// <summary>
        /// Создает новую аудиторию.
        /// </summary>
        /// <param name="auditory">Аудитория.</param>
        /// <returns>Идентификатор созданной аудитории.</returns>
        public int Create(AuditoryItem auditory)
        {
            return 0;
        }

        /// <summary>
        /// Удаляет аудиторию.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        public void Delete(int id)
        {

        }

        /// <summary>
        /// Получает список всех аудиторий.
        /// </summary>
        /// <returns>Список аудиторий.</returns>
        public List<AuditoryItem> GetList()
        {
            return null;
        }
    }
}
