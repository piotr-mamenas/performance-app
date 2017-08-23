using System;
using System.Collections.Generic;
using Core.Domain.Partner;

namespace Core.Domain.Account
{
    public class BaseAccount
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }
        
        public DateTime DateCreated { get; set; }

        public DateTime DateClosed { get; set; }

        public virtual ICollection<BasePartner> Partners { get; set; }
        
    }
}
