using System;
using System.Data.Entity;
using Core.Domain.Assets;

namespace Infrastructure.Seed.TestData
{
    public class AssetSeeder : BaseSeeder<Asset>, ITestData
    {
        public AssetSeeder(IDbSet<Asset> assets)
            : base(assets)
        {
            SeededEntities.Add(new Equity
            {
                Id = 1,
                Name = "Apple",
                Isin = "US0378331005"
            });

            SeededEntities.Add(new Equity
            {
                Id = 2,
                Name = "Accenture",
                Isin = "IE00B4BNMY34"
            });

            SeededEntities.Add(new Equity
            {
                Id = 3,
                Name = "UBS",
                Isin = "CH0244767585"
            });

            SeededEntities.Add(new Bond
            {
                Id = 4,
                FaceValue = 100,
                IssueDate = DateTime.Now,
                MaturityDate = DateTime.Today,
                Name = "US Standard Bond",
                Coupon = new BondCoupon
                {
                    Amount = 200,
                    Rate = new decimal(0.04)
                }
            });
        }
    }
}
