using Backend.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Backend.Common.Interfaces
{
    /// <summary>
    /// Data Access interface
    /// </summary>
    public interface IDataAccess
    {
        /// <summary>
        /// Documents collection
        /// </summary>
        IRepository<Document> Documents { get; }

     
        /// <summary>
        /// Saves all the changess
        /// </summary>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Get sas token
        /// </summary>
        string GetSasToken(string container, int expiresOnMinutes);
      
    }
}