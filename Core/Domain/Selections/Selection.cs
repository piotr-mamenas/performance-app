using System.Collections.Generic;
using Core.Domain.Partners;
using Core.Domain.Portfolios;
using Core.Interfaces;

namespace Core.Domain.Selections
{
    public class Selection : BaseEntity, IEntityRoot
    {
        public ICollection<Partner> SelectedPartners { get; set; }

        public ICollection<Portfolio> SelectedPortfolios { get; set; }
    }
}
