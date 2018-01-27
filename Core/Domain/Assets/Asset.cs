using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain.Portfolios;
using Core.Interfaces;

namespace Core.Domain.Assets
{
    public class Asset : BaseEntity, IEntityRoot
    {
        public string Name { get; set; }

        public string Isin { get; set; }

        public AssetClass Class { get; set; }
        public int ClassId { get; set; }
        
        public ICollection<Portfolio> Portfolios { get; set; }

        public ICollection<AssetPrice> Prices { get; set; }

        public Asset()
        {
            Prices = null;
            Portfolios = null;
        }

        /// <summary>
        /// Calculates partial Holding Period Return for a larger period
        /// </summary>
        /// <param name="dateFrom">Beginning of partial period</param>
        /// <param name="dateTo">End of partial period</param>
        /// <param name="income">Income for the partial period</param>
        /// <returns></returns>
        private decimal CalculateHoldingPeriodPeriodicReturn(DateTime dateFrom, DateTime dateTo, decimal income)
        {
            var initialPrice = Prices.Where(p => p.Timestamp.Date == dateFrom.Date)
                .Select(p => p.Amount)
                .SingleOrDefault();

            var maturityPrice = Prices.Where(p => p.Timestamp.Date == dateTo.Date)
                .Select(p => p.Amount)
                .SingleOrDefault();

            return income + (maturityPrice - initialPrice) / initialPrice;
        }

        /// <summary>
        /// Calculates the Holding Period Return
        /// </summary>
        /// <param name="periodDictionary">(Key=BeginDate, Value=EndDate)</param>
        /// <param name="incomes">Can be several for one period</param>
        /// <returns></returns>
        public decimal CalculateHoldingPeriodReturn(IDictionary<DateTime,DateTime> periodDictionary, IDictionary<DateTime,decimal> incomes)
        {
            var holdingPeriodReturn = 0.00m;
            var index = 0;

            foreach(var period in periodDictionary)
            {
                var periodFrom = period.Key;
                var periodTo = period.Value;

                var incomeForPeriod = incomes.Where(i => i.Key >= periodFrom && i.Key <= periodTo)
                    .Select(i => i.Value)
                    .Sum();

                var periodicReturn = CalculateHoldingPeriodPeriodicReturn(periodFrom, periodTo, incomeForPeriod);

                if (index == 0)
                {
                    holdingPeriodReturn = periodicReturn;
                }
                else
                {
                    holdingPeriodReturn = holdingPeriodReturn * (1 + periodicReturn);
                }
                index++;
            }

            return holdingPeriodReturn - 1;
        }
    }
}
