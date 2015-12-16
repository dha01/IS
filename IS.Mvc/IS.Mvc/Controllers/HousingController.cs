using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS.Model.Item.Housing;
using IS.Model.Item.Person;
using IS.Model.Service;
using IS.Mvc.Models;

namespace IS.Mvc.Controllers
{
	/// <summary>
	/// Контролер для работы с данными у корпуса.
	/// </summary>
	public class HousingController : Controller
	{

		private HousingService _housingService;

		/// <summary>
		/// Конструктор контроллера корпусов.
		/// </summary>
		public HousingController()
		{
			_housingService = new HousingService();
		}

		/// <summary>
		/// Список корпусов.
		/// </summary>
		/// <returns></returns>
		public ActionResult List()
		{
			Access.CheckAccess("Housing.Reader");
			return View("List", _housingService.GetList().OrderBy(x => x.Number).ThenBy(x => x.Number).ToList());
		}

		/// <summary>
		/// Страница с корпусом. Если идентификатор не указан перенаправляет на список корпусов.
		/// </summary>
		/// <param name="id">Идентификатор корпусо=а.</param>
		/// <returns></returns>
		public ActionResult Index(int? id)
		{
			Access.CheckAccess("Housing.Reader");
			if (id.HasValue)
			{
				return View("Index", _housingService.GetById(id.Value));
			}
			else
			{
				return RedirectToAction("List");
			}
		}

		/// <summary>
		/// Создает новый корпус.
		/// </summary>
		/// <returns></returns>
		[ValidateInput(false)]
		public ActionResult Create(HousingItem housing)
		{
			Access.CheckAccess("Housing.Creator");
			return RedirectToAction("Index", new { id = _housingService.Create(housing) });
		}

		/// <summary>
		/// Интерфейс для создания корпуса.
		/// </summary>
		/// <returns></returns>
		public ActionResult New()
		{
			Access.CheckAccess("Housing.Creator");
			
			return View();
		}

		/// <summary>
		/// Сохраняет измменения у корпуса.
		/// </summary>
		/// <returns></returns>
		[ValidateInput(false)]
		public ActionResult Update(HousingItem housing)
		{
			Access.CheckAccess("Housing.Updater");
			_housingService.Update(housing);
			return RedirectToAction("Index", new { id = housing.Id });
		}

		/// <summary>
		/// Интерфейс для редактирования корпуса.
		/// </summary>
		/// <returns></returns>
		public ActionResult Edit(int id)
		{
			Access.CheckAccess("Housing.Updater");
			return View(_housingService.GetById(id));
		}

		/// <summary>
		/// Удаление корпуса.
		/// </summary>
		/// <returns></returns>
		public ActionResult Delete(int id)
		{
			Access.CheckAccess("Housing.Deleter");
			_housingService.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
