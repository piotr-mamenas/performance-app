namespace Core.Dtos
{
    public class ContactDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public virtual PartnerDto Partner { get; set; }

        public int PartnerId { get; set; }
    }
}
