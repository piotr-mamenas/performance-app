using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Workflows;

namespace Infrastructure.EntityConfigurations.SystemConfigurations.WorkflowConfigurations
{
    public class WorkflowStatusConfiguration : BaseEntityConfiguration<WorkflowStatus>
    {
        public WorkflowStatusConfiguration()
        {
            ToTable("WorkflowStatus");

            Property(ws => ws.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("WorkflowStatusId");

            Property(ws => ws.Name)
                .HasColumnName("WorkflowStatusName")
                .HasMaxLength(255)
                .IsRequired();

            Property(ws => ws.Code)
                .HasColumnName("WorkflowStatusCode")
                .IsRequired();

            Property(ws => ws.Designation)
                .HasColumnName("WorkflowStatusDesignation")
                .HasMaxLength(255)
                .IsRequired();

            HasMany(ws => ws.Workflows)
                .WithRequired(w => w.Status)
                .HasForeignKey(w => w.StatusId);
        }
    }
}
