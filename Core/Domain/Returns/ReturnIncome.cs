using System;

namespace Core.Domain.Returns
{
    public class ReturnIncome : BaseEntity
    {
        public DateTime Timestamp { get; set; }

        public decimal Amount { get; set; }

        public Return Return { get; set; }
        public int ReturnId { get; set; }
    }
}
