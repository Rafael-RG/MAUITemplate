using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Azure.Functions.Worker.Http;
using Backend.Common.Interfaces;

namespace Backend.Common.Middleware
{
    /// <summary>
    /// Middleware to capture and store session inforamtion (like authentication headers)
    /// so all layer can access the sesion information through the SessionProvider
    /// </summary>
    public class SessionMiddleware : IFunctionsWorkerMiddleware
    {
        /// <summary>
        /// Called when the middleware is used.
        /// The scoped service is injected into Invoke
        /// </summary>
        public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {

            try
            {
                var httpRequqestData = await context.GetHttpRequestDataAsync();
                if (httpRequqestData != null && 
                    !httpRequqestData.Url.ToString().Contains("api/swagger", StringComparison.InvariantCultureIgnoreCase) &&
                    context.BindingContext.BindingData is IReadOnlyDictionary<string, object> bindingData && bindingData.ContainsKey("headers"))
                {                                  
                    var headers = JsonConvert.DeserializeObject<Dictionary<string, string>>(bindingData["headers"].ToString().ToLower());
                    if (!AreHeaderValid(headers))
                    {
                        var newHttpResponse = httpRequqestData.CreateResponse(HttpStatusCode.Unauthorized);
                        await newHttpResponse.WriteAsJsonAsync(new { ResponseStatus = "Invalid or missing required headers" }, newHttpResponse.StatusCode);
                        context.GetInvocationResult().Value = newHttpResponse;
                        return;
                    }
                    var sessionProvider = context.InstanceServices.GetRequiredService<ISessionProvider>();
                    sessionProvider.Setup(headers);                                    
                }
                await next(context);
            }
            catch (Exception ex)
            {           
                var httpRequqestData = await context.GetHttpRequestDataAsync();
                var newHttpResponse = httpRequqestData.CreateResponse(HttpStatusCode.BadRequest);
                await newHttpResponse.WriteAsJsonAsync(new { ResponseStatus = $"Middleware error { ex.Message}" }, newHttpResponse.StatusCode);
                context.GetInvocationResult().Value = newHttpResponse;
            }
        }


        /// <summary>
        /// Validates that the required headers are present
        /// </summary>
        private static bool AreHeaderValid(Dictionary<string, string> headers)
        {
            return headers.Keys.Count > 0;      
        }
    }
}
