using Core.Interfaces;

namespace Core.Domain.Reports
{
    public class Report : BaseEntity, IEntityRoot
    {
        /// <summary>
        /// The short name of the report
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description what the report is about
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The hash representation of the file name on server
        /// </summary>
        public string ReportPath { get; set; }
    }
}
