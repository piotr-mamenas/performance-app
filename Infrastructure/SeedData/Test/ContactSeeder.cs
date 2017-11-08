using System.Data.Entity;
using Core.Domain.Contacts;

namespace Infrastructure.SeedData.Test
{
    public class ContactSeeder : BaseSeeder<Contact>, ITestData
    {
        public ContactSeeder(IDbSet<Contact> contacts)
            : base(contacts)
        {
            SeededEntities.Add(new Contact
            {
                Id = 1,
                Email = "gordon.gekko@teldar.com",
                FirstName = "Gordon",
                LastName = "Gekko",
                Name = "Gordon Gekko",
                PartnerId = 1,
                PhoneNumber = "+0111111111"
            });

            SeededEntities.Add(new Contact
            {
                Id = 2,
                Email = "piotr.mamenas@gmail.com",
                FirstName = "Piotr",
                LastName = "Mamenas",
                Name = "Piotr Mamenas",
                PartnerId = 1,
                PhoneNumber = "+482222222"
            });

            SeededEntities.Add(new Contact
            {
                Id = 3,
                Email = "jordan.belfort@stratton.com",
                FirstName = "Jordan",
                LastName = "Belfort",
                Name = "Jordan Belfort",
                PartnerId = 2,
                PhoneNumber = "+413333333"
            });
        }
    }
}
