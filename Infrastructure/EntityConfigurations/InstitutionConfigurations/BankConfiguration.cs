using System.Data.Entity.ModelConfiguration;
using Core.Domain.Institutions;

namespace Infrastructure.EntityConfigurations.InstitutionConfigurations
{
    public class BankConfiguration : EntityTypeConfiguration<Bank>
    {
        public BankConfiguration()
        {
            Property(b => b.Bic)
                .HasColumnName("BankBicCode")
                .HasMaxLength(11);
        }
    }
}
