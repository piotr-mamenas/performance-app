using System.Data.Entity;
using Core.Domain.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Infrastructure.Identity
{
    public class ApplicationUserStore : UserStore<User, Role, string, UserLogin, UserRole, UserClaim>,
        IUserStore<User>
    {
        public ApplicationUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
