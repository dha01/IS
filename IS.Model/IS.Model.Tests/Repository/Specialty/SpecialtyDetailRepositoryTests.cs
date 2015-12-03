using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using IS.Model.Item.Specialty;
using IS.Model.Repository.Specialty;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Specialty
{
	/// <summary>
	/// Тесты для репозитория учбных курсов.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	public class SpecialtyDetailRepositoryTests
	{
		#region Fields

		/// <summary>
		/// Транзакция.
		/// </summary>
		private TransactionScope _transactionScope;

		/// <summary>
		/// Репозиторий курсов.
		/// </summary>
		private SpecialtyDetailRepository _specialtydetailRepository;

		private SpecialtyDetailItem _specialtydetail;
		private SpecialtyDetailItem _specialtydetailNew;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_specialtydetailRepository = new SpecialtyDetailRepository();

			_specialtydetail = new SpecialtyDetailItem()
			{
				ActualDate = DateTime.Now.Date,
				SpecialtyId = 30,
				SemestrCount = 4,
				TrainingPeriod = 1,
				Qualification = Qualification.Bachelor,
				FormStudy = FormStudy.Distance,
				PaySpace = 128,
				LowcostSpace = 98,
			};
			_specialtydetailNew = new SpecialtyDetailItem()
			{
				ActualDate = DateTime.Now.Date,
				SpecialtyId = 32,
				SemestrCount = 3,
				TrainingPeriod = 2,
				Qualification = Qualification.Master,
				FormStudy = FormStudy.Fulltime,
				PaySpace = 64,
				LowcostSpace = 98,
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
		/// Проверяет эквивалентны ли два курса.
		/// </summary>
		/// <param name="first_specialtydetail"></param>
		/// <param name="second_specialtydetail"></param>
		private void AreEqualSpecialtyDetails(SpecialtyDetailItem first_specialtydetail, SpecialtyDetailItem second_specialtydetail)
		{
			Assert.AreEqual(first_specialtydetail.Id, second_specialtydetail.Id);
			Assert.AreEqual(first_specialtydetail.ActualDate, second_specialtydetail.ActualDate);
			Assert.AreEqual(first_specialtydetail.SemestrCount, second_specialtydetail.SemestrCount);
			Assert.AreEqual(first_specialtydetail.TrainingPeriod, second_specialtydetail.TrainingPeriod);
			Assert.AreEqual(first_specialtydetail.PaySpace, second_specialtydetail.PaySpace);
			Assert.AreEqual(first_specialtydetail.LowcostSpace, second_specialtydetail.LowcostSpace);
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает учебный курс.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			_specialtydetail.Id = _specialtydetailRepository.Create(_specialtydetail);
			var result = _specialtydetailRepository.Get(_specialtydetail.Id);
			AreEqualSpecialtyDetails(result, _specialtydetail);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет параметры учебного курса.
		/// </summary>
		[Test]
		public void Update_Void_ReturnChangedSpecialtyDetail()
		{
			_specialtydetail.Id = _specialtydetailRepository.Create(_specialtydetail);
			var result = _specialtydetailRepository.Get(_specialtydetail.Id);
			AreEqualSpecialtyDetails(result, _specialtydetail);

			_specialtydetailNew.Id = _specialtydetail.Id;
			_specialtydetailRepository.Update(_specialtydetailNew);
			result = _specialtydetailRepository.Get(_specialtydetail.Id);
			AreEqualSpecialtyDetails(result, _specialtydetailNew);

		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет курс.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_specialtydetail.Id = _specialtydetailRepository.Create(_specialtydetail);
			var result = _specialtydetailRepository.Get(_specialtydetail.Id);
			AreEqualSpecialtyDetails(result, _specialtydetail);

			_specialtydetailRepository.Delete(_specialtydetail.Id);
			result = _specialtydetailRepository.Get(_specialtydetail.Id);
			Assert.IsNull(result);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список всех контактов.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnNotEmptyListWithSpecialtyDetails()
		{
			_specialtydetail.Id = _specialtydetailRepository.Create(_specialtydetail);
			var result = _specialtydetailRepository.GetList().Find(x => x.Id == _specialtydetail.Id);
			AreEqualSpecialtyDetails(result, _specialtydetail);
		}

		#endregion
	}
}
