using System.Collections.Generic;
using Core.Domain.Contact;
using Core.Domain.Institution;

namespace Core.Domain.Partner
{
    public class BasePartner
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public ICollection<BaseInstitution> Organizations { get; set; }

        public ICollection<BaseContact> Contacts { get; set; }
    }
}
