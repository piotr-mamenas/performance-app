﻿using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public static Partner Build(string name, string number)
        {
            return new Partner
            {
                Name = name,
                Number = number
            };
        }

        protected Partner()
        {
            Institutions = null;
            Contacts = null;
            Accounts = null;
        }
        
        public bool CanDelete (out string errorMessage)
        {
            errorMessage = string.Empty;
            if (Contacts.Any())
            {
                errorMessage = "Partner has existing Contacts";
                return false;
            }

            if (Accounts.Any())
            {
                errorMessage = "Partner has existing Accounts";
                return false;
            }
            
            return true;
        }
    }
}
