using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Model.Helper;
using IS.Model.Item.Comment;

namespace IS.Model.Repository.Comment
{
	/// <summary>
	/// Интерфейс репозитория комментариев.
	/// </summary>
	public class CommentRepository : ICommentRepository
	{
		/// <summary>
		/// Получает комментарий по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Комментарий.</returns>
		public CommentItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<CommentItem>(@"
select
	c.comment Id,
	c.add_date AddDate,
	c.text_comment TextComment,
from Task.comment c
where c.comment = @id", new { id });
			}
		}

		/// <summary>
		/// Обновляет данные по комментарию.
		/// </summary>
		/// <param name="comment">Комментарий.</param>
		public void Update(CommentItem comment)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
update Task.comment
set
	add_date = @AddDate,
	text_comment = @TextComment,
where comment = @Id", comment);
			}
		}

		/// <summary>
		/// Создает новый комментарий.
		/// </summary>
		/// <param name="comment">Комментарий.</param>
		/// <returns>Идентификатор созданного комментария.</returns>
		public int Create(CommentItem comment)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into Task.comment
(
	add_date,
	text_comment,
)
values
(
	@AddDate,
	@TextComment,
)

select scope_identity()", comment);
			}
		}

		/// <summary>
		/// Удаляет комментарий.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			using (SqlHelper sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
delete from Task.comment
where comment = @id", new { id });
			}
		}

		/// <summary>
		/// Получает список всех комментариев.
		/// </summary>
		/// <returns>Список комментариев.</returns>
		public List<CommentItem> GetList()
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<CommentItem>(@"
select
	c.comment Id,
	c.add_date AddDate,
	c.text_comment TextComment,
from Task.comment c");
			}
		}
	}
}
