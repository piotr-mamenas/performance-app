using System.ComponentModel;

namespace Core.Dtos
{
    public class AccountDto
    {
        public int Id { get; set; }

        [DisplayName("Account Name")]
        public string Name { get; set; }

        [DisplayName("Account Number")]
        public string Number { get; set; }
    }
}
