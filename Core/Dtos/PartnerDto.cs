using System.Collections.Generic;

namespace Core.Dtos
{
    public class PartnerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public ICollection<InstitutionDto> Organizations { get; set; }

        public virtual ICollection<ContactDto> Contacts { get; set; }
    }
}
