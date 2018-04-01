using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain.Accounts;
using Core.Domain.Assets;
using Core.Enums.Domain;
using Core.Interfaces;

namespace Core.Domain.Portfolios
{
    public class Portfolio : BaseEntity, IEntityRoot
    {
        public string Number { get; set; }

        public string Name { get; set; }

        public Account Account { get; set; }
        public int AccountId { get; set; }

        public ICollection<Asset> Assets { get; set; }

        public ICollection<PortfolioAssetPosition> Positions { get; set; }

        public Portfolio()
        {
            Assets = null;
            Positions = null;
        }

        public void CalculateReturn(ReturnType returnType, IEnumerable<Tuple<DateTime, DateTime>> periods)
        {
            foreach (var asset in Assets)
            {
                var periodPositions = Positions.Where(p => p.AssetId == asset.Id);

                foreach (var period in periods)
                {
                    periodPositions = periodPositions.Where(pp => pp.Timestamp >= period.Item1 && pp.Timestamp <= period.Item2);
                }

                var periodIncomes = periodPositions.Select(p => new Tuple<decimal, DateTime>(p.Amount, p.Timestamp));
                asset.CalculateReturn(ReturnType.HoldingPeriodReturn, periods, periodIncomes);
            }
        }

        public void PlaceOrder(PortfolioOperationOrder order)
        {
            // TODO: Logic
        }
    }
}
