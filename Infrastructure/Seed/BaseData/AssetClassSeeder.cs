using System.Data.Entity;
using Core.Domain.Assets;

namespace Infrastructure.Seed.BaseData
{
    public class AssetClassSeeder : BaseSeeder<AssetClass>, ITestData
    {
        public AssetClassSeeder(IDbSet<AssetClass> assetClasses)
            : base(assetClasses)
        {
            SeededEntities.Add(new AssetClass
            {
                Id = 1,
                Name = "Bond",
                IsEnabled = true
            });

            SeededEntities.Add(new AssetClass
            {
                Id = 2,
                Name = "Equity",
                IsEnabled = true
            });
        }
    }
}
