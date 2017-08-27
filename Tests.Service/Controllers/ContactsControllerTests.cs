using Core.Interfaces;
using Moq;
using NUnit.Framework;
using Service.Controllers;

namespace Tests.Service.Controllers
{
    [TestFixture]
    public class ContactsControllerTests
    {
        [SetUp]
        public void TestConfiguration()
        {
            var unitOfWorkFake = new Mock<IUnitOfWork>();
            var controller = new ContactsController(unitOfWorkFake.Object);
        }

        [Test]
        public void Test()
        {
            
        }
    }
}
