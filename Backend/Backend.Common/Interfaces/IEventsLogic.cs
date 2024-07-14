using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Common.Models;
using Backend.Models;

namespace Backend.Common.Interfaces
{
    /// <summary>
    /// Documents business logic
    /// </summary>
    public interface IEventsLogic
    {

        /// <summary>
        /// Gets all the documents
        /// </summary>
        /// <returns></returns>
        Task<Result<List<Document>>> GetDocumentsAsync();



        /// <summary>
        /// Gets all the documents
        /// </summary>
        /// <returns></returns>
        Task<Result<Document>> CreateUpdateDocumentAsyc(Document document);
    }


}
