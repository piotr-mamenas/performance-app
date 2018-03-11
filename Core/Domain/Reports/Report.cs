using Core.Interfaces;

namespace Core.Domain.Reports
{
    public class Report : BaseEntity, IEntityRoot
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ReportHash { get; set; }

        public void Generate()
        {
            
        }

        public void Download()
        {
            
        }
    }
}
