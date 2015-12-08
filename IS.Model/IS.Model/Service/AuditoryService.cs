using System;
using System.Collections.Generic;
using System.Linq;
using IS.Model.Item.Auditory;
using IS.Model.Repository.Auditory;

namespace IS.Model.Service
{
	/// <summary>
	/// Сервис для работы с аудиториями.
	/// </summary>
	public class AuditoryService
	{
		#region Fields
		
		/// <summary>
		/// Репозиторий задач.
		/// </summary>
		private IAuditoryRepository _auditoryRepository;

		#endregion

		#region Constructors

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		public AuditoryService()
		{
			_auditoryRepository = new AuditoryRepository();
		}

		/// <summary>
		/// Конструктор класс.
		/// </summary>
		/// <param name="auditory_repository">Интерфейс репозитория аудиторий.</param>
		public AuditoryService(IAuditoryRepository auditory_repository)
		{
			_auditoryRepository = auditory_repository;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Получает аудиторию по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Аудитория.</returns>
		public AuditoryItem GetById(int id)
		{
			return _auditoryRepository.Get(id);
		}

		/// <summary>
		/// Создает аудиторию.
		/// </summary>
		/// <param name="auditory">Аудитория.</param>
		/// <returns>Идентификаторо созданной задачи.</returns>
		public int Create(AuditoryItem auditory)
		{/*a.auditory Id,
	a.number Number,
	a.full_name FullName,
	a.memo Memo,
	a.level Level,
	a.capacity Capacity*/
		}

		/// <summary>
		/// Измененяет данные об аудитории.
		/// </summary>
		/// <param name="auditory">Аудитория.</param>
		public void Update(AuditoryItem auditory)
		{

		}

		/// <summary>
		/// Удаляет аудиторию.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			_auditoryRepository.Delete(id);
		}


		/// <summary>
		/// Получает список аудиторий.
		/// </summary>
		public List<AuditoryItem> GetList()
		{
			return _auditoryRepository.GetList();
		}


		#endregion
	}
}
