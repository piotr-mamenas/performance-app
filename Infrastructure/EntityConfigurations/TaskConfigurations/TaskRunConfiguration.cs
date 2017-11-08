using System.Data.Entity.ModelConfiguration;
using Core.Domain.Tasks;

namespace Infrastructure.EntityConfigurations.TaskConfigurations
{
    public class TaskRunConfiguration : EntityTypeConfiguration<TaskRun>
    {
        public TaskRunConfiguration()
        {
            Property(t => t.IsDeleted).HasColumnName("IsDeleted");

            HasKey(t => t.Id);

            ToTable("TaskRun");

            Property(tr => tr.StartTimestamp)
                .HasColumnType(DatabaseVendorTypes.TimestampField)
                .IsRequired();

            Property(tr => tr.EndTimestamp)
                .HasColumnType(DatabaseVendorTypes.TimestampField);

            Property(tr => tr.Progress)
                .HasColumnName("TaskProgress")
                .HasPrecision(1, 2);

            HasRequired(tr => tr.Task)
                .WithMany(t => t.Runs)
                .WillCascadeOnDelete(false);
        }
    }
}
