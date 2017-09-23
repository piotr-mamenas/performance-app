using System;
using System.ComponentModel;

namespace Service.Dtos
{
    public class PositionDto
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
