using System;

namespace Core.Domain.Returns
{
    public class ReturnCalculationPeriod : BaseEntity
    {
        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public Return Return { get; set; }
        public int ReturnId { get; set; }

        protected ReturnCalculationPeriod()
        {
        }

        public static ReturnCalculationPeriod Build(DateTime dateFrom, DateTime dateTo, int returnId)
        {
            return new ReturnCalculationPeriod
            {
                DateFrom = dateFrom,
                DateTo = dateTo,
                ReturnId = returnId
            };
        }
    }
}
