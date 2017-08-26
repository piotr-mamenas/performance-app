using System.Collections.Generic;
using Core.Domain.Contacts;
using Core.Domain.Institutions;

namespace Core.Domain.Partners
{
    public abstract class BasePartner<T> : BaseEntity<T> where T: BasePartner<T>, new()
    {
        public string Name { get; set; }

        public string Number { get; set; }

        public ICollection<Institution> Organizations { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}
