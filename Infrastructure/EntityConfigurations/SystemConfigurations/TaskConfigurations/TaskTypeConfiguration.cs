using Core.Domain.Tasks;

namespace Infrastructure.EntityConfigurations.SystemConfigurations.TaskConfigurations
{
    public class TaskTypeConfiguration : BaseEntityConfiguration<TaskType>
    {
        public TaskTypeConfiguration()
        {
            ToTable("TaskType");

            Property(tt => tt.Name)
                .HasColumnName("TaskTypeName")
                .IsRequired();

            Property(tt => tt.Description)
                .HasColumnName("TaskTypeDescription")
                .IsRequired();
        }
    }
}
