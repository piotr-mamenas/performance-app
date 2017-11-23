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
                Name = "Base Template Report",
                Description = "Description of the Report",
                ReportHash = "AB#$*9d8d320dsdsoas#212:sd"
            });
        }
    }
}
