using System;
using Core.Enums.Domain;

namespace Core.Domain.Portfolios
{
    public class PortfolioOperationOrder
    {
        public PortfolioOperationType Type { get; set; }

        public int Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        public DateTime PlacedDate { get; set; }

        protected PortfolioOperationOrder()
        {
        }
    }
}
