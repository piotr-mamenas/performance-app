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

            Property(st => st.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("TaskId");

            Property(st => st.Name)
                .HasColumnName("TaskName")
                .HasMaxLength(255)
                .IsRequired();

            Property(st => st.Description)
                .HasColumnName("TaskDescription")
                .HasMaxLength(1024);

            Property(st => st.Parameters)
                .HasColumnName("TaskJsonParameters")
                .HasMaxLength(2048);

            HasRequired(st => st.Type)
                .WithMany(t => t.Tasks)
                .HasForeignKey(t => t.TypeId);

            HasMany(st => st.Runs)
                .WithRequired(tr => tr.Task)
                .HasForeignKey(tr => tr.TaskId);

            // TODO: Solve
            Map<ImportTask>(p => p.Requires("TaskType").HasValue((int)Core.Enums.Domain.TaskType.Import));
            Map<ExportTask>(p => p.Requires("TaskType").HasValue((int)Core.Enums.Domain.TaskType.Export));
        }
    }
}
