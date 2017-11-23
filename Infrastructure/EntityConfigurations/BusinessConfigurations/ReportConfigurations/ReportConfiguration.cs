using System.ComponentModel.DataAnnotations.Schema;
using Core.Domain.Reports;

namespace Infrastructure.EntityConfigurations.BusinessConfigurations.ReportConfigurations
{
    public class ReportConfiguration : BaseEntityConfiguration<Report>
    {
        public ReportConfiguration()
        {
            ToTable("Report");

            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("ReportId");

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("ReportName");

            Property(p => p.Description)
                .IsOptional()
                .HasMaxLength(1024)
                .HasColumnName("ReportDescription");

            Property(p => p.ReportHash)
                .IsOptional()
                .HasMaxLength(255)
                .HasColumnName("ReportHash");
        }
    }
}
