using System.Collections.Generic;
using System.ComponentModel;

namespace Service.Dtos
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
