using System.Collections.Generic;
using Service.Dtos.Partner;

namespace Service.Dtos.Institution
{
    public class InstitutionDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<PartnerDto> Partners { get; set; }

        public string Bic { get; set; }
    }
}
