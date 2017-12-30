using System.Data.Entity;
using Core.Domain.Reports;

namespace Infrastructure.Seed.TestData
{
    public class ReportSeeder : BaseSeeder<Report>, ITestData
    {
        public ReportSeeder(IDbSet<Report> reports)
            : base(reports)
        {
            SeededEntities.Add(new Report
            {
                Id = 1,
                Name = "templateA.pdf",
                Description = "Description of the Report",
                ReportHash = "12390ddxcs32xccds"
            });
            SeededEntities.Add(new Report
            {
                Id = 2,
                Name = "templateB.pdf",
                Description = "Description of the Report",
                ReportHash = "sdfdsf234dfxDK4xss"
            });
            SeededEntities.Add(new Report
            {
                Id = 3,
                Name = "templateC.pdf",
                Description = "Description of the Report",
                ReportHash = "SJIJD2ewzxc920dxp"
            });
        }
    }
}
