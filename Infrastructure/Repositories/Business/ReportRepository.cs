using Core.Domain.Reports;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class ReportRepository<TSpecificEntity> : Repository<TSpecificEntity>, IReportRepository<TSpecificEntity> where TSpecificEntity : Report
    {
        public ReportRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
