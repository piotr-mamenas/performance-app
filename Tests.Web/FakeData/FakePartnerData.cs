using System.Collections.Generic;
using Core.Domain.Partners;

namespace Tests.Web.FakeData
{
    public static class FakePartnerData
    {
        public static IList<Partner> GetList()
        {
            return new List<Partner>
            {
                Partner.Build("TESTPARTNER1", "PARTNERNUMBER1"),
                Partner.Build("TESTPARTNER1", "PARTNERNUMBER1")
            };
        }
    }
}
