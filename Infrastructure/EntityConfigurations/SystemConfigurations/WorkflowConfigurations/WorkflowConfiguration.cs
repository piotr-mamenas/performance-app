using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Workflows;

namespace Infrastructure.EntityConfigurations.SystemConfigurations.WorkflowConfigurations
{
    public class WorkflowConfiguration : BaseEntityConfiguration<Workflow>
    {
        public WorkflowConfiguration()
        {
            ToTable("Workflow");

            Property(w => w.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("WorkflowId");

            Property(w => w.Timestamp)
                .HasColumnType(DatabaseVendorTypes.TimestampField)
                .HasColumnName("WorkflowTimestamp")
                .IsRequired();

            HasRequired(w => w.Status)
                .WithMany(ws => ws.Workflows)
                .HasForeignKey(w => w.StatusId);
        }
    }
}
