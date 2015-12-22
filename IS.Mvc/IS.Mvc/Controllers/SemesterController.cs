using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS.Model.Item.Calendar;
using IS.Model.Service;
using IS.Mvc.Models;

namespace IS.Mvc.Controllers
{
    /// <summary>
    /// Контролер для работы с данными у семестров.
    /// </summary>
    public class SemesterController : Controller
    {

        private SemesterService _semesterService;

        /// <summary>
        /// Конструктор контроллера семестров.
        /// </summary>
        public SemesterController()
        {
            _semesterService = new SemesterService();
        }

        /// <summary>
        /// Список семестров.
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            Access.CheckAccess("Semester.Reader");
            return View("List", _semesterService.GetList().OrderBy(x => x.FromDate).ThenBy(x => x.TrimDate).ToList());
        }

        /// <summary>
        /// Страница с семестром. Если идентификатор не указан перенаправляет на список семестров.
        /// </summary>
        /// <param name="id">Идентификатор семестра.</param>
        /// <returns></returns>
        public ActionResult Index(int? id)
        {
            Access.CheckAccess("Semester.Reader");
            if (id.HasValue)
            {
                return View("Index", _semesterService.GetById(id.Value));
            }
            else
            {
                return RedirectToAction("List");
            }
        }

        /// <summary>
        /// Создает новый семестер.
        /// </summary>
        /// <returns></returns>
        [ValidateInput(false)]
        public ActionResult Create(SemesterItem semester)
        {
            Access.CheckAccess("Semester.Creator");
            return RedirectToAction("Index", new { id = _semesterService.Create(semester) });
        }

        /// <summary>
        /// Интерфейс для создания семестра.
        /// </summary>
        /// <returns></returns>
        public ActionResult New()
        {
            Access.CheckAccess("Semester.Creator");
            var default_item = new SemesterItem
            {
                FromDate = DateTime.Now,
                TrimDate = DateTime.Now
            };
            return View(default_item);
        }

        /// <summary>
        /// Сохраняет измменения у семестра.
        /// </summary>
        /// <returns></returns>
        [ValidateInput(false)]
        public ActionResult Update(SemesterItem semester)
        {
            Access.CheckAccess("Semester.Updater");
            _semesterService.Update(semester);
            return RedirectToAction("Index", new { id = semester.Id });
        }

        /// <summary>
        /// Интерфейс для редактирования семестра.
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            Access.CheckAccess("Semester.Updater");
            return View(_semesterService.GetById(id));
        }

        /// <summary>
        /// Удаление семестра.
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            Access.CheckAccess("Semester.Deleter");
            _semesterService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
