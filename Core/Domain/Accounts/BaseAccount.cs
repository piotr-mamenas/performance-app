using System;
using System.Collections.Generic;
using Core.Domain.Partners;

namespace Core.Domain.Accounts
{
    public class BaseAccount<T> : BaseEntity<T> where T : BaseEntity<T>, new()
    {
        public string Name { get; set; }

        public string Number { get; set; }
        
        public DateTime DateCreated { get; set; }

        public DateTime DateClosed { get; set; }

        public virtual ICollection<Partner> Partners { get; set; }
        
    }
}
