using Core.Domain.Partners;
using Core.Interfaces;

namespace Core.Domain.Contacts
{
    public class Contact : BaseEntity, IEntityRoot
    {
        public string Name { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public Partner Partner { get; set; }
        public int PartnerId { get; set; }

        protected Contact()
        {
        }
    }
}
