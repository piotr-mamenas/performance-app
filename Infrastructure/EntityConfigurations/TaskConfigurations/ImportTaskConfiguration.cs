using Core.Domain.Tasks;

namespace Infrastructure.EntityConfigurations.TaskConfigurations
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
