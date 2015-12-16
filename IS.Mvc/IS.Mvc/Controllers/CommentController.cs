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
		public int SendMessage(CommentItem comment)
		{
			 _commentService.Create(comment);
			return 0;
		}
	}
}
