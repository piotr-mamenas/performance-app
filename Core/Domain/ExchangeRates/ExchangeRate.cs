using System;
using Core.Domain.Currencies;
using Core.Interfaces;

namespace Core.Domain.ExchangeRates
{
    public class ExchangeRate : BaseEntity, IEntityRoot
    {
        public Currency BaseCurrency { get; set; }
        public int BaseCurrencyId { get; set; }

        public Currency TargetCurrency { get; set; }
        public int TargetCurrencyId { get; set; }

        public decimal Rate { get; set; }

        public decimal Max { get; set; }

        public decimal Min { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
