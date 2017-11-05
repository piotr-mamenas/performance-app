using Core.Domain.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Infrastructure.Identity
{
    public class ApplicationRoleStore : RoleStore<Role, string, UserRole>,
        IRoleStore<Role>
    {
        public ApplicationRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
