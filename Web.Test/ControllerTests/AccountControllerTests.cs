using System;
using System.Linq;
using System.Web.Mvc;
using Core.Interfaces;
using Moq;
using Ninject.Extensions.Logging;
using NUnit.Framework;
using Web.Controllers;
using Web.Presentation.ViewModels.AccountViewModels;

namespace Web.Tests.ControllerTests
{
    [TestFixture]
    public class AccountControllerTests
    {
        private IUnitOfWork UnitOfWork { get; set; }
        private ILogger Logger { get; set; }

        [SetUp]
        public void Init()
        {
            var fakeAccountsList = Fakes.FakeAccountData.GetList();
            var fakePartnersList = Fakes.FakePartnerData.GetList();

            UnitOfWork = MockUnitOfWork.Create(fakeAccountsList,fakePartnersList);
            Logger = new Mock<ILogger>().Object;
        }

        [Test]
        public void Create_ShouldSave_NewProperAccount()
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
            Assert.IsInstanceOf(typeof(RedirectToRouteResult), result);
        }


    }
}
