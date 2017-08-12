using System.Collections.Generic;
using Core.Domain.Contact;
using Core.Domain.Organization;

namespace Core.Domain.Partner
{
    public class BasePartner
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public BaseOrganization Organization { get; set; }

        public IEnumerable<BaseContact> Contact { get; set; }
    }
}
