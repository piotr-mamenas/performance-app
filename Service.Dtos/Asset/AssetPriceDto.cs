using System;
using Service.Dtos.BaseData;

namespace Service.Dtos.Asset
{
    public class AssetPriceDto
    {
        public int Id { get; set; }

        public string AssetName { get; set; }
        public string ClassName { get; set; }
        public string Isin { get; set; }
        public int AssetId { get; set; }

        public string CurrencyCode { get; set; }
        public int CurrencyId { get; set; }

        public string Timestamp { get; set; }

        public decimal Amount { get; set; }
    }
}
