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
	/// <summary>
	/// Контролер для работы с данными студентов.
	/// </summary>
	public class StudentController : Controller
	{

		private StudentService _studentService;

		/// <summary>
		/// Конструктор контроллера студентов.
		/// </summary>
        public StudentController()
		{
            _studentService = new StudentService();
		}

		/// <summary>
		/// Список студентов.
		/// </summary>
		/// <returns></returns>
		public ActionResult List(int team_id)
		{
            Access.CheckAccess("Student.Reader");
			return View("List", _studentService.GetListByTeam(team_id));
		}

		/// <summary>
		/// Страница со студентами. Если идентификатор не указан перенаправляет на список студентов.
		/// </summary>
		/// <param name="id">Идентификатор студентов.</param>
		/// <returns></returns>
		public ActionResult Index(int? id)
		{
            Access.CheckAccess("Student.Reader");
			if (id.HasValue)
			{
				return View("Index", _studentService.GetById(id.Value));
			}
			else
			{
				return RedirectToAction("List");
			}
		}

		/// <summary>
        /// Зачисление студента в группу.
		/// </summary>
		/// <returns></returns>
		[ValidateInput(false)]
        public ActionResult Create(StudentItem student)
		{
            Access.CheckAccess("Student.Creator");
			return RedirectToAction("Index", new { id = _studentService.Create(student) });
		}

		/// <summary>
        /// Интерфейс для зачисления студента в группу.
		/// </summary>
		/// <returns></returns>
		public ActionResult New()
		{
            Access.CheckAccess("Student.Creator");
            var default_item = new StudentItem
			{
                LastName = "",
                FirstName = "",
				FatherName = ""
			};
			return View(default_item);
		}

		/// <summary>
		/// Интерфейс для редактирования данных о студенте.
		/// </summary>
		/// <returns></returns>
		public ActionResult Edit(int id)
		{
			Access.CheckAccess("Student.Updater");
			return View(_studentService.GetById(id));
		}

		/// <summary>
        /// Исключение студента из группы.
		/// </summary>
		/// <returns></returns>
        public ActionResult Delete(StudentItem student)
		{
            Access.CheckAccess("Student.Deleter");
			_studentService.Delete(student);
			return RedirectToAction("Index");
		}
	}
}
