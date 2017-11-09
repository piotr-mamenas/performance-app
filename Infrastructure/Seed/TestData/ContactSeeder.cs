using System.Data.Entity;
using Core.Domain.Partners;

namespace Infrastructure.Seed.TestData
{
    public class ContactSeeder : BaseSeeder<PartnerContact>, ITestData
    {
        public ContactSeeder(IDbSet<PartnerContact> contacts)
            : base(contacts)
        {
            SeededEntities.Add(new PartnerContact
            {
                Id = 1,
                Email = "gordon.gekko@teldar.com",
                FirstName = "Gordon",
                LastName = "Gekko",
                Name = "Gordon Gekko",
                PartnerId = 1,
                PhoneNumber = "+0111111111"
            });

            SeededEntities.Add(new PartnerContact
            {
                Id = 2,
                Email = "piotr.mamenas@gmail.com",
                FirstName = "Piotr",
                LastName = "Mamenas",
                Name = "Piotr Mamenas",
                PartnerId = 1,
                PhoneNumber = "+482222222"
            });

            SeededEntities.Add(new PartnerContact
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
