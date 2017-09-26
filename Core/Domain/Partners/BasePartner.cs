using System.Collections.Generic;
using Core.Domain.Accounts;
using Core.Domain.Contacts;
using Core.Domain.Institutions;

namespace Core.Domain.Partners
{
    public abstract class BasePartner<T> : BaseEntity<T> where T: BasePartner<T>, new()
    {
        public string Name { get; set; }

        public string Number { get; set; }

        public ICollection<Institution> Institutions { get; set; }

        public ICollection<Contact> Contacts { get; set; }

        public ICollection<Account> Accounts { get; set; }

        protected BasePartner()
        {
            Institutions = null;
            Contacts = null;
            Accounts = null;
        }
    }
}
