using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using IS.Model.Item.Contact;
using IS.Model.Item.Person;
using IS.Model.Item.Cathedra;
using IS.Model.Item.Faculty;
using IS.Model.Item.Specialty;
using IS.Model.Item.Team;
using IS.Model.Repository.Contact;
using IS.Model.Repository.Person;
using IS.Model.Repository.Cathedra;
using IS.Model.Repository.Faculty;
using IS.Model.Repository.Specialty;
using IS.Model.Repository.Team;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Contact
{
	/// <summary>
	/// Тесты для репозитория контактов.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	public class ContactRepositoryTests
	{
		#region Fields

		/// <summary>
		/// Транзакция.
		/// </summary>
		private TransactionScope _transactionScope;

		/// <summary>
		/// Репозиторий контактов.
		/// </summary>
		private ContactRepository _contactRepository;

		private ContactItem _contact;
		private ContactItem _contactNew;

		private PersonRepository _personRepository;
		private PersonItem _person;

		private CathedraRepository _cathedraRepository;
		private CathedraItem _cathedra;

		private FacultyRepository _facultyRepository;
		private FacultyItem _faculty;

		private TeamRepository _teamRepository;
		private SpecialtyDetailRepository _specialtyDetailRepository;
		private SpecialtyRepository _specialtyRepository;
		private TeamItem _team;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_contactRepository = new ContactRepository();
			_personRepository = new PersonRepository();

			_cathedraRepository = new CathedraRepository();
			_facultyRepository = new FacultyRepository();

			_teamRepository = new TeamRepository();
			_specialtyDetailRepository = new SpecialtyDetailRepository();
			_specialtyRepository = new SpecialtyRepository();

			var specialty_detail = new SpecialtyDetailItem()
			{
				SpecialtyId = _specialtyRepository.Create(new SpecialtyItem()
				{
					CathedraId = _cathedraRepository.Create(new CathedraItem()
					{
						FacultyId = _facultyRepository.Create(new FacultyItem()
						{
							FullName = "Кафедра",
							ShortName = "K" 
						}),
						FullName = "Кафедра",
						ShortName = "K"
					}),
					FullName = "Специальность",
					ShortName = "С",
					Code = "1"
				}),
				ActualDate = DateTime.Now
			};

			_contact = new ContactItem()
			{
				Type = ContactType.MobilePhone,
				Value = "8-999-999-99-99"
			};
			_contactNew = new ContactItem()
			{
				Type = ContactType.CityPhone,
				Value = "000-00-00"
			};
			_person = new PersonItem()
			{
				Id = 1,
				LastName = "Иванов",
				FirstName = "Василий",
				Birthday = DateTime.Now.Date,
				FatherName = "Иванович"

			};
			_faculty = new FacultyItem()
			{
				FullName = "Экономический",
				ShortName = "Э",
			};
			_cathedra = new CathedraItem()
			{
				FullName = "Информациионных систем и технологий",
				ShortName = "ИСиТ",
				FacultyId = _facultyRepository.Create(_faculty)
			};
			_team = new TeamItem()
			{
				Name = "ПЕ-22б",
				CreateDate = DateTime.Now.Date,
				SpecialtyDetailId = _specialtyDetailRepository.Create(specialty_detail)
			}; 
		}

		#endregion

		#region TearDown

		/// <summary>
		/// Выполняется после каждого теста.
		/// </summary>
		[TearDown]
		public void TearDown()
		{
			_transactionScope.Dispose();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Проверяет эквивалентны ли два контакта.
		/// </summary>
		/// <param name="first_contact">Первый контакт для сравнения.</param>
		/// <param name="second_contact">Второй контакт для сравнения.</param>
		private void AreEqualContacts(ContactItem first_contact, ContactItem second_contact)
		{
			Assert.AreEqual(first_contact.Id, second_contact.Id);
			Assert.AreEqual(first_contact.Type, second_contact.Type);
			Assert.AreEqual(first_contact.Value, second_contact.Value);
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает контакт.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			_contact.Id = _contactRepository.Create(_contact);
			var result = _contactRepository.Get(_contact.Id);
			AreEqualContacts(result, _contact);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет параметры контакта.
		/// </summary>
		[Test]
		public void Update_Void_ReturnChangedContact()
		{
			_contact.Id = _contactRepository.Create(_contact);
			var result = _contactRepository.Get(_contact.Id);
			AreEqualContacts(result, _contact);

			_contactNew.Id = _contact.Id;
			_contactRepository.Update(_contactNew);
			result = _contactRepository.Get(_contact.Id);
			AreEqualContacts(result, _contactNew);

		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет контакт.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_contact.Id = _contactRepository.Create(_contact);
			var result = _contactRepository.Get(_contact.Id);
			AreEqualContacts(result, _contact);

			_contactRepository.Delete(_contact.Id);
			result = _contactRepository.Get(_contact.Id);
			Assert.IsNull(result);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список всех контактов.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnNotEmptyListWithContacts()
		{
			_contact.Id = _contactRepository.Create(_contact);
			var result = _contactRepository.GetList().Find(x => x.Id == _contact.Id);
			AreEqualContacts(result, _contact);
		}

		#endregion

		#region GetPersonListById

		/// <summary>
		/// Получает список всех контактов человека по его идентификатору.
		/// </summary>
		[Test]
		public void GetContactsListByPersonId_Void_ReturnNotEmptyListWithContacts()
		{
			_person.Id = _personRepository.Create(_person);
			_contact.Id = _contactRepository.Create(_contact);
			_contactRepository.AttachContactToPerson(_contact.Id, _person.Id);
			var result = _contactRepository.GetContactsListByPersonId(_person.Id).First(x => x.Id == _contact.Id);
			AreEqualContacts(result, _contact);
		}

		#endregion

		#region GetCathedraListById

		/// <summary>
		/// Получает список всех контактов кафедры по его идентификатору.
		/// </summary>
		[Test]
		public void GetContactsListByCathedraId_Void_ReturnNotEmptyListWithContacts()
		{
			_cathedra.Id = _cathedraRepository.Create(_cathedra);
			_contact.Id = _contactRepository.Create(_contact);
			_contactRepository.AttachContactToCathedra(_contact.Id, _cathedra.Id);
			var result = _contactRepository.GetContactsListByCathedraId(_cathedra.Id).First(x => x.Id == _contact.Id);
			AreEqualContacts(result, _contact);
		}

		#endregion

		#region GetFacultyListById

		/// <summary>
		/// Получает список всех контактов факультета по его идентификатору.
		/// </summary>
		[Test]
		public void GetContactsListByFacultyId_Void_ReturnNotEmptyListWithContacts()
		{
			_faculty.Id = _facultyRepository.Create(_faculty);
			_contact.Id = _contactRepository.Create(_contact);
			_contactRepository.AttachContactToFaculty(_contact.Id, _faculty.Id);
			var result = _contactRepository.GetContactsListByFacultyId(_faculty.Id).First(x => x.Id == _contact.Id);
			AreEqualContacts(result, _contact);
		}

		#endregion

		#region GetTeamListById

		/// <summary>
		/// Получает список всех контактов группы по ее идентификатору.
		/// </summary>
		[Test]
		public void GetContactsListByTeamId_Void_ReturnNotEmptyListWithContacts()
		{
			_team.Id = _teamRepository.Create(_team);
			_contact.Id = _contactRepository.Create(_contact);
			_contactRepository.AttachContactToTeam(_contact.Id, _team.Id);
			var result = _contactRepository.GetContactsListByTeamId(_team.Id).First(x => x.Id == _contact.Id);
			AreEqualContacts(result, _contact);
		}

		#endregion   
	}
}
