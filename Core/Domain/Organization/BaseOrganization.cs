using Core.Domain.Partner;

namespace Core.Domain.Organization
{
    public class BaseOrganization
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public BasePartner Partner { get; set; }
    }
}
