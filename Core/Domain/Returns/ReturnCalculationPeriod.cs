using System;

namespace Core.Domain.Returns
{
    public class ReturnCalculationPeriod : BaseEntity
    {
        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public Return Return { get; set; }
        public int ReturnId { get; set; }
    }
}
