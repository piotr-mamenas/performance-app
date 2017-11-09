using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Core.Domain.Portfolios;

namespace Infrastructure.EntityConfigurations.PositionConfigurations
{
    public class PositionConfiguration : EntityTypeConfiguration<PortfolioAssetPosition>
    {
        public PositionConfiguration()
        {
            Property(c => c.IsDeleted).HasColumnName("IsDeleted");

            HasKey(p => p.Id);

            ToTable("Position");

            Property(o => o.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("PositionId");

            Property(p => p.Amount)
                .HasColumnName("PositionAmount")
                .HasPrecision(16, 3)
                .IsRequired();

            Property(p => p.Timestamp)
                .HasColumnType(DatabaseVendorTypes.TimestampField)
                .HasColumnName("PositionTimestamp")
                .IsRequired();

            HasRequired(p => p.Currency)
                .WithMany(c => c.Positions)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.Portfolio)
                .WithMany(c => c.Positions)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.Asset)
                .WithMany(c => c.Positions)
                .WillCascadeOnDelete(false);
        }
    }
}
