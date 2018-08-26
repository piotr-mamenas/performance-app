using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Identity;

namespace Infrastructure.Services
{
    public interface ISessionService
    {
        Task<string> StartSession(string userName);
        Task<bool> IsTokenValidAsync(string authToken);
        Task<bool> IsUserTokenValidAsync(string userName);
        Task<User> GetCurrentUserByAuthenticationTokenAsync(string authToken);
    }

    public class SessionService : ISessionService
    {
        private const int SessionTimeout = 20;
        private readonly ApplicationDbContext _dbContext;
        public SessionService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Starts a new session for User
        /// </summary>
        /// <returns>Authentication Token</returns>
        public async Task<string> StartSession(string userName)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.UserName == userName);

            var newSession = UserSession.Build(user);
            _dbContext.UserSessions.Add(newSession);
            await _dbContext.SaveChangesAsync();

            return newSession.AuthenticationToken;
        }

        public async Task<bool> IsTokenValidAsync(string authToken)
        {
            var currentSession = await _dbContext.UserSessions
                .SingleOrDefaultAsync(us => us.AuthenticationToken == authToken && us.SessionEnd == null);

            return await _isSessionValid(currentSession);
        }

        public async Task<bool> IsUserTokenValidAsync(string userName)
        {
            var currentSession = await _dbContext.UserSessions
                .Include(us => us.User)
                .SingleOrDefaultAsync(us => us.User.UserName == userName && us.SessionEnd == null);

            return await _isSessionValid(currentSession);
        }

        public async Task<User> GetCurrentUserByAuthenticationTokenAsync(string authToken)
        {
            var currentSession = await _dbContext.UserSessions
                .Include(us => us.User)
                .Include(us => us.User.Roles)
                .SingleOrDefaultAsync(us => us.AuthenticationToken == authToken && us.SessionEnd == null);

            var isSessionValid = await _isSessionValid(currentSession);
            if (!isSessionValid)
            {
                return null;
            }

            return currentSession?.User;
        }

        private async Task<bool> _isSessionValid(UserSession session)
        {
            if (session == null)
            {
                return false;
            }

            var currentTime = DateTime.Now;
            if (currentTime - session.SessionStart > TimeSpan.FromMinutes(SessionTimeout))
            {
                session.SessionEnd = DateTime.Now;
                await _dbContext.SaveChangesAsync();
                return false;
            }

            return true;
        }
    }
}
