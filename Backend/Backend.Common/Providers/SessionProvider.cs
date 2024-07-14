using Backend.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace Backend.Common.Providers
{
    /// <inheritdoc/>  
    public class SessionProvider : ISessionProvider
    {
        /// <inheritdoc/>  
        public Dictionary<string, string> RequestHeaders { get; private set; } = new Dictionary<string, string>();


        /// <inheritdoc/>  
        public void Setup(Dictionary<string, string> requestHeaders)
        {
            this.RequestHeaders = requestHeaders;
        }
    }
}
