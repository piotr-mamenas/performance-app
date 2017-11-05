using Microsoft.AspNet.Identity.EntityFramework;

namespace Core.Domain.Identity
{
    public class Role : IdentityRole<string, UserRole>
    {
        public static string AdminRole = "Admin";
        public static string AssociateRole = "Associate";
    }
}
