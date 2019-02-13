using System.Collections.Generic;
using System.ComponentModel;
using Service.Dtos.Account;
using Service.Dtos.Contact;
using Service.Dtos.Institution;

namespace Service.Dtos.Partner
{
    public class PartnerDto
    {
        public int Id { get; set; }

        [DisplayName("Partner Name")]
        public string Name { get; set; }

        [DisplayName("Partner Number")]
        public string Number { get; set; }

        [DisplayName("Partner Type")]
        public string TypeName { get; set; }

        public ICollection<InstitutionDto> Institutions { get; set; }

        public ICollection<AccountDto> Accounts { get; set; }

        public ICollection<ContactDto> Contacts { get; set; }
    }
}
