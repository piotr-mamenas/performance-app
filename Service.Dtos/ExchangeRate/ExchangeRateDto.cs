using System;
using Service.Dtos.BaseData;

namespace Service.Dtos.ExchangeRate
{
    public class ExchangeRateDto
    {
        public int Id { get; set; }

        public CurrencyDto BaseCurrency { get; set; }
        public int BaseCurrencyId { get; set; }

        public CurrencyDto TargetCurrency { get; set; }
        public int TargetCurrencyId { get; set; }

        public decimal Rate { get; set; }

        public decimal Max { get; set; }

        public decimal Min { get; set; }

        public string Timestamp { get; set; }
    }
}
