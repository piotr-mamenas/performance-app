using System.ComponentModel;
using Service.Dtos.Partner;

namespace Service.Dtos.Account
{
    public class AccountDto
    {
        public int Id { get; set; }

        [DisplayName("Account Name")]
        public string Name { get; set; }

        [DisplayName("Account Number")]
        public string Number { get; set; }

        [DisplayName("Opened Date")]
        public string DateOpened { get; set; }

        [DisplayName("Closed Date")]
        public string DateClosed { get; set; }
        
        [DisplayName("Account Partner")]
        public virtual PartnerDto Partner { get; set; }

        [DisplayName("Partner Id")]
        public int PartnerId { get; set; }
    }
}