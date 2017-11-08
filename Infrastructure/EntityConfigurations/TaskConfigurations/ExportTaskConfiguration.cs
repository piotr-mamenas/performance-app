using System.Data.Entity.ModelConfiguration;
using Core.Domain.Tasks;

namespace Infrastructure.EntityConfigurations.TaskConfigurations
{
    public class ExportTaskConfiguration : EntityTypeConfiguration<ExportTask>
    {
        public ExportTaskConfiguration()
        {
            Property(i => i.Path)
                .HasColumnName("ExportPath")
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}
