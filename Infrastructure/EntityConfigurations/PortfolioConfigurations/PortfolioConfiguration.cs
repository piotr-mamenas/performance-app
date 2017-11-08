using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Core.Domain.Portfolios;

namespace Infrastructure.EntityConfigurations.PortfolioConfigurations
{
    public class PortfolioConfiguration : EntityTypeConfiguration<Portfolio>
    {
        public PortfolioConfiguration()
        {
            Property(c => c.IsDeleted).HasColumnName("IsDeleted");

            HasKey(p => p.Id);

            ToTable("Portfolio");

            Property(o => o.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("PortfolioId");

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("PortfolioName");

            HasRequired(b => b.Account)
                .WithMany(c => c.Portfolios)
                .WillCascadeOnDelete(false);
        }
    }
}
