using System;
using System.Data.Entity;
using Core.Domain.Assets;

namespace Infrastructure.Seed.TestData
{
    public class AssetPriceSeeder : BaseSeeder<AssetPrice>, ITestData
    {
        public AssetPriceSeeder(IDbSet<AssetPrice> assetPrices)
            : base(assetPrices)
        {
            SeededEntities.Add(new AssetPrice
            {
                Id = 1,
                AssetId = 1,
                CurrencyId = 5,
                Amount = 102.3456m,
                Timestamp = new DateTime(2017,11,17,12,57,47,DateTimeKind.Local)
            });
            SeededEntities.Add(new AssetPrice
            {
                Id = 1,
                AssetId = 1,
                CurrencyId = 5,
                Amount = 101.3456m,
                Timestamp = new DateTime(2017, 11, 16, 12, 17, 47, DateTimeKind.Local)
            });
            SeededEntities.Add(new AssetPrice
            {
                Id = 1,
                AssetId = 1,
                CurrencyId = 5,
                Amount = 97.3456m,
                Timestamp = new DateTime(2017, 11, 15, 10, 17, 47, DateTimeKind.Local)
            });

            SeededEntities.Add(new AssetPrice
            {
                Id = 1,
                AssetId = 2,
                CurrencyId = 5,
                Amount = 64.0192m,
                Timestamp = new DateTime(2017, 11, 17, 12, 47, 47, DateTimeKind.Local)
            });
            SeededEntities.Add(new AssetPrice
            {
                Id = 1,
                AssetId = 2,
                CurrencyId = 5,
                Amount = 64.3456m,
                Timestamp = new DateTime(2017, 11, 16, 12, 17, 47, DateTimeKind.Local)
            });
            SeededEntities.Add(new AssetPrice
            {
                Id = 1,
                AssetId = 2,
                CurrencyId = 5,
                Amount = 65.8956m,
                Timestamp = new DateTime(2017, 11, 15, 10, 37, 47, DateTimeKind.Local)
            });

            SeededEntities.Add(new AssetPrice
            {
                Id = 1,
                AssetId = 3,
                CurrencyId = 5,
                Amount = 87.1205m,
                Timestamp = new DateTime(2017, 11, 17, 12, 57, 47, DateTimeKind.Local)
            });
            SeededEntities.Add(new AssetPrice
            {
                Id = 1,
                AssetId = 3,
                CurrencyId = 5,
                Amount = 85.9294m,
                Timestamp = new DateTime(2017, 11, 16, 13,17,11,DateTimeKind.Local)
            });
            SeededEntities.Add(new AssetPrice
            {
                Id = 1,
                AssetId = 3,
                CurrencyId = 5,
                Amount = 84.2940m,
                Timestamp = new DateTime(2017, 11, 17, 11, 07, 02, DateTimeKind.Local)
            });
        }
    }
}
