using System;

namespace Core.Domain.Returns
{
    public class ReturnIncome : BaseEntity
    {
        public DateTime Timestamp { get; set; }

        public decimal Amount { get; set; }

        public Return Return { get; set; }
        public int ReturnId { get; set; }

        protected ReturnIncome()
        {
        }

        public static ReturnIncome Build(decimal amount, DateTime timestamp, int returnId)
        {
            return new ReturnIncome
            {
                Amount = amount,
                ReturnId = returnId,
                Timestamp = timestamp
            };
        }
    }
}
