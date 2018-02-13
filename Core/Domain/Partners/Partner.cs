using System.Collections.Generic;
using System.Linq;
using Core.Domain.Accounts;
using Core.Domain.Contacts;
using Core.Domain.Institutions;
using Core.Interfaces;

namespace Core.Domain.Partners
{
    public class Partner : BaseEntity, IEntityRoot
    {
        public string Name { get; set; }

        public string Number { get; set; }

        public PartnerType Type { get; set; }
        public int PartnerTypeId { get; set; }

        public ICollection<Institution> Institutions { get; set; }

        public ICollection<Contact> Contacts { get; set; }

        public ICollection<Account> Accounts { get; set; }

        public Partner()
        {
            Institutions = null;
            Contacts = null;
            Accounts = null;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ValidateDelete ()
        {
            if (Contacts.Any())
            {
                return "Partner has existing Contacts";
            }

            if (Accounts.Any())
            {
                return "Partner has existing Accounts";
            }

            return null;
        }
    }
}
