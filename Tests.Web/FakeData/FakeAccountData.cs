using System;
using System.Collections.Generic;
using Core.Domain.Accounts;

namespace Tests.Web.FakeData
{
    public static class FakeAccountData
    {
        public static Account GetOne()
        {
            return Account.Build("TESTACCOUNT3", "US2264", 2);
        }

        public static IList<Account> GetList()
        {
            return new List<Account>
            {
                Account.Build("TESTACCOUNT1", "US2034", 1),
                Account.Build("TESTACCOUNT2", "US2059", 2)
            };
        }
    }
}
