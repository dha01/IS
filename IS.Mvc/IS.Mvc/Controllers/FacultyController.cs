using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS.Model.Item.Faculty;
using IS.Model.Service;
using IS.Mvc.Models;

namespace IS.Mvc.Controllers
{
	/// <summary>
	/// Контролер для работы с данными по факультетам.
	/// </summary>
	public class FacultyController : Controller
	{
		private FacultyService _facultyService;
		/// <summary>
		/// Конструктор контроллера факультетов.
		/// </summary>
		public FacultyController()
		{
			_facultyService = new FacultyService();
		}

		/// <summary>
		/// Список факультетов.
		/// </summary>
		/// <returns></returns>
		public ActionResult List()
		{
			Access.CheckAccess("Faculty.Reader");
			return View("List", _facultyService.GetList().OrderBy(x => x.ShortName).ThenBy(x => x.FullName).ToList());
		}

		/// <summary>
		/// Страница факультета. Если идентификатор не указан, то перенаправляет на список факультетов.
		/// </summary>
		/// <param name="id">Идентификатор факультета.</param>
		/// <returns></returns>
		public ActionResult Index(int? id)
		{
			Access.CheckAccess("Faculty.Reader");
			if (id.HasValue)
			{
				return View("Index", _facultyService.GetById(id.Value));
			}
			else
			{
				return RedirectToAction("List");
			}
		}
		
		/// <summary>
		/// Создает новую запись о факультете.
		/// </summary>
		/// <returns></returns>
		[ValidateInput(false)]
		public ActionResult Create(FacultyItem faculty)
		{
			Access.CheckAccess("Faculty.Creator");
			return RedirectToAction("Index", new { id = _facultyService.Create(faculty) });
		}

		/// <summary>
		/// Интерфейс для создания записи о факультете.
		/// </summary>
		/// <returns></returns>
		public ActionResult New()
		{
			Access.CheckAccess("Faculty.Creator");
			var default_item = new FacultyItem
			{
				FullName = "",
				ShortName = ""
			};
			return View(default_item);
		}

		/// <summary>
		/// Сохраняет изменения в записи о факультете.
		/// </summary>
		/// <returns></returns>
		[ValidateInput(false)]
		public ActionResult Update(FacultyItem faculty)
		{
			Access.CheckAccess("Faculty.Updater");
			_facultyService.Update(faculty);
			return RedirectToAction("Index", new { id = faculty.Id });
		}

		/// <summary>
		/// Интерфейс для редактирования записи о факультете.
		/// </summary>
		/// <returns></returns>
		public ActionResult Edit(int id)
		{
			Access.CheckAccess("Faculty.Updater");
			return View(_facultyService.GetById(id));
		}

		/// <summary>
		/// Удаление записи о факультете.
		/// </summary>
		/// <returns></returns>
		public ActionResult Delete(int id)
		{
			Access.CheckAccess("Faculty.Deleter");
			_facultyService.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
