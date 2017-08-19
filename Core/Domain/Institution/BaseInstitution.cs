using System.Collections.Generic;
using Core.Domain.Partner;

namespace Core.Domain.Institution
{
    public class BaseInstitution
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<BasePartner> Partners { get; set; }
    }
}
