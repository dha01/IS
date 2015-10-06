using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS.Model.Item.Task;
using IS.Model.Service;
using IS.Mvc.Models;

namespace IS.Mvc.Controllers
{
    /// <summary>
    /// Контролер для работы с данными по задачам.
    /// </summary>
	public class TaskController : Controller
    {
	    private TaskService _taskService;
		
		public TaskController()
	    {
		    _taskService = new TaskService();
	    }
		
		/// <summary>
		/// Страница с задачей. Если идентификатор не указан перенаправляет на список задач.
		/// </summary>
		/// <param name="task"></param>
		/// <returns></returns>
		public ActionResult Index(int? id)
        {
			if (id.HasValue)
	        {
				return View("Index", _taskService.GetById(id.Value));
	        }
	        else
	        {
				return RedirectToAction("List");
	        }
        }

		/// <summary>
		/// Список задач.
		/// </summary>
		/// <returns></returns>
		public ActionResult List()
		{
			return View("List", _taskService.GetList());
		}

		/// <summary>
		/// Создает новую задачу.
		/// </summary>
		/// <returns></returns>
		public ActionResult Create(TaskItem task)
		{
			Access.CheckAccess("Task.Creator");
			return RedirectToAction("Index", new { id = _taskService.Create(task) });
		}

		/// <summary>
		/// Интерфейс для создания задачи.
		/// </summary>
		/// <returns></returns>
		public ActionResult New()
		{
			Access.CheckAccess("Task.Creator");
			return View();
		}

		/// <summary>
		/// Сохраняет измменения в здаче.
		/// </summary>
		/// <returns></returns>
		public ActionResult Update(TaskItem task)
		{
			Access.CheckAccess("Task.Updater");
			_taskService.Update(task);
			return RedirectToAction("Index", new { id = task.Id });
		}

		/// <summary>
		/// Интерфейс для редактирования задачи.
		/// </summary>
		/// <returns></returns>
		public ActionResult Edit(int id)
		{
			Access.CheckAccess("Task.Updater");
			return View(_taskService.GetById(id));
		}

		/// <summary>
		/// Интерфейс для редактирования задачи.
		/// </summary>
		/// <returns></returns>
		public ActionResult Delete(int id)
		{
			Access.CheckAccess("Task.Deleter");
			_taskService.Delete(id);
			return RedirectToAction("Index");
		}
    }
}
