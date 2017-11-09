using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Core.Domain.Portfolios;

namespace Infrastructure.EntityConfigurations.PortfolioConfigurations
{
    public class PortfolioConfiguration : EntityTypeConfiguration<Portfolio>
    {
        public PortfolioConfiguration()
        {
            Property(p => p.IsDeleted).HasColumnName("IsDeleted");

            HasKey(p => p.Id);

            ToTable("Portfolio");

            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("PortfolioId");

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("PortfolioName");

            HasRequired(p => p.Account)
                .WithMany(a => a.Portfolios)
                .WillCascadeOnDelete(false);

            HasMany(c => c.Positions)
                .WithRequired(p => p.Portfolio)
                .HasForeignKey(p => p.PortfolioId)
                .WillCascadeOnDelete(false);
        }
    }
}
