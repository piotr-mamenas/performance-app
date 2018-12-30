using System;
using System.Collections.Generic;
using Core.Domain.Portfolios;
using Core.Domain.Returns;
using Core.Enums.Domain;
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

        public ICollection<Return> Returns { get; set; }

        public void CalculateReturn(ReturnType returnType, IEnumerable<Tuple<DateTime, DateTime>> periods, IEnumerable<Tuple<decimal, DateTime>> incomes)
        {
            switch (returnType)
            {
                case ReturnType.HoldingPeriodReturn:
                    var holdingPeriodReturn = new HoldingPeriodReturn(periods, incomes);
                    holdingPeriodReturn.Calculate();
                    Returns.Add(holdingPeriodReturn);
                    break;
            }
        }

        protected Asset()
        {
            Prices = null;
            Portfolios = null;
            Returns = null;
        }
    }
}
