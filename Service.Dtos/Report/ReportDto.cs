using System.ComponentModel;

namespace Service.Dtos.Report
{
    public class ReportDto
    {
        public int? Id { get; set; }

        [DisplayName("Report Name")]
        public string Name { get; set; }

        [DisplayName("Report Description")]
        public string Description { get; set; }

        public string ReportHash { get; set; }
    }
}
