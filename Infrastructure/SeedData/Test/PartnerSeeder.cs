using System.Data.Entity;
using Core.Domain.Partners;

namespace Infrastructure.SeedData.Test
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
                Number = "PL1249"
            });

            SeededEntities.Add(new Partner
            {
                Id = 2,
                Name = "Dr. Wyler & Co",
                Number = "US3450"
            });
        }
    }
}
