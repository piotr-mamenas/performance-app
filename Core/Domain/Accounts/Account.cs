using System;
using System.Collections.Generic;
using Core.Domain.Partners;
using Core.Domain.Portfolios;
using Core.Interfaces;

namespace Core.Domain.Accounts
{
    /// <summary>
    /// 
    /// </summary>
    public class Account : BaseEntity, IEntityRoot
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

        /// <summary>
        /// The portfolios which belong to this account
        /// </summary>
        public ICollection<Portfolio> Portfolios { get; set; }
        
        #endregion

        #region Constructor

        public Account()
        {
            Partners = null;
            Portfolios = null;
        }

        public Account(string accountName, string accountNumber, Partner initialAccountOwner)
        {

            Name = accountName;
            Number = accountNumber;
            OpenedDate = DateTime.Today;
            Portfolios = null;

            Partners = new List<Partner>
            {
                initialAccountOwner
            };
        }
        #endregion
    }
}
