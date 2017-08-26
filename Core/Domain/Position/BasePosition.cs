using System;
using Core.Domain.Assets;

namespace Core.Domain.Position
{
    public abstract class BasePosition<T> : BaseEntity<T> where T : BaseEntity<T>, new()
    {
        public decimal Amount { get; set; }

        public DateTime Timestamp { get; set; }

        public Asset Asset { get; set; }
    }
}
