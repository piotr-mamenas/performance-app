using System.Data.Entity.ModelConfiguration;
using Core.Domain.Tasks;

namespace Infrastructure.EntityConfigurations.TaskConfigurations
{
    public class ImportTaskConfiguration : EntityTypeConfiguration<ImportTask>
    {
        public ImportTaskConfiguration()
        {
            Property(i => i.Path)
                .HasColumnName("ImportPath")
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}
