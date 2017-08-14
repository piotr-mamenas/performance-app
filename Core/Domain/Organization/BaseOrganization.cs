using System.Collections.Generic;
using Core.Domain.Partner;

namespace Core.Domain.Organization
{
    public class BaseOrganization
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<BasePartner> Partners { get; set; }
    }
}
