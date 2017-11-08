using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Core.Domain.Tasks;

namespace Infrastructure.EntityConfigurations.TaskConfigurations
{
    public class TaskConfiguration : EntityTypeConfiguration<Task>
    {
        public TaskConfiguration()
        {
            Property(t => t.IsDeleted).HasColumnName("IsDeleted");

            HasKey(t => t.Id);

            ToTable("Task");

            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("TaskId");

            Property(t => t.Name)
                .HasColumnName("TaskName")
                .HasMaxLength(255)
                .IsRequired();

            Property(t => t.Description)
                .HasColumnName("TaskDescription")
                .HasMaxLength(1024);
        }
    }
}
