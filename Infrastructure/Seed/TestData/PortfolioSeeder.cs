using System.Collections.Generic;
using System.Data.Entity;
using Core.Domain.Assets;
using Core.Domain.Portfolios;

namespace Infrastructure.Seed.TestData
{
    public class PortfolioSeeder : BaseSeeder<Portfolio>, ITestData
    {
        public PortfolioSeeder(IDbSet<Portfolio> portfolios)
            : base(portfolios)
        {
            SeededEntities.Add(new Portfolio
            {
                Id = 1,
                Name = "Benchmark Portfolio",
                Number = "KKY10934747",
                AccountId = 1
            });

            SeededEntities.Add(new Portfolio
            {
                Id = 2,
                Name = "Benchmark Portfolio",
                Number = "KKZ97147473",
                AccountId = 2
            });

        }
    }
}
