using System.Collections.Generic;
using Core.Domain.Partners;
using Core.Interfaces;

namespace Core.Domain.Institutions
{
    public class Institution : BaseEntity<Institution>, IEntityRoot
    {
        public string Name { get; set; }

        public ICollection<Partner> Partners { get; set; }

        public Institution()
        {
            Partners = null;
        }
    }
}
