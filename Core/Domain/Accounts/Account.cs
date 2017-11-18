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
        public DateTime? ClosedDate { get; set; }

        /// <summary>
        /// The partner which hold the right to the account
        /// </summary>
        public Partner Partner { get; set; }
        public int PartnerId { get; set; }

        /// <summary>
        /// The portfolios which belong to this account
        /// </summary>
        public ICollection<Portfolio> Portfolios { get; set; }
        
        #endregion

        #region Constructor

        public Account()
        {
            Portfolios = null;
        }

        public Account(string accountName, string accountNumber, Partner accountOwner)
        {
            Name = accountName;
            Number = accountNumber;
            OpenedDate = DateTime.Today;
            Portfolios = null;
            Partner = accountOwner;
        }
        #endregion
    }
}
