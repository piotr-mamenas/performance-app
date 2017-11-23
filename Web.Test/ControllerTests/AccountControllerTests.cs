using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Core.Interfaces;
using Moq;
using Ninject.Extensions.Logging;
using NUnit.Framework;
using Web.Controllers;
using Web.Presentation.ViewModels.AccountViewModels;
using Web.Tests.FakeData;

namespace Web.Tests.ControllerTests
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    public class AccountControllerTests
    {
        private IUnitOfWork UnitOfWork { get; set; }
        private ILogger Logger { get; set; }

        [SetUp]
        public void Init()
        {
            var fakeAccountsList = FakeAccountData.GetList();
            var fakePartnersList = FakePartnerData.GetList();

            UnitOfWork = MockUnitOfWork.Create(fakeAccountsList,fakePartnersList);
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
        [Ignore("Test does not see mocked unit of work account id, must fix")]
        public void Update_ShouldSave_UpdatedValidAccount()
        {
            // Arrange
            var accountsCount = UnitOfWork.Accounts.GetAll().Count();
            var controller = new AccountController(UnitOfWork, Logger);

            var accountVm = new AccountViewModel
            {
                Id = 1,
                Name = "UpdatedAccount",
                Number = "UpdatedAccountNumber",
                OpenedDate = DateTime.Now,
                SelectedPartnerId = 1
            };

            // Act
            var result = controller.Update(1,accountVm);

            // Assert
            Assert.AreEqual(accountsCount + 1, UnitOfWork.Accounts.GetAll().Count());
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
