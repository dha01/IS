using System;
using IS.Model.Item.Task;
using IS.Model.Item.Comment;
using System.Collections.Generic;

namespace IS.Model.Item.TaskInfo
{
	/// <summary>
	/// Класс для хранения списка комментариев по задаче.
	/// </summary>
	public class TaskInfoItem : TaskItem
	{
		/// <summary>
		/// Список комментариев.
		/// </summary>
		public List<CommentItem> CommentList { get; set; }
	}
}
