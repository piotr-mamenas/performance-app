﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Core.Domain.Reports;
using Core.Interfaces.Repositories.Business;

namespace Infrastructure.Repositories.Business
{
    public class ReportRepository : Repository<Report>, IReportRepository
    {
        public ReportRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Report>> GetAllReportsAsync()
        {
            return await Context.Reports.ToListAsync();
        }
    }
}
