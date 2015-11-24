using System;
using System.Transactions;
using IS.Model.Item.Auditory;
using IS.Model.Repository.Auditory;
using NUnit.Framework;

namespace IS.Model.Auditory.Repository.Team
{
	/// <summary>
	/// Тесты для репозитория задач.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
    public class AuditoryRepositoryTests
	{
		#region Fields

		/// <summary>
		/// Транзакция.
		/// </summary>
		private TransactionScope _transactionScope;

		/// <summary>
		/// Репозиторий задач.
		/// </summary>
        private AuditoryRepository _auditoryRepository;

        private AuditoryItem _auditory;
        private AuditoryItem _auditoryNew;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
            _auditoryRepository = new AuditoryRepository();

            _auditory = new AuditoryItem()
			{
                Number = "481",
                FullName = "МН-481", //Что подразумевается под Полным именем?
                Memo = "Лекционная",
                Level = 2,
                Capacity = 60
			};
            _auditoryNew = new AuditoryItem()
			{
                Number = "572",
                FullName = "ИН-572",
                Memo = "Римская",
                Level = 1,
                Capacity = 120
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
		/// Проверяет эквивалентны ли две аудитории.
		/// </summary>
        /// <param name="first_auditory"></param>
        /// <param name="second_auditory"></param>
        private void AreEqualAuditory(AuditoryItem first_auditory, AuditoryItem second_auditory)
		{
            Assert.AreEqual(first_auditory.Number, second_auditory.Number);
            Assert.AreEqual(first_auditory.FullName, second_auditory.FullName);
            Assert.AreEqual(first_auditory.Memo, second_auditory.Memo);
            Assert.AreEqual(first_auditory.Level, second_auditory.Level);
            Assert.AreEqual(first_auditory.Capacity, second_auditory.Capacity);
		}

		#endregion

		#region Create


		#endregion

		#region Update

	

		#endregion

		#region Delete

        /// <summary>
        /// Удаляет аудиторию.
        /// </summary>
        [Test]
        public void Delete_Void_ReturnNull()
        {
            _auditory.Id = _auditoryRepository.Create(_auditory); //Ещё не сделали (24.11.2015)
            var result = _auditoryRepository.Get(_auditory.Id);
            AreEqualDiscipline(result, _auditory);

            _auditoryRepository.Delete(_auditory.Id);
            result = _auditoryRepository.Get(_auditory.Id);
            Assert.IsNull(result);
        }

		#endregion

		#region GetList

	

		#endregion
	}
}
