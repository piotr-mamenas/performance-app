using System;
using System.Collections.Generic;
using Core.Domain.Assets;
using Core.Interfaces;

namespace Core.Domain.Returns
{
    public class Return : BaseEntity, IEntityRoot
    {
        public ICollection<ReturnIncome> Incomes { get; set; }

        public ICollection<ReturnCalculationPeriod> Periods { get; set; }

        public decimal Rate { get; set; }

        public DateTime CalculatedTime { get; set; }

        public Asset Asset { get; set; }
        public int AssetId { get; set; }
    }
}
