using Template.Models;
using System.Threading.Tasks;

namespace Template.Common.Interfaces
{



    /// <summary>
    /// Interface for authenticating the user
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Current user details
        /// </summary>
        User User { get; }


        /// <summary>
        /// Authenticate the user
        /// </summary>
        /// <returns></returns>
        Task<bool> AuthenticateAsync(string username = "", string password = "");


        /// <summary>
        /// Load the crendetials from cache (if available)
        /// </summary>
        /// <returns></returns>
        Task<bool> LoadCredentialsAsync();


        /// <summary>
        /// Logout the user
        /// </summary>
        /// <returns></returns>
        Task<bool> LogOutAsync();


        /// <summary>
        /// Return if the user is authenticated
        /// </summary>
        /// <returns></returns>
        bool IsAuthenticated();
    }
}
