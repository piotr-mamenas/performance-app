using System.Collections.Generic;
using Core.Domain.Accounts;
using Core.Domain.Institutions;
using Core.Interfaces;

namespace Core.Domain.Partners
{
    public class Partner : BaseEntity, IEntityRoot
    {
        public string Name { get; set; }

        public string Number { get; set; }

        public ICollection<Institution> Institutions { get; set; }

        public ICollection<PartnerContact> Contacts { get; set; }

        public ICollection<Account> Accounts { get; set; }

        public Partner()
        {
            Institutions = null;
            Contacts = null;
            Accounts = null;
        }
    }
}
