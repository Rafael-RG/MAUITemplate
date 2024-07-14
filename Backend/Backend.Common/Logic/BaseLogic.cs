using Backend.Common.Interfaces;
using Backend.Common.Models;
using Microsoft.Extensions.Logging;
using System;

namespace Backend.Common.Logic
{
    /// <summary>
    /// Base logic class
    /// </summary>
    public class BaseLogic
    {
        protected readonly ILogger logger;
        protected readonly ISessionProvider sessionProvider;
        protected readonly IDataAccess dataAccess;


        /// <summary>
        /// Gets by DI the dependeciees
        /// </summary>
        /// <param name="dataAccess"></param>
        public BaseLogic(ISessionProvider sessionProvider, IDataAccess dataAccess, ILogger logger)
        {
            this.sessionProvider = sessionProvider;
            this.dataAccess = dataAccess; 
            this.logger = logger;
        }


        /// <summary>
        /// Handles and error
        /// </summary>
        protected static Result<T> Error<T>(Exception ex, T data = null) where T : class
        {
            return new Result<T>
            {
                Data = data,
                Message = ex.Message,
                Success = false
            };
        }   
    }
}
