using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Countries;

namespace Infrastructure.EntityConfigurations.BusinessConfigurations.CountryConfigurations
{
    public class CountryConfiguration : BaseEntityConfiguration<Country>
    {
        public CountryConfiguration()
        {
            ToTable("Country");

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

            HasRequired(c => c.Currency)
                .WithMany(c => c.Countries)
                .WillCascadeOnDelete(false);

            Property(c => c.IsEnabled)
                .HasColumnName("CountryEnabled");
        }
    }
}
