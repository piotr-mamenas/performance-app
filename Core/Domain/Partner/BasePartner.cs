using System.Collections.Generic;
using Core.Domain.Contact;
using Core.Domain.Institution;
using Core.Enums;
using Core.Enums.Domain;

namespace Core.Domain.Partner
{
    public class BasePartner
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public ICollection<BaseInstitution> Organizations { get; set; }

        public virtual ICollection<BaseContact> Contacts { get; set; }
    }
}
