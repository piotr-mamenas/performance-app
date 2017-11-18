using System.Collections.Generic;
using System.Linq;
using Core.Domain.Accounts;
using Core.Domain.Partners;
using Core.Interfaces;
using Moq;

namespace Web.Tests
{
    public class MockUnitOfWork
    {
        public static IUnitOfWork Create(IList<Account> accounts, IList<Partner> partners)
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork.Setup(x => x.Accounts.GetAll()).Returns(accounts.AsQueryable());
            mockUnitOfWork.Setup(x => x.Partners.GetAll()).Returns(partners.AsQueryable());

            mockUnitOfWork.Setup(m => m.Accounts.Add(It.IsAny<Account>())).Callback<Account>(accounts.Add);
            mockUnitOfWork.Setup(m => m.Partners.Add(It.IsAny<Partner>())).Callback<Partner>(partners.Add);

            return mockUnitOfWork.Object;
        }
    }
}
