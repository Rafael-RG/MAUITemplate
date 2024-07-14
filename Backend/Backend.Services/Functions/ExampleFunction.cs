using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;
using Microsoft.OpenApi.Models;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Backend.Common.Extensions;
using Backend.Common.Models;
using Backend.Common.Interfaces;
using Backend.Models;

namespace Backend.Service.Functions
{
    /// <summary>
    /// Documents backend API
    /// </summary>
    public class ExampleFunction
    {
        private readonly ILogger<ExampleFunction> logger;
        private readonly IEventsLogic businessLogic;


        /// <summary>
        /// Receive all the depedencies by DI
        /// </summary>        
        public ExampleFunction(IEventsLogic businessLogic, ILogger<ExampleFunction> logger)
        {
            this.logger = logger;
            this.businessLogic = businessLogic;
        }


        /// <summary>
        /// Creates a new document
        /// </summary>       
        [OpenApiOperation("Create", ["Documents"], Description = "Creates a new document")]
        [OpenApiParameter("Authetication", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "User bearer token")]
        [OpenApiSecurity("X-Functions-Key", SecuritySchemeType.ApiKey, Name = "x-functions-key", In = OpenApiSecurityLocationType.Header, Description = "The function key to access the API")]
        [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(ExampleFunction), Required = true, Description = "Document to create")]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(Response<Document>), Description = "The created / updated document")]
        [Function(nameof(CreateDocumentAsync))]
        public async Task<HttpResponseData> GetAccessTokenAsync(
         [HttpTrigger(AuthorizationLevel.Function, "post", Route = "documents")] HttpRequestData request)
        {
            return await request.CreateResponse(this.businessLogic.CreateUpdateDocumentAsyc, request.DeserializeBody<Document>(), responseLinks =>
            {
                responseLinks.Links = new Dictionary<string, string> { };
            }, logger);
        }


        /// <summary>
        /// Creates a new document
        /// </summary>       
        [OpenApiOperation("Create", ["Documents"], Description = "Creates a new document")]
        [OpenApiParameter("Authetication", In = ParameterLocation.Header, Required = true, Type = typeof(string), Description = "User bearer token")]
        [OpenApiSecurity("X-Functions-Key", SecuritySchemeType.ApiKey, Name = "x-functions-key", In = OpenApiSecurityLocationType.Header, Description = "The function key to access the API")]
        [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(ExampleFunction), Required = true, Description = "Document to create")]
        [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(Response<Document>), Description = "The created / updated document")]
        [Function(nameof(CreateDocumentAsync))]
        public async Task<HttpResponseData> CreateDocumentAsync(
         [HttpTrigger(AuthorizationLevel.Function, "post", Route = "documents")] HttpRequestData request)
        {
            return await request.CreateResponse(this.businessLogic.CreateUpdateDocumentAsyc, request.DeserializeBody<Document>(), responseLinks =>
            {
                responseLinks.Links = new Dictionary<string, string> { };
            }, logger);
        }



    }
}


