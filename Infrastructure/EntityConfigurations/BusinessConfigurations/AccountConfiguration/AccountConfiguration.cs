using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Accounts;

namespace Infrastructure.EntityConfigurations.BusinessConfigurations.AccountConfiguration
{
    public class AccountConfiguration : BaseEntityConfiguration<Account>
    {
        public AccountConfiguration()
        {
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

            HasMany(a => a.Portfolios)
                .WithRequired(p => p.Account)
                .HasForeignKey(p => p.AccountId)
                .WillCascadeOnDelete(false);

            Property(a => a.OpenedDate)
                .HasColumnType(DatabaseVendorTypes.TimestampField)
                .IsRequired();

            Property(a => a.ClosedDate)
                .HasColumnType(DatabaseVendorTypes.TimestampField)
                .IsOptional();
        }
    }
}