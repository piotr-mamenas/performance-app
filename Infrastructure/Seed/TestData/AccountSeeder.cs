using System;
using System.Data.Entity;
using Core.Domain.Accounts;

namespace Infrastructure.Seed.TestData
{
    public class AccountSeeder : BaseSeeder<Account>, ITestData
    {
        public AccountSeeder(IDbSet<Account> accounts)
            : base(accounts)
        {
            SeededEntities.Add(new Account
            {
                Id = 1,
                OpenedDate = DateTime.Now,
                Name = "Private WM Account",
                Number = "CH470217"
            });

            SeededEntities.Add(new Account
            {
                Id = 2,
                OpenedDate = DateTime.Now,
                Name = "Private WM Account",
                Number = "GB076919"
            });

            SeededEntities.Add(new Account
            {
                Id = 3,
                OpenedDate = DateTime.Now,
                Name = "Private Speculation Account",
                Number = "CH011137"
            });
        }
    }
}
