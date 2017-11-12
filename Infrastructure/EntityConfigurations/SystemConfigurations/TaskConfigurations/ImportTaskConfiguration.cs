using Core.Domain.Tasks;

namespace Infrastructure.EntityConfigurations.SystemConfigurations.TaskConfigurations
{
    public class ImportTaskConfiguration : BaseEntityConfiguration<ImportTask>
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
