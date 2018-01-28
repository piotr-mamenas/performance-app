using Core.Domain.Assets;
using Core.Domain.Portfolios;
using Core.Enums;

namespace Core.Domain.Returns
{
    public class HoldingPeriodReturn : Return
    {
        public Periodicity Periodicity { get; set; }

        public decimal Rate { get; set; }

        public Asset Asset { get; set; }
        public int AssetId { get; set; }

        public Portfolio Portfolio { get; set; }
        public int PortfolioId { get; set; }
    }
}
