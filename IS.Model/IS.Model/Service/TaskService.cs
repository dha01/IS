using System;
using System.Collections.Generic;
using System.Linq;
using IS.Model.Item.Task;
using IS.Model.Repository.Task;
using IS.Model.Service;
using IS.Model.Repository.Comment;
using IS.Model.Item.TaskInfo;

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

		/// <summary>
		/// Репозиторий комментариев.
		/// </summary>
		private ICommentRepository _commentRepository;

		#endregion

		#region Constructors

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		public TaskService()
		{
			_taskRepository = new TaskRepository();

			_commentRepository = new CommentRepository();
		}

		/// <summary>
		/// Конструктор класс.
		/// </summary>
		/// <param name="task_repository">Интерфейс репозитория задач.</param>
		/// <param name="comment_repository">Интерфейс репозитория задач.</param>
		public TaskService(ITaskRepository task_repository, ICommentRepository comment_repository)
		{
			_taskRepository = task_repository;

			_commentRepository = comment_repository;
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
		/// Создает задачу.
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

			var list = GetList().FindAll(x => x.Prefix == task.Prefix);
			if (list.Any())
			{
				task.Number = GetList().FindAll(x => x.Prefix == task.Prefix).Max(y => y.Number) + 1;
			}
			else
			{
				task.Number = 1;
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
		/// Меняет статус задачи задачу.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <param name="is_perform"></param>
		/// <param name="is_open"></param>
		public void SetState(int id, bool is_perform, bool is_open)
		{
			var task = _taskRepository.Get(id);
			task.IsPerform = is_perform;
			task.IsOpen = is_open;
			_taskRepository.Update(task);
		}

		/// <summary>
		/// Получает список задач.
		/// </summary>
		public List<TaskItem> GetList()
		{
			return _taskRepository.GetList();
		}

		/// <summary>
		/// Собирает статистику по выполненым задачам.
		/// </summary>
		/// <returns></returns>
		public Dictionary<string, int> Statistic()
		{
			var list = GetList().FindAll(x => x.Performer != null/* && x.IsPerform*/ && x.Prefix == TaskPrefix.Task);
			var stat = new Dictionary<string, int>();

			foreach (var group in list.GroupBy(x=>x.Performer).OrderBy(y => y.Key))
			{
				stat.Add(group.Key, group.Sum(x => x.Difficult));
			}
			return stat;
		}

		/// <summary>
		/// Получает основные данные и заполняет список комментариев.
		/// </summary>
		/// <param name="task_id">Идентификатор задачи.</param>
		/// <returns>Расширенные данные о задаче.</returns>
		public TaskInfoItem GetTaskInfoById(int task_id)
		{
			var task = _taskRepository.Get(task_id);

			var info = new TaskInfoItem()
			{
				Id = task.Id,
				Author = task.Author,
				Deadline = task.Deadline,
				Created = task.Created,
				Performer = task.Performer,
				Header = task.Header,
				IsOpen = task.IsOpen,
				IsPerform = task.IsPerform,
				Mem = task.Mem,
				Number = task.Number,
				Priority = task.Priority,
				Prefix = task.Prefix,
				PullRequestUrl = task.PullRequestUrl,
				CommentList = _commentRepository.GetListByTaskId(task_id)
			};

			return info;
		}

		#endregion
	}
}
