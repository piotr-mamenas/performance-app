using System;
using System.Collections.Generic;
using Core.Domain.Partners;
using Core.Interfaces;

namespace Core.Domain.Accounts
{
    /// <summary>
    /// 
    /// </summary>
    public class Account : Entity<Account>, IEntityRoot
    {
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime OpenedDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime ClosedDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Partner> Partners { get; set; }
        #endregion

        #region Constructor

        public Account()
        {
            Partners = null;
        }
        #endregion

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
