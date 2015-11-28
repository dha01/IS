using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using IS.Model.Item.SpecialtyDetail;
using IS.Model.Repository.SpecialtyDetail;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.SpecialtyDetail
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
		private SpecialtyDetailRepository _specialty_detailRepository;

		private SpecialtyDetailItem _specialty_detail;
		private SpecialtyDetailItem _specialty_detailNew;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_specialty_detailRepository = new SpecialtyDetailRepository();

			_specialty_detail = new SpecialtyDetailItem()
			{
				ActualDate = DateTime.Now.Date,
				SemestrCount = 4,
				TrainingPeriod = 1,
				PaySpace = 128,
				LowcostSpace = 45,
			};
			_specialty_detailNew = new SpecialtyDetailItem()
			{
				ActualDate = DateTime.Now.Date,
				SemestrCount = 3,
				TrainingPeriod = 2,
				PaySpace = 64,
				LowcostSpace = 34,
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
		/// <param name="first_specialty_detail"></param>
		/// <param name="second_specialty_detail"></param>
		private void AreEqualSpecialtyDetails(SpecialtyDetailItem first_specialty_detail, SpecialtyDetailItem second_specialty_detail)
		{
			Assert.AreEqual(first_specialty_detail.Id, second_specialty_detail.Id);
			Assert.AreEqual(first_specialty_detail.ActualDate, second_specialty_detail.ActualDate);
			Assert.AreEqual(first_specialty_detail.SemestrCount, second_specialty_detail.SemestrCount);
			Assert.AreEqual(first_specialty_detail.TrainingPeriod, second_specialty_detail.TrainingPeriod);
			Assert.AreEqual(first_specialty_detail.PaySpace, second_specialty_detail.PaySpace);
			Assert.AreEqual(first_specialty_detail.LowcostSpace, second_specialty_detail.LowcostSpace);
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает учебный курс.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			_specialty_detail.Id = _specialty_detailRepository.Create(_specialty_detail);
			var result = _specialty_detailRepository.Get(_specialty_detail.Id);
			AreEqualSpecialtyDetails(result, _specialty_detail);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет параметры учебного курса.
		/// </summary>
		[Test]
		public void Update_Void_ReturnChangedSpecialtyDetail()
		{
			_specialty_detail.Id = _specialty_detailRepository.Create(_specialty_detail);
			var result = _specialty_detailRepository.Get(_specialty_detail.Id);
			AreEqualSpecialtyDetails(result, _specialty_detail);

			_specialty_detailNew.Id = _specialty_detail.Id;
			_specialty_detailRepository.Update(_specialty_detailNew);
			result = _specialty_detailRepository.Get(_specialty_detail.Id);
			AreEqualSpecialtyDetails(result, _specialty_detailNew);

		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет курс.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_specialty_detail.Id = _specialty_detailRepository.Create(_specialty_detail);
			var result = _specialty_detailRepository.Get(_specialty_detail.Id);
			AreEqualSpecialtyDetails(result, _specialty_detail);

			_specialty_detailRepository.Delete(_specialty_detail.Id);
			result = _specialty_detailRepository.Get(_specialty_detail.Id);
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
			_specialty_detail.Id = _specialty_detailRepository.Create(_specialty_detail);
			var result = _specialty_detailRepository.GetList().Find(x => x.Id == _specialty_detail.Id);
			AreEqualSpecialtyDetails(result, _specialty_detail);
		}

		#endregion
	}
}
