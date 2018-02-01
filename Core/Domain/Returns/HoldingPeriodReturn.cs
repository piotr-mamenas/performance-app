﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain.Returns
{
    public class HoldingPeriodReturn : Return
    {
        public HoldingPeriodReturn()
        {
            
        }

        public HoldingPeriodReturn(ICollection<ReturnCalculationPeriod> periods, ICollection<ReturnIncome> incomes)
        {
            Periods = periods;
            Incomes = incomes;
        }

        /// <summary>
        /// Calculates partial Holding Period Return for a larger period
        /// </summary>
        /// <param name="dateFrom">Beginning of partial period</param>
        /// <param name="dateTo">End of partial period</param>
        /// <param name="income">Income for the partial period</param>
        /// <returns></returns>
        private decimal CalculatePeriodicReturn(DateTime dateFrom, DateTime dateTo, decimal income)
        {
            var initialPrice = Asset.Prices.Where(p => p.Timestamp.Date == dateFrom.Date)
                .Select(p => p.Amount)
                .SingleOrDefault();

            var maturityPrice = Asset.Prices.Where(p => p.Timestamp.Date == dateTo.Date)
                .Select(p => p.Amount)
                .SingleOrDefault();

            return income + (maturityPrice - initialPrice) / initialPrice;
        }

        /// <summary>
        /// Calculates the Holding Period Return
        /// </summary>
        /// <returns></returns>
        public void Calculate()
        {
            var holdingPeriodReturn = 0.00m;

            var index = 0;
            foreach (var period in Periods)
            {
                var periodFrom = period.DateFrom;
                var periodTo = period.DateTo;

                var incomeForPeriod = Incomes.Where(i => i.Timestamp >= periodFrom && i.Timestamp <= periodTo)
                    .Select(i => i.Amount)
                    .Sum();

                var periodicReturn = CalculatePeriodicReturn(periodFrom, periodTo, incomeForPeriod);

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

            CalculatedTime = DateTime.Now;
            Rate = holdingPeriodReturn - 1;
        }
    }
}
