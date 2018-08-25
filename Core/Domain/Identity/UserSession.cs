using System;

namespace Core.Domain.Identity
{
    public class UserSession : BaseEntity
    {
        public User User { get; set; }
        public string UserId { get; set; }
        
        public string AuthenticationToken { get; set; }

        public DateTime SessionStart { get; set; }

        public DateTime SessionEnd { get; set; }
    }
}
