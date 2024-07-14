using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Template.Common.Interfaces
{

    /// <summary>
    /// Http access service interface
    /// </summary>
    public interface IHttpService
    {

        /// <summary>
        /// Executes a post method 
        /// </summary>
        Task<T> PostAsync<T>(object postData, string uri, JsonSerializerSettings settings = null);


        /// <summary>
        /// Executes a GET method to the service
        /// </summary>   
        Task<JObject> GetJsonObjectAsync(string uri, JsonSerializerSettings settings = null);



        /// <summary>
        /// Executes a GET method to the service
        /// </summary>   
        Task<JObject[]> GetJsonArrayAsync(string uri, JsonSerializerSettings settings = null);

    }
}
