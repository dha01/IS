using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS.Model.Item.Person;
using IS.Model.Service;
using IS.Mvc.Models;

namespace IS.Mvc.Controllers
{
	public class PersonController : Controller
	{

		private PersonService _personService;
		
		public PersonController()
		{
			_personService = new PersonService();
		}

		/// <summary>
		/// Список людей.
		/// </summary>
		/// <returns></returns>
		public ActionResult List()
		{
			return View("List", _personService.GetList().OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList());
		}

		/// <summary>
		/// Страница с челоеком. Если идентификатор не указан перенаправляет на список людей.
		/// </summary>
		/// <param name="id">Идентификатор человека.</param>
		/// <returns></returns>
		public ActionResult Index(int? id)
		{
			if (id.HasValue)
			{
				return View("Index", _personService.GetById(id.Value));
			}
			else
			{
				return RedirectToAction("List");
			}
		}

		/// <summary>
		/// Создает нового человека.
		/// </summary>
		/// <returns></returns>
		[ValidateInput(false)]
		public ActionResult Create(PersonItem person)
		{
			//Access.CheckAccess("Person.Creator");
			return RedirectToAction("Index", new { id = _personService.Create(person) });
		}

		/// <summary>
		/// Интерфейс для создания человека.
		/// </summary>
		/// <returns></returns>
		public ActionResult New()
		{
			//Access.CheckAccess("Person.Creator");
			var default_item = new PersonItem
			{
				LastName = "Иванов",
				FirstName = "Иван",
				FatherName = "Иванович"
			};
			return View(default_item);
		}

		/// <summary>
		/// Сохраняет измменения у человека.
		/// </summary>
		/// <returns></returns>
		[ValidateInput(false)]
		public ActionResult Update(PersonItem person)
		{
			//Access.CheckAccess("Person.Updater");
			_personService.Update(person);
			return RedirectToAction("Index", new { id = person.Id });
		}

		/// <summary>
		/// Интерфейс для редактирования человека.
		/// </summary>
		/// <returns></returns>
		public ActionResult Edit(int id)
		{
			//Access.CheckAccess("Task.Updater");
			return View(_personService.GetById(id));
		}
	}
}