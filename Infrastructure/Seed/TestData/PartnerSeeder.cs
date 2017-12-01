using System.Data.Entity;
using Core.Domain.Partners;

namespace Infrastructure.Seed.TestData
{
    public class PartnerSeeder : BaseSeeder<Partner>, ITestData
    {
        public PartnerSeeder(IDbSet<Partner> partners)
            : base(partners)
        {
            SeededEntities.Add(new Partner
            {
                Id = 1,
                Name = "OCPD Trading Company",
                Number = "PL1249",
                PartnerTypeId = 1
            });

            SeededEntities.Add(new Partner
            {
                Id = 2,
                Name = "Dr. Wyler & Co",
                Number = "US3450",
                PartnerTypeId = 1
            });
        }
    }
}
