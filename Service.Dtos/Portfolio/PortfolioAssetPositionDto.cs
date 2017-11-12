using System;
using System.ComponentModel;
using Service.Dtos.Asset;
using Service.Dtos.BaseData;

namespace Service.Dtos.Portfolio
{
    public class PortfolioAssetPositionDto
    {
        public int Id { get; set; }

        [DisplayName("Position Amount")]
        public decimal Amount { get; set; }

        [DisplayName("Position Currency")]
        public CurrencyDto Currency { get; set; }

        [DisplayName("Position Asset")]
        public AssetDto Asset { get; set; }



        [DisplayName("Position Timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
