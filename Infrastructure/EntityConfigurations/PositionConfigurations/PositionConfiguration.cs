using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.SqlServer;
using Core.Domain.Positions;

namespace Infrastructure.EntityConfigurations.PositionConfigurations
{
    public class PositionConfiguration : EntityTypeConfiguration<Position>
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
                .HasColumnName("PositionTime")
                .IsRequired();

            HasRequired(p => p.Currency)
                .WithMany(c => c.Positions)
                .WillCascadeOnDelete(false);

            HasRequired(p => p.Asset)
                .WithMany(c => c.Positions)
                .WillCascadeOnDelete(false);
        }
    }
}
