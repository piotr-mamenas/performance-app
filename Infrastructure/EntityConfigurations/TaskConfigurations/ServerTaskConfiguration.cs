using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Tasks;
using Core.Enums.Domain;

namespace Infrastructure.EntityConfigurations.TaskConfigurations
{
    public class ServerTaskConfiguration : BaseEntityConfiguration<ServerTask>
    {
        public ServerTaskConfiguration()
        {
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

            HasMany(t => t.Runs)
                .WithRequired(tr => tr.Task)
                .HasForeignKey(tr => tr.TaskId)
                .WillCascadeOnDelete(false);

            Map<ImportTask>(p => p.Requires("TaskType").HasValue((int)TaskType.Import));
            Map<ExportTask>(p => p.Requires("TaskType").HasValue((int)TaskType.Export));
        }
    }
}
