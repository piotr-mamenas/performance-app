using Core.Interfaces;
using Service.Controllers;

namespace Service.Tests.Controllers
{
    [TestFixture]
    public class ContactsControllerTests
    {
        private ContactsController _contactsController;

        [SetUp]
        public void TestConfiguration()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            _contactsController = new ContactsController(mockUnitOfWork.Object);
        }

        [Test]
        public void Test()
        {
            
        }

        [OneTimeTearDown]
        public void DisposeAllObjects()
        {
            _contactsController = null;
        }
    }
}
