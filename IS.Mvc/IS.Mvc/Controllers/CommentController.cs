using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS.Model.Item.Comment;
using IS.Model.Service;
using IS.Mvc.Models;

namespace IS.Mvc.Controllers
{
	/// <summary>
	/// Контролер для работы с данными по комментариям.
	/// </summary>
	public class CommentController : Controller
	{
		private CommentService _commentService;

		public CommentController()
		{
			_commentService = new CommentService();
		}

		/// <summary>
		/// Создает новый комментарий.
		/// </summary>
		/// <returns></returns>
		[ValidateInput(false)]
		public JsonResult SendMessage(CommentItem comment)
		{
			 var id = _commentService.Create(comment);
			 return Json(new { success = true, id, is_deleter = Access.CheckRole("Comment.Deleter") }, JsonRequestBehavior.AllowGet);
		}

		/// <summary>
		/// Удаляет комментарий.
		/// </summary>
		/// <returns></returns>
		[ValidateInput(false)]
		public JsonResult Delete(int comment_id)
		{
			_commentService.Delete(comment_id);
			return Json(new { success = true}, JsonRequestBehavior.AllowGet);
		}
	}
}
