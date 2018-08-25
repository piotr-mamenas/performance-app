using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AuthenticationService
    {
        private readonly ApplicationDbContext _dbContext;
        public AuthenticationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ValidateToken(string authToken, string userId)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == userId);

            
        }
    }
}
