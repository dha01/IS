using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using IS.Model.Helper;
using IS.Model.Item.Contact;

namespace IS.Model.Repository.Contact
{
	/// <summary>
	/// Интерфейс репозитория контактов.
	/// </summary>
	public class ContactRepository : IContactRepository
	{
		/// <summary>
		/// Получает контакт по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Контакт.</returns>
		public ContactItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<ContactItem>(@"
select
	c.contact Id,
	t.code Type,
	c.value Value
from Contact.contact c
	join Contact.contact_type t on t.contact_type = c.contact_type
where c.contact = @id", new { id });
			}
		}

		/// <summary>
		/// Обновляет данные по контакту.
		/// </summary>
		/// <param name="contact">Контакт.</param>
		public void Update(ContactItem contact)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
update Contact.contact
set
	contact_type = (select top 1 t.contact_type from Contact.contact_type t where t.code = @Type),
	value = @Value
where contact = @Id", contact);
			}
		}

		/// <summary>
		/// Создает новый контакт.
		/// </summary>
		/// <param name="contact">Контакт.</param>
		/// <returns>Идентификатор созданного контакта.</returns>
		public int Create(ContactItem contact)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into Contact.contact
(
	contact_type,
	value
)
values
(
	(select top 1 t.contact_type from Contact.contact_type t where t.code = @Type),
	@Value
)

select scope_identity()", contact);
			}
		}

		/// <summary>
		/// Удаляет контакт.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			using (SqlHelper sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
delete from Contact.contact
where contact = @id", new { id });
			}
		}

		/// <summary>
		/// Получает список всех контактов.
		/// </summary>
		/// <returns>Список контактов.</returns>
		public List<ContactItem> GetList()
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<ContactItem>(@"
select
	c.contact Id,
	t.code Type,
	c.value Value
from Contact.contact c
	join Contact.contact_type t on t.contact_type = c.contact_type");
			}
		}

        /// <summary>
        /// Прикрепляет контакт к человеку.
        /// </summary>
        /// <param name="contact_id">Идентификатор контакта.</param>
        /// <param name="person_id">Идентификатор человека.</param>
        public void AttachContactToPerson(int contact_id, int person_id)
        {
            using (var sqlh = new SqlHelper())
            {
                sqlh.ExecNoQuery(@"
insert into Contact.contact2person
(
	contact,
	person
)
values
(
	@contact_id,
	@person_id
)", new { contact_id, person_id });
            }
        }
        
        /// <summary>
		/// Получает список всех контактов человека по его идентификатору.
		/// </summary>
		/// <returns>Список контактов.</returns>
		public List<ContactItem> GetContactsListByPersonId(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<ContactItem>(@"
select
	c.contact Id,
	t.code Type,
	c.value Value
from Contact.contact c
	join Contact.contact_type t on t.contact_type = c.contact_type
	join Contact.contact2person c2p on c2p.contact = c.contact
where c2p.person = @Id", new { id });
			}
		}

        /// <summary>
        /// Прикрепляет контакт к кафедре.
        /// </summary>
        /// <param name="contact_id">Идентификатор контакта.</param>
        /// <param name="cathedra_id">Идентификатор кафедры.</param>
        public void AttachContactToCathedra(int contact_id, int cathedra_id)
        {
            using (var sqlh = new SqlHelper())
            {
                sqlh.ExecNoQuery(@"
insert into Contact.contact2cathedra
(
	contact,
	cathedra
)
values
(
	@contact_id,
	@cathedra_id
)", new { contact_id, cathedra_id });
            }
        }

        /// <summary>
        /// Получает список всех контактов кафедры по ее идентификатору.
        /// </summary>
        /// <returns>Список контактов.</returns>
        public List<ContactItem> GetContactsListByCathedraId(int id)
        {
            using (var sqlh = new SqlHelper())
            {
                return sqlh.ExecMappingList<ContactItem>(@"
select
	c.contact Id,
	t.code Type,
	c.value Value
from Contact.contact c
	join Contact.contact_type t on t.contact_type = c.contact_type
	join Contact.contact2cathedra c2c on c2c.contact = c.contact
where c2c.cathedra = @Id", new { id });
            }
        }

        /// <summary>
        /// Прикрепляет контакт к факультету.
        /// </summary>
        /// <param name="contact_id">Идентификатор контакта.</param>
        /// <param name="faculty_id">Идентификатор факультета.</param>
        public void AttachContactToFaculty(int contact_id, int faculty_id)
        {
            using (var sqlh = new SqlHelper())
            {
                sqlh.ExecNoQuery(@"
insert into Contact.contact2faculty
(
	contact,
	faculty
)
values
(
	@contact_id,
	@faculty_id
)", new { contact_id, faculty_id });
            }
        }

        /// <summary>
        /// Получает список всех контактов факультета по его идентификатору.
        /// </summary>
        /// <returns>Список контактов.</returns>
        public List<ContactItem> GetContactsListByFacultyId(int id)
        {
            using (var sqlh = new SqlHelper())
            {
                return sqlh.ExecMappingList<ContactItem>(@"
select
	c.contact Id,
	t.code Type,
	c.value Value
from Contact.contact c
	join Contact.contact_type t on t.contact_type = c.contact_type
	join Contact.contact2faculty c2f on c2f.contact = c.contact
where c2f.faculty = @Id", new { id });
            }
        }

        /// <summary>
        /// Прикрепляет контакт к группе.
        /// </summary>
        /// <param name="contact_id">Идентификатор контакта.</param>
        /// <param name="team_id">Идентификатор группы.</param>
        public void AttachContactToTeam(int contact_id, int team_id)
        {
            using (var sqlh = new SqlHelper())
            {
                sqlh.ExecNoQuery(@"
insert into Contact.contact2team
(
	contact,
	team
)
values
(
	@contact_id,
	@team_id
)", new { contact_id, team_id });
            }
        }

        /// <summary>
        /// Получает список всех контактов группы по ее идентификатору.
        /// </summary>
        /// <returns>Список контактов.</returns>
        public List<ContactItem> GetContactsListByTeamId(int id)
        {
            using (var sqlh = new SqlHelper())
            {
                return sqlh.ExecMappingList<ContactItem>(@"
select
	c.contact Id,
	t.code Type,
	c.value Value
from Contact.contact c
	join Contact.contact_type t on t.contact_type = c.contact_type
	join Contact.contact2team c2t on c2t.contact = c.contact
where c2t.team = @Id", new { id });
            }
        }
	}
}
