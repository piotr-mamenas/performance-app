using Core.Domain.Partners;

namespace Core.Domain.Contacts
{
    public class BaseContact<T> : BaseEntity<T> where T : BaseEntity<T>, new()
    {
        public string Name { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public Partner Partner { get; set; }

        public int PartnerId { get; set; }
    }
}
