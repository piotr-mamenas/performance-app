using System;
using Core.Domain.Partners;
using Core.Interfaces;

namespace Core.Domain.Accounts
{
    /// <summary>
    /// 
    /// </summary>
    public class Account : BaseAccount<Account>, IEntityRoot
    {
        public void OpenNewAccount(string name, string number, Partner partner)
        {
            Name = name;
            Number = number;
            OpenedDate = DateTime.Today;
            Partners.Add(partner);
        }

        private string GetAccountNumber(Partner partner)
        {
            return "";
        }
    }
}
