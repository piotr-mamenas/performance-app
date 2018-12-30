using System;
using System.Collections.Generic;
using Core.Domain.Partners;
using Core.Domain.Portfolios;
using Core.Domain.Workflows;
using Core.Interfaces;

namespace Core.Domain.Accounts
{
    /// <summary>
    /// 
    /// </summary>
    public class Account : BaseEntity, IEntityRoot
    {
        #region Properties
        public string Name { get; set; }

        /// <summary>
        /// The number of the account derived from the linked partner names
        /// </summary>
        public string Number { get; set; }

        public DateTime OpenedDate { get; set; }

        public DateTime? ClosedDate { get; set; }

        public Partner Partner { get; set; }
        public int PartnerId { get; set; }

        public WorkflowStatus Status { get; set; }
        public int StatusId { get; set; }

        public ICollection<Portfolio> Portfolios { get; set; }
        
        #endregion

        public static Account Build(string name, string number, int partnerId)
        {
            return new Account(name, number, partnerId);
        }

        public void Close()
        {
        }

        public void RequestClose()
        {
        }

        protected Account()
        {
            Portfolios = null;
        }

        private Account(string accountName, string accountNumber, int accountOwnerId)
        {
            Name = accountName;
            Number = accountNumber;
            OpenedDate = DateTime.Today;
            Portfolios = null;
            PartnerId = accountOwnerId;
            StatusId = WorkflowStatus.Initial;
        }
    }
}
