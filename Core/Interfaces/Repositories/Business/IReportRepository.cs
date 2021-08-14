using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Reports;

namespace Core.Interfaces.Repositories.Business
{
    public interface IReportRepository
    {
        Task<IEnumerable<Report>> GetAllReportsAsync();
    }
}