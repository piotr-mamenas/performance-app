using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Accounts;
using Core.Domain.Partners;
using Core.Interfaces;
using Moq;

namespace Web.Tests
{
    public static class MockUnitOfWork
    {

        public static IUnitOfWork Create(IList<Account> accounts, IList<Partner> partners)
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            
            mockUnitOfWork.Setup(m => m.Accounts.Add(It.IsAny<Account>())).Callback<Account>(accounts.Add);
            mockUnitOfWork.Setup(m => m.Partners.Add(It.IsAny<Partner>())).Callback<Partner>(partners.Add);

            mockUnitOfWork.Setup(m => m.Accounts.GetAll()).Returns(accounts.AsQueryable());
            mockUnitOfWork.Setup(m => m.Partners.GetAsync(1)).Returns(Task.FromResult(partners.SingleOrDefault(a => a.Id == 1)));
            mockUnitOfWork.Setup(m => m.Partners.GetAll()).Returns(partners.AsQueryable());
            mockUnitOfWork.Setup(m => m.Accounts.GetAsync(1)).Returns(Task.FromResult(accounts.SingleOrDefault(a => a.Id == 1)));

            mockUnitOfWork.As<IComplete>();
            mockUnitOfWork.As<IComplete>().Setup(m => m.CompleteAsync()).Returns(Task.FromResult(0));

            return mockUnitOfWork.Object;
        }
    }
}
