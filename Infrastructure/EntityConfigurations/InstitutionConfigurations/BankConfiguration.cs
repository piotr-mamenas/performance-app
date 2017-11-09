using Core.Domain.Institutions;

namespace Infrastructure.EntityConfigurations.InstitutionConfigurations
{
    public class BankConfiguration : BaseEntityConfiguration<Bank>
    {
        public BankConfiguration()
        {
            Property(b => b.Bic)
                .HasColumnName("BankBicCode")
                .HasMaxLength(11);
        }
    }
}
