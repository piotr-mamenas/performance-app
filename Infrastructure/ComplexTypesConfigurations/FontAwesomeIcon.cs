using System.Data.Entity.ModelConfiguration;
using Core.Domain.TileWidgets;

namespace Infrastructure.ComplexTypesConfigurations
{
    public class FontAwesomeIconConfiguration : ComplexTypeConfiguration<FontAwesomeIcon>
    {
        public FontAwesomeIconConfiguration()
        {
            Property(fa => fa.Name)
                .IsRequired()
                .HasColumnName("IconName");
        }
    }
}
