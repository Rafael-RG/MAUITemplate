using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Backend.Common.Models;
using Backend.Common.Interfaces;
using Backend.Models;
using Backend.Common.Logic;
using System.Linq;

namespace Backend.Service.BusinessLogic
{
    /// </inheritdoc/>
    public class ExampleLogic : BaseLogic, IEventsLogic
    {
        /// <summary>
        /// Gets by DI the dependeciees
        /// </summary>
        /// <param name="dataAccess"></param>
        public ExampleLogic(ISessionProvider sessionProvider, IDataAccess dataAccess, Logger<IEventsLogic> logger) : base(sessionProvider, dataAccess, logger)
        {
        }


        /// </inheritdoc/>
        public async Task<Result<List<Document>>> GetDocumentsAsync()
        {
            try
            {
                var documents = (await this.dataAccess.Documents.GetAsync()).ToList();
                return new Result<List<Document>>(documents);
            }
            catch (Exception ex)    
            {
                return Error<List<Document>>(ex);
            }        
        }

        /// </inheritdoc/>
        public Task<Result<Document>> CreateUpdateDocumentAsyc(Document document)
        {
            throw new NotImplementedException();
        }


    }


}
