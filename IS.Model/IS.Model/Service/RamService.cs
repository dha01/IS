using System;
using System.Collections.Generic;
using System.Linq;
using IS.Model.Item.Ram;
using IS.Model.Repository.Ram;
using IS.Model.Service;

namespace IS.Model.Service
{
	/// <summary>
	/// Сервис для работы с оперативной памятью.
	/// </summary>
	public class RamService
	{
		#region Fields
		
		/// <summary>
		/// Репозиторий единиц оперативной памяти.
		/// </summary>
		private IRamRepository _ramRepository;

		#endregion

		#region Constructors

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		public RamService()
		{
			_ramRepository = new RamRepository();
		}

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		public RamService(IRamRepository ram_repository)
		{
			//_ramRepository = new RamRepository();
			_ramRepository = ram_repository;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Получает единицу оперативной памяти по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Оперативная память.</returns>
		public RamItem GetById(int id)
		{
			return _ramRepository.Get(id);
		}

		/// <summary>
		/// Создает единицу оперативной памяти.
		/// </summary>
		/// <param name="ram">оперативная память.</param>
		/// <returns>Идентификатор созданной оперативной памяти.</returns>
		public int Create(RamItem ram)
		{
			if (string.IsNullOrEmpty(ram.Name))
			{
				throw new Exception("Поле 'Name' не должно быть пустым.");
			}

			return _ramRepository.Create(ram);
		}

		/// <summary>
		/// Измененяет данные об оперативной памяти.
		/// </summary>
		/// <param name="ram">Оперативная память.</param>
		public void Update(RamItem ram)
		{
			if (string.IsNullOrEmpty(ram.Name))
			{
				throw new Exception("Поле 'Name' не должно быть пустым.");
			}

			if (GetById(ram.Id) == null)
			{
				throw new Exception("Элемент не найден.");
			}

			_ramRepository.Update(ram);
		}

		/// <summary>
		/// Удаляет единицу оперативной памяти.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			_ramRepository.Delete(id);
		}

		/// <summary>
		/// Получает список единиц оперативной памяти.
		/// </summary>
		public List<RamItem> GetList()
		{
			return _ramRepository.GetList();
		}
		#endregion
	}
}
