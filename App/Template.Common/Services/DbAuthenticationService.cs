using Template.Common.Interfaces;
using Template.Models;

namespace Template.Common.Services
{
    /// <summary>
    /// Basic authentication service using the local database
    /// </summary>
    public class DbAuthenticationService : IAuthenticationService
    {
        /// <inheeritdoc/>
        public User User { get; private set; }


        /// <inheeritdoc/>
        public async Task<bool> AuthenticateAsync(string username = "", string password = "")
        {
            await Task.Delay(250);
            this.User = new User
            {
                UserId = "0",
                Name = username
            };
            return true;
        }


        /// <inheeritdoc/>
        public Task<bool> LoadCredentialsAsync()
        {
            return Task.FromResult(true);
        }


        /// <inheeritdoc/>
        public Task<bool> LogOutAsync()
        {
            this.User = null;
            return Task.FromResult(true);
        }


        /// <inheeritdoc/>
        public bool IsAuthenticated()
        {
            return this.User != null;
        }
    }
}
