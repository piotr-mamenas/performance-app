using System.Collections.Generic;
using Core.Domain.Accounts;
using Core.Domain.Contacts;
using Core.Domain.Institutions;
using Core.Domain.Portfolios;
using Core.Interfaces;

namespace Core.Domain.Partners
{
    public class Partner : BaseEntity<Partner>, IEntityRoot
    {
        public string Name { get; set; }

        public string Number { get; set; }

        public ICollection<Institution> Institutions { get; set; }

        public ICollection<Contact> Contacts { get; set; }

        public ICollection<Account> Accounts { get; set; }

        public Partner()
        {
            Institutions = null;
            Contacts = null;
            Accounts = null;
        }
    }
}
