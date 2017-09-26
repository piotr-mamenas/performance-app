using System.Collections.Generic;
using Core.Domain.Partners;

namespace Core.Domain.Institutions
{
    public abstract class BaseInstitution<T> : BaseEntity<T> where T : BaseEntity<T>, new()
    {
        public string Name { get; set; }

        public ICollection<Partner> Partners { get; set; }

        protected BaseInstitution()
        {
            Partners = null;
        }
    }
}
