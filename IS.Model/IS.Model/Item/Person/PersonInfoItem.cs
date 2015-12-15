using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Model.Item.Contact;
 
namespace IS.Model.Item.Person
{
    /// <summary>
    /// Расширенный класс для хранения контактов людей.
    /// </summary>
    public class PersonInfoItem : PersonItem
    {
        /// <summary>
		/// Список контактов.
		/// </summary>
		public List<ContactItem> ContactsList { get; set; }
    }
}
