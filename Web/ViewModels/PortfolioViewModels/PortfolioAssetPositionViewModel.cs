using System;
using System.ComponentModel;
using Web.ViewModels.BaseData;

namespace Web.ViewModels.PortfolioViewModels
{
    public class PortfolioAssetPositionViewModel
    {
        public int Id { get; set; }

        [DisplayName("Position Amount")]
        public decimal Amount { get; set; }

        [DisplayName("Position Currency")]
        public CurrencyViewModel Currency { get; set; }

        [DisplayName("Position Asset")]
        public PortfolioAssetViewModel Asset { get; set; }

        [DisplayName("Position Timestamp")]
        public DateTime Timestamp { get; set; }
    }
}