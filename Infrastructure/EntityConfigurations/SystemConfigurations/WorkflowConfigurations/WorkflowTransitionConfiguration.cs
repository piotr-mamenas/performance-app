using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Workflows;

namespace Infrastructure.EntityConfigurations.SystemConfigurations.WorkflowConfigurations
{
    public class WorkflowTransitionConfiguration : BaseEntityConfiguration<WorkflowTransition>
    {
        public WorkflowTransitionConfiguration()
        {
            ToTable("WorkflowTransition");

            Property(wt => wt.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("WorkflowTransitionId");

            Property(wt => wt.Caption)
                .HasColumnName("WorkflowTransitionCaption")
                .IsRequired()
                .HasMaxLength(255);

            Property(wt => wt.Name)
                .HasColumnName("WorkflowTransitionName")
                .IsRequired()
                .HasMaxLength(255);

            HasRequired(wt => wt.TransitionFrom).WithMany();

            HasRequired(wt => wt.TransitionTo).WithMany();
        }
    }
}
