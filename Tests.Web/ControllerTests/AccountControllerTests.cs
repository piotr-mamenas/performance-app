using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Core.Interfaces;
using Moq;
using Ninject.Extensions.Logging;
using NUnit.Framework;
using Tests.Web.FakeData;
using Web.Controllers;
using Web.Presentation.ViewModels.AccountViewModels;

namespace Tests.Web.ControllerTests
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    public class AccountControllerTests
    {
        public IUnitOfWork UnitOfWork
        {
            get
            {
                if (_unitOfWork == null)
                {
                    _unitOfWork = MockUnitOfWork.Create(FakeAccountData.GetList(), FakePartnerData.GetList());
                }
                return _unitOfWork;
            }
        }

        private IUnitOfWork _unitOfWork;

        private ILogger Logger { get; set; }

        [SetUp]
        public void Init()
        {
            Logger = new Mock<ILogger>().Object;
        }

        [Test]
        public void Create_ShouldSave_NewValidAccount()
        {
            // Arrange
            var accountsCount = UnitOfWork.Accounts.GetAll().Count();
            var controller = new AccountController(UnitOfWork,Logger);

            var accountVm = new AccountViewModel
            {
                Name = "NewAccount",
                Number = "NewAccountNumber",
                OpenedDate = DateTime.Now,
                SelectedPartnerId = 1
            };

            // Act
            var result = controller.Create(accountVm);

            // Assert
            Assert.AreEqual(accountsCount + 1, UnitOfWork.Accounts.GetAll().Count());
            Assert.IsInstanceOf(typeof(Task<ActionResult>), result);
        }
        
        [Test]
        public void Create_ShouldNotSave_NewInvalidAccount()
        {
            // Arrange
            var accountsCount = UnitOfWork.Accounts.GetAll().Count();
            var controller = new AccountController(UnitOfWork, Logger);
            var accountVm = new AccountViewModel
            {
                Number = null,
                Name = null,
                SelectedPartnerId = 0
            };
            // Act
            var result = controller.Create(accountVm);

            // Assert
            Assert.AreEqual(accountsCount, UnitOfWork.Accounts.GetAll().Count());
            Assert.IsInstanceOf(typeof(Task<ActionResult>), result);
        }

        [Test]
        public void Update_ShouldSave_UpdatedValidAccount()
        {
            // Arrange
            var controller = new AccountController(UnitOfWork, Logger);

            var accountId = 1;
            var accountName = "UpdatedName";

            var accountVm = new AccountViewModel
            {
                Id = accountId,
                Name = accountName,
                Number = "UpdatedAccountNumber",
                OpenedDate = DateTime.Now,
                SelectedPartnerId = 1
            };

            // Act
            var result = controller.Update(accountId,accountVm);
            var accountInDb = UnitOfWork.Accounts.GetAsync(accountId);

            // Assert
            Assert.AreEqual(accountName, accountInDb.Result.Name);
            Assert.IsInstanceOf(typeof(Task<ActionResult>), result);
        }

        [Test]
        public void Update_ShouldNotSave_NewValidAccount()
        {
            // Arrange
            var accountsCount = UnitOfWork.Accounts.GetAll().Count();
            var controller = new AccountController(UnitOfWork, Logger);
            var accountVm = new AccountViewModel
            {
                Name = "UpdatedAccount",
                Number = "UpdatedAccountNumber",
                OpenedDate = DateTime.Now,
                SelectedPartnerId = 1
            };
            // Act
            var result = controller.Update(0,accountVm);

            // Assert
            Assert.AreEqual(accountsCount, UnitOfWork.Accounts.GetAll().Count());
            Assert.IsInstanceOf(typeof(Task<ActionResult>), result);
        }
    }
}
