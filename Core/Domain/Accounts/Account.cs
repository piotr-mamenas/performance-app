using System;
using System.Collections.Generic;
using Core.Domain.Partners;
using Core.Interfaces;

namespace Core.Domain.Accounts
{
    /// <summary>
    /// 
    /// </summary>
    public class Account : BaseEntity<Account>, IEntityRoot
    {
        #region Properties
        /// <summary>
        /// The name of the account
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The number of the account derived from the linked partner names
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// The date at which the account was opened
        /// </summary>
        public DateTime OpenedDate { get; set; }

        /// <summary>
        /// The date at which the account was closed
        /// </summary>
        public DateTime ClosedDate { get; set; }

        /// <summary>
        /// The partners which hold the right to the account
        /// </summary>
        public ICollection<Partner> Partners { get; set; }

        #endregion

        #region Constructor

        public Account()
        {
            Partners = null;
        }
        #endregion

        #region Methods

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

        #endregion
    }
}
