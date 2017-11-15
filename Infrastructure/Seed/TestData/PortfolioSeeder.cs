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
            // TODO: Need to fix asset population for portfolio
            var assetList = new List<Asset>
            {
                new Asset
                {
                    Id = 1
                },
                new Asset
                {
                    Id = 2
                },
                new Asset
                {
                    Id = 3
                }
            };

            SeededEntities.Add(new Portfolio
            {
                Id = 1,
                Name = "Benchmark Portfolio",
                Number = "KKY10934747",
                AccountId = 1, 
                Assets = assetList
            });

            SeededEntities.Add(new Portfolio
            {
                Id = 2,
                Name = "Benchmark Portfolio",
                Number = "KKZ97147473",
                AccountId = 2,
                Assets = assetList
            });

        }
    }
}
