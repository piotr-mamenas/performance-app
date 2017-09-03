﻿using Core.Interfaces;
using Moq;
using NUnit.Framework;
using Service.Controllers;

namespace Tests.Service.Controllers
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
