using System.Collections.Generic;

namespace Backend.Common.Interfaces
{
    /// <summary>
    /// Session provider to capture session information and make 
    /// it available to all classes by DI
    /// </summary>
    public interface ISessionProvider
    {
        /// <summary>
        /// Receives request headers
        /// </summary>
        Dictionary<string, string> RequestHeaders { get; }
        
        
        /// <summary>
        /// Receives the headers and setup the session
        /// </summary>
        void Setup(Dictionary<string, string> requestHeaders);
    }
}
