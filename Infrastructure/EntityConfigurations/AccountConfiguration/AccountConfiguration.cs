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

            ToTable("tbl_Account");

            Property(a => a.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("AccountId");

            Property(a => a.Name)
                .HasColumnName("AccountName")
                .HasMaxLength(255);

            Property(a => a.Number)
                .HasColumnName("AccountNumber")
                .HasMaxLength(127);

            Property(a => a.DateCreated)
                .HasColumnType("datetime2")
                .IsRequired();

            Property(a => a.DateClosed)
                .HasColumnType("datetime2")
                .IsOptional();
        }
    }
}