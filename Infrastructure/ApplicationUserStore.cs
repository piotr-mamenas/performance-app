using System.Data.Entity;
using Core.Domain.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Infrastructure
{
    public class ApplicationUserStore : UserStore<ApplicationUser, ApplicationRole, string, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>,
        IUserStore<ApplicationUser>
    {
        public ApplicationUserStore(DbContext context)
            : base(context) { }
    }
}
