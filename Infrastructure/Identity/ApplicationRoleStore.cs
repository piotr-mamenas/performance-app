using System.Data.Entity;
using Core.Domain.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Infrastructure.Identity
{
    public class ApplicationRoleStore : RoleStore<Role, string, UserRole>,
        IRoleStore<Role>
    {
        public ApplicationRoleStore(DbContext context)
            : base(context)
        {
        }
    }
}
