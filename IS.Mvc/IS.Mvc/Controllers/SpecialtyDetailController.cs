using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS.Model.Item.Specialty;
using IS.Model.Service;
using IS.Mvc.Models;

namespace IS.Mvc.Controllers
{
	/// <summary>
	/// Контролер для работы с данными по учебным курсам.
	/// </summary>
	public class SpecialtyDetailController : Controller
	{
		private SpecialtyDetailService _specialtyDetailService;
		/// <summary>
		/// Создание сервиса учебных курсов.
		/// </summary>
		public SpecialtyDetailController()
		{
			_specialtyDetailService = new SpecialtyDetailService();
		}

		/// <summary>
		/// Страница с учебным курсом. Если идентификатор не указан перенаправляет на список учебных курсов.
		/// </summary>
		/// <param name="id">Идентификатор учебного курса.</param>
		/// <returns></returns>
		public ActionResult Index(int? id)
		{
			Access.CheckAccess("SpecialtyDetail.Reader");
			if (id.HasValue)
			{
				return View("Index", _specialtyDetailService.GetById(id.Value));
			}
			else
			{
				return RedirectToAction("List");
			}
		}

		/// <summary>
		/// Список учебных курсов.
		/// </summary>
		/// <returns></returns>
		public ActionResult List()
		{
			Access.CheckAccess("SpecialtyDetail.Reader");
			return View("List", _specialtyDetailService.GetList());
		}

		/// <summary>
		/// Создает новый учебный курс.
		/// </summary>
		/// <returns></returns>
		[ValidateInput(false)]
		public ActionResult Create(SpecialtyDetailItem specialty_detail)
		{
			Access.CheckAccess("SpecialtyDetail.Creator");
			return RedirectToAction("List", new { id = _specialtyDetailService.Create(specialty_detail) });
		}

		/// <summary>
		/// Интерфейс для создания учебного курса.
		/// </summary>
		/// <returns></returns>
		public ActionResult New()
		{
			Access.CheckAccess("SpecialtyDetail.Creator");
			var defaultitem = new SpecialtyDetailItem();
			
			return View(defaultitem);
		}

		/// <summary>
		/// Сохраняет изменения в учебном курсе.
		/// </summary>
		/// <returns></returns>
		[ValidateInput(false)]
		public ActionResult Update(SpecialtyDetailItem specialty_detail)
		{
			Access.CheckAccess("SpecialtyDetail.Updater");
			_specialtyDetailService.Update(specialty_detail);
			return RedirectToAction("Index", new { id = specialty_detail.Id });
			
		}


		/// <summary>
		/// Интерфейс для редактирования учебного курса.
		/// </summary>
		/// <returns></returns>
		public ActionResult Edit(int id)
		{
			Access.CheckAccess("SpecialtyDetail.Updater");
			return View(_specialtyDetailService.GetById(id));

		}

		/// <summary>
		/// Интерфейс для удаления учебного курса.
		/// </summary>
		/// <returns></returns>
		public ActionResult Delete(int id)
		{
			Access.CheckAccess("SpecialtyDetail.Deleter");
			_specialtyDetailService.Delete(id);
			return RedirectToAction("Index");
		}

	}
}