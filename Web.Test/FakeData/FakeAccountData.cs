using System;
using System.Collections.Generic;
using Core.Domain.Accounts;

namespace Web.Tests.FakeData
{
    public static class FakeAccountData
    {
        public static Account GetOne()
        {
            return new Account
            {
                Id = 3,
                IsDeleted = false,
                PartnerId = 2,
                OpenedDate = DateTime.Now,
                ClosedDate = null,
                Name = "TESTACCOUNT3",
                Number = "US2264"
            };
        }

        public static IList<Account> GetList()
        {
            return new List<Account>
            {
                new Account
                {
                    Id = 1,
                    IsDeleted = false,
                    PartnerId = 1,
                    OpenedDate = DateTime.Now,
                    ClosedDate = null,
                    Name = "TESTACCOUNT1",
                    Number = "US2034"
                },
                new Account
                {
                    Id = 2,
                    IsDeleted = false,
                    PartnerId = 2,
                    OpenedDate = DateTime.Now,
                    ClosedDate = null,
                    Name = "TESTACCOUNT2",
                    Number = "US2059"
                }
            };
        }
    }
}
