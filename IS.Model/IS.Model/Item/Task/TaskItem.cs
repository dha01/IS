using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IS.Model.Item.Task
{
	public class TaskItem
	{
		public int Id { get; set; }
		public int TaskType { get; set; }
		public int TaskNum { get; set; }
		public string Header { get; set; }
		public string Mem { get; set; }
		public string Executor { get; set; }
		public int Difficult { get; set; }
		public bool Complite { get; set; }
	}
}
