using Core.Domain.Tasks;

namespace Infrastructure.EntityConfigurations.SystemConfigurations.TaskConfigurations
{
    public class TaskRunConfiguration : BaseEntityConfiguration<TaskRun>
    {
        public TaskRunConfiguration()
        {
            ToTable("TaskRun");

            Property(tr => tr.StartTimestamp)
                .HasColumnType(DatabaseVendorTypes.TimestampField)
                .IsRequired();

            Property(tr => tr.EndTimestamp)
                .HasColumnType(DatabaseVendorTypes.TimestampField);

            Property(tr => tr.Progress)
                .HasColumnName("TaskProgress");

            HasRequired(tr => tr.Task)
                .WithMany(t => t.Runs);
        }
    }
}
