using System.Collections.Generic;

namespace Core.Dtos
{
    public class InstitutionDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<PartnerDto> Partners { get; set; }
    }
}
