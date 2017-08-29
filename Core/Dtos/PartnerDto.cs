using System.Collections.Generic;
using System.ComponentModel;

namespace Core.Dtos
{
    public class PartnerDto
    {
        public int Id { get; set; }

        [DisplayName("Partner Name")]
        public string Name { get; set; }

        [DisplayName("Partner Number")]
        public string Number { get; set; }

        public ICollection<InstitutionDto> Organizations { get; set; }
    }
}
