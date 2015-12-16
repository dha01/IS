using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS.Model.Item.Cathedra;
using IS.Model.Service;
using IS.Mvc.Models;

namespace IS.Mvc.Controllers
{
	/// <summary>
	/// Контролер для работы с данными у кафедры.
	/// </summary>
	public class CathedraController : Controller
	{

		private CathedraService _cathedraService;

		/// <summary>
		/// Конструктор контроллера людей.
		/// </summary>
		public CathedraController()
		{
			_cathedraService = new CathedraService();
		}

		/// <summary>
		/// Список кафедр.
		/// </summary>
		/// <returns></returns>
		public ActionResult List()
		{
			Access.CheckAccess("Cathedra.Reader");
			return View("List", _cathedraService.GetList().OrderBy(x => x.FullName).ThenBy(x => x.ShortName).ToList());
		}

		/// <summary>
		/// Страница с кафедрой. Если идентификатор не указан перенаправляет на список кафедр.
		/// </summary>
		/// <param name="id">Идентификатор кафедры.</param>
		/// <returns></returns>
		public ActionResult Index(int? id)
		{
			Access.CheckAccess("Cathedra.Reader");
			if (id.HasValue)
			{
				return View("Index", _cathedraService.GetById(id.Value));
			}
			else
			{
				return RedirectToAction("List");
			}
		}

		/// <summary>
		/// Создает новую кафедру.
		/// </summary>
		/// <returns></returns>
		[ValidateInput(false)]
		public ActionResult Create(CathedraItem cathedra)
		{
			Access.CheckAccess("Cathedra.Creator");
			return RedirectToAction("Index", new { id = _cathedraService.Create(cathedra) });
		}

		/// <summary>
		/// Интерфейс для создания кафедры.
		/// </summary>
		/// <returns></returns>
		public ActionResult New()
		{
			Access.CheckAccess("Cathedra.Creator");
			var default_item = new CathedraItem
			{
				FullName = "",
				ShortName = ""
			};
			return View(default_item);
		}

		/// <summary>
		/// Сохраняет измменения у кафедры.
		/// </summary>
		/// <returns></returns>
		[ValidateInput(false)]
		public ActionResult Update(CathedraItem cathedra)
		{
			Access.CheckAccess("Cathedra.Updater");
			_cathedraService.Update(cathedra);
			return RedirectToAction("Index", new { id = cathedra.Id });
		}

		/// <summary>
		/// Интерфейс для редактирования кафедры.
		/// </summary>
		/// <returns></returns>
		public ActionResult Edit(int id)
		{
			Access.CheckAccess("Cathedra.Updater");
			return View(_cathedraService.GetById(id));
		}

		/// <summary>
		/// Удаление кафедры.
		/// </summary>
		/// <returns></returns>
		public ActionResult Delete(int id)
		{
			Access.CheckAccess("Cathedra.Deleter");
			_cathedraService.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
