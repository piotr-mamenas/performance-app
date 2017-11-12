using Core.Domain.Tasks;

namespace Infrastructure.EntityConfigurations.SystemConfigurations.TaskConfigurations
{
    public class ExportTaskConfiguration : BaseEntityConfiguration<ExportTask>
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
