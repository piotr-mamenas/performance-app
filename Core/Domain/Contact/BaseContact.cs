using Core.Domain.Partner;

namespace Core.Domain.Contact
{
    public class BaseContact
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public BasePartner Partner { get; set; }

        public int PartnerId { get; set; }
    }
}
