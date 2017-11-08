using System.Data.Entity;
using Core.Domain.Institutions;

namespace Infrastructure.Seed.TestData
{
    public class InstitutionSeeder : BaseSeeder<Institution>, ITestData
    {
        public InstitutionSeeder(IDbSet<Institution> institutions)
            : base(institutions)
        {
            SeededEntities.Add(new Institution
            {
                Id = 2,
                Name = "European Union"
            });

            SeededEntities.Add(new Bank
            {
                Id = 1,
                Bic = "CRESCHZZ80A",
                Name = "Credit Suisse"
            });
        }
    }
}
