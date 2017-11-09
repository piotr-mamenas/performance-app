using System.Collections.Generic;
using System.ComponentModel;
using Service.Dtos.Partner;

namespace Service.Dtos.Portfolio
{
    public class PortfolioDto
    {
        public int Id { get; set; }

        [DisplayName("Portfolio Number")]
        public string Number { get; set; }

        [DisplayName("Portfolio Name")]
        public string Name { get; set; }
        
        public virtual ICollection<PartnerDto> Partners { get; set; }
    }
}
