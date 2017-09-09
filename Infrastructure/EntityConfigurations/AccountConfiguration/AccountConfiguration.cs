using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Core.Domain.Accounts;

namespace Infrastructure.EntityConfigurations.AccountConfiguration
{
    public class AccountConfiguration : EntityTypeConfiguration<Account>
    {
        public AccountConfiguration()
        {
            Property(a => a.IsDeleted).HasColumnName("IsDeleted");

            HasKey(a => a.Id);

            ToTable("Account");

            Property(a => a.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("AccountId");

            Property(a => a.Name)
                .HasColumnName("AccountName")
                .HasMaxLength(255);

            Property(a => a.Number)
                .HasColumnName("AccountNumber")
                .HasMaxLength(127);

            Property(a => a.OpenedDate)
                .HasColumnType(DatabaseVendorTypes.TimestampField)
                .IsRequired();

            Property(a => a.ClosedDate)
                .HasColumnType(DatabaseVendorTypes.TimestampField)
                .IsOptional();
        }
    }
}