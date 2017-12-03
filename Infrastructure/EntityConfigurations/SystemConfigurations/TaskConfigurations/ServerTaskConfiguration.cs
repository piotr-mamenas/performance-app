using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Tasks;
using Core.Enums.Domain;

namespace Infrastructure.EntityConfigurations.SystemConfigurations.TaskConfigurations
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

            HasRequired(t => t.Type)
                .WithMany(t => t.Tasks)
                .HasForeignKey(t => t.TypeId);

            HasMany(t => t.Runs)
                .WithRequired(tr => tr.Task)
                .HasForeignKey(tr => tr.TaskId);

            // TODO: Solve
            Map<ImportTask>(p => p.Requires("TaskType").HasValue((int)Core.Enums.Domain.TaskType.Import));
            Map<ExportTask>(p => p.Requires("TaskType").HasValue((int)Core.Enums.Domain.TaskType.Export));
        }
    }
}
