using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Model.Item.Contact;

namespace IS.Model.Item.Cathedra
{
    /// <summary>
    /// Расширенный класс для хранения контактов кафедр.
    /// </summary>
    public class CathedraInfoItem : CathedraItem
    {
        /// <summary>
        /// Список контактов.
        /// </summary>
        public List<ContactItem> ContactsList { get; set; }
    }
}
