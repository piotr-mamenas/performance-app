using System.Data.Entity;
using Core.Domain.Accounts;
using Core.Domain.Workflows;

namespace Infrastructure.Seed.BaseData
{
    public class WorkflowStatusSeeder : BaseSeeder<WorkflowStatus>, IBaseData
    {
        public WorkflowStatusSeeder(IDbSet<WorkflowStatus> statuses)
            : base(statuses)
        {
            SeededEntities.Add(new WorkflowStatus
            {
                Id = 1,
                Name = "Account Opened Status",
                IsDeleted = false,
                IsEnabled = true,
                Code = 1000000001,
                Caption = "Opened"
            });

            SeededEntities.Add(new WorkflowStatus
            {
                Id = 2,
                Name = "Account Closed Status",
                IsDeleted = false,
                IsEnabled = true,
                Code = 1000000002,
                Caption = "Closed"
            });

            SeededEntities.Add(new WorkflowStatus
            {
                Id = 3,
                Name = "Account Reopened Status",
                IsDeleted = false,
                IsEnabled = true,
                Code = 1000000003,
                Caption = "Reopened"
            });
        }
    }
}
