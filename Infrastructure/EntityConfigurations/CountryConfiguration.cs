using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Core.Domain.Countries;

namespace Infrastructure.EntityConfigurations
{
    public class CountryConfiguration : EntityTypeConfiguration<Country>
    {
        public CountryConfiguration()
        {
            HasKey(c => c.Id);

            ToTable("tbl_Country");

            Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("CountryId");

            Property(c => c.Name)
                .HasMaxLength(255)
                .IsRequired()
                .HasColumnName("CountryName");

            Property(c => c.Code)
                .HasMaxLength(2)
                .HasColumnName("CountryCode");

            Property(c => c.IsEnabled)
                .HasColumnName("CountryEnabled");
        }
    }
}
