using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Reports;

namespace Core.Interfaces.Repositories.Business
{
    public interface IReportRepository<TSpecificEntity> : IRepository<TSpecificEntity> where TSpecificEntity : Report
    {
        Task<IEnumerable<Report>> GetAllReportsAsync();
    }
}