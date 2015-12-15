using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Model.Item.Access;
using IS.Model.Item.Team;

namespace IS.Model.Item.Info
{
	/// <summary>
	/// Класс для хранения данных о сущности специальности.
	/// </summary>
	public class SpecialtyInfoItem : UserItem
	{
		/// <summary>
		/// Список групп.
		/// </summary>
		public List<TeamItem> TeamList { get; set; }
	}
}
