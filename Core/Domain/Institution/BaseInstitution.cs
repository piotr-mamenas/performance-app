using System.Collections.Generic;
using Core.Domain.Partner;
using Core.Enums;
using Core.Enums.Domain;

namespace Core.Domain.Institution
{
    public class BaseInstitution
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<BasePartner> Partners { get; set; }

        public string Bic { get; set; }
    }
}
