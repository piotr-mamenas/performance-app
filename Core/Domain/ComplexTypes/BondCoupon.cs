using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.ComplexTypes
{
    [ComplexType]
    public class BondCoupon
    {
        /// <summary>
        /// 
        /// </summary>
        public decimal Rate
        {
            get => Rate;

            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal Amount { get; set; }
    }
}
