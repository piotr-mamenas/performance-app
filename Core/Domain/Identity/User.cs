using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Domain.TileWidgets;
using Core.Enums;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Core.Domain.Identity
{
    public class User : IdentityUser<string, UserLogin, UserRole, UserClaim>
    {
        public Language Language { get; set; }

        public ICollection<TileWidget> TileWidgets { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }
    }
}