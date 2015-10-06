﻿using System;
using System.Collections.Generic;
using IS.Model.Item.Task;
using IS.Model.Repository.Task;

namespace IS.Model.Service
{
	/// <summary>
	/// Сервис для работы с задачами.
	/// </summary>
	public class TaskService
	{
		#region Fields
		
		/// <summary>
		/// Репозиторий задач.
		/// </summary>
		private ITaskRepository _taskRepository;

		#endregion

		#region Constructors

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		public TaskService()
		{
			_taskRepository = new TaskRepository();
		}

		/// <summary>
		/// Конструктор класс.
		/// </summary>
		/// <param name="task_repository">Интерфейс репозитория задач.</param>
		public TaskService(ITaskRepository task_repository)
		{
			_taskRepository = task_repository;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Получает задачу по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Задача.</returns>
		public TaskItem GetById(int id)
		{
			return _taskRepository.Get(id);
		}

		/// <summary>
		/// Создает пользователя.
		/// </summary>
		/// <param name="task">Задача.</param>
		/// <returns>Идентификаторо созданной задачи.</returns>
		public int Create(TaskItem task)
		{
			if (string.IsNullOrEmpty(task.Header))
			{
				throw new Exception("Поле 'Header' не должно быть пустым.");
			}

			if (string.IsNullOrEmpty(task.Mem))
			{
				throw new Exception("Поле 'Mem' не должно быть пустым.");
			}

			return _taskRepository.Create(task);
		}

		/// <summary>
		/// Измененяет данные о задаче.
		/// </summary>
		/// <param name="task">Задача.</param>
		public void Update(TaskItem task)
		{
			if (string.IsNullOrEmpty(task.Header))
			{
				throw new Exception("Поле 'Header' не должно быть пустым.");
			}

			if (string.IsNullOrEmpty(task.Mem))
			{
				throw new Exception("Поле 'Mem' не должно быть пустым.");
			}

			if (GetById(task.Id) == null)
			{
				throw new Exception("Задача не найдена.");
			}

			_taskRepository.Update(task);
		}

		/// <summary>
		/// Удаляет задачу.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			_taskRepository.Delete(id);
		}

		/// <summary>
		/// Получает список задач.
		/// </summary>
		public List<TaskItem> GetList()
		{
			return _taskRepository.GetList();
		}

		#endregion
	}
}
