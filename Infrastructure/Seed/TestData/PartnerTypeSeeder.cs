using System.Data.Entity;
using Core.Domain.Partners;

namespace Infrastructure.Seed.TestData
{
    public class PartnerTypeSeeder : BaseSeeder<PartnerType>, ITestData
    {
        public PartnerTypeSeeder(IDbSet<PartnerType> partnertypes)
            : base(partnertypes)
        {
            SeededEntities.Add(new PartnerType
            {
                Id = 1,
                Name = "Private Client",
                IsDeleted = false
            });
        }
    }
}
