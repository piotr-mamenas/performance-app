using System.Collections.Generic;

namespace Core.Domain.Partners
{
    public class PartnerType : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Partner> Partners { get; set; }

        protected PartnerType()
        {
            Partners = null;
        }
    }
}
