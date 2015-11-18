using System;
using System.Transactions;
using IS.Model.Item.Cathedra;
using IS.Model.Repository.Cathedra;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Cathedra
{
    /// <summary>
    /// Тесты для репозитория кафедр.
    /// </summary>
    [Category("Integration")]
    [TestFixture]
    public class CathedraRepositoryTests
    {
        #region Fields

        /// <summary>
        /// Транзакция.
        /// </summary>
        private TransactionScope _transactionScope;

        /// <summary>
        /// Репозиторий кафедр.
        /// </summary>
        private FacultyRepository сathedraRepository;

        private CathedraItem _сathedra;
        private CathedraItem _сathedraNew;

        #endregion

        #region SetUp

        /// <summary>
        /// Выполняется перед каждым тестом.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _transactionScope = new TransactionScope();
            сathedraRepository = new СathedraRepository();
            _сathedra = new СathedraItem()
            {
                FullName = "Информациионных систем и технологий",
                ShortName = "ИСиТ",
                FacultyId = ""
            };
            _сathedraNew = new СathedraItem()
            {
                FullName = "Экономики и управления",
                ShortName = "ЭиЭ",
                FacultyId = ""
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
        /// Проверяет эквивалентны ли две кафедры.
        /// </summary>
        /// <param name="first_сathedra"></param>
        /// <param name="second_сathedra"></param>
        private void AreEqualСathedra(СathedraItem first_сathedra, СathedraItem second_сathedra)
        {
            Assert.AreEqual(first_сathedra.Id, second_сathedra.Id);
            Assert.AreEqual(first_сathedra.FullName, second_сathedra.FullName);
            Assert.AreEqual(first_сathedra.ShortName, second_сathedra.ShortName);
            Assert.AreEqual(first_сathedra.FacultyId, second_сathedra.FacultyId);
        }

        #endregion

        #region Create

        /// <summary>
        /// Создает кафедру.
        /// </summary>
        [Test]
        public void Create_Void_ReturnId()
        {
            _cathedra.Id = _cathedraRepository.Create(_cathedra);
            var result = _cathedraRepository.Get(_cathedra.Id);
            AreEqualCathedra(result, _cathedra);
        }
        #endregion

        #region Update

        /// <summary>
        /// Изменяет параметры кафедры.
        /// </summary>
        [Test]
        public void Update_Void_ReturnChangedCathedra()
        {
            _cathedra.Id = _cathedraRepository.Create(_cathedra);
            var result = _cathedraRepository.Get(_cathedra.Id);
            AreEqualPerson(result, _person);
            _cathedraNew.Id = _cathedra.Id;
            _cathedraRepository.Update(_cathedraNew);
            result = _cathedraRepository.Get(_cathedra.Id);
            AreEqualCathedra(result, _cathedraNew);
        }
        #endregion

        #region Delete

        /// <summary>
        /// Удаляет кафедру.
        /// </summary>
        [Test]
        public void Delete_Void_ReturnNull()
        {
            _cathedra.Id = _cathedraRepository.Create(_cathedra);
            var result = _cathedraRepository.Get(_cathedra.Id);
            AreEqualCathedra(result, _cathedra);
            _cathedraRepository.Delete(_cathedra.Id);
            result = _cathedraRepository.Get(_cathedra.Id);
            Assert.IsNull(result);
        }
        #endregion

        #region GetList

        /// <summary>
        /// Получает список всех кафедр.
        /// </summary>
        [Test]
        public void GetList_Void_ReturnNotEmptyListWithСathedra()
        {
            _сathedra.Id = сathedraRepository.Create(_сathedra);
            var result = сathedraRepository.GetList().Find(x => x.Id == _сathedra.Id);
            AreEqualСathedra(result, _сathedra); 
        }

        #endregion
    }
}
