using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Template.Common.Interfaces;

namespace Template.Common.Services
{
    /// <summary>
    /// Data access service
    /// </summary>
    public class HttpService : IHttpService
    {
        private static HttpClient httpClient;


        /// <summary>
        /// Initialization
        /// </summary>
        public HttpService()
        {
        }


        /// <summary>
        /// Creates and configures the HTTP client
        /// </summary>
        private void CreateHttpClient()
        {
            // Disables the default cache
            if (httpClient != null)
            {
                httpClient.DefaultRequestHeaders.IfModifiedSince = DateTimeOffset.Now;
            }
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.IfModifiedSince = DateTimeOffset.Now;
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add(Constants.WebApiKeyHeader, Constants.WebApiKey);
            httpClient.Timeout = new TimeSpan(0, 0, 5, 0);
        }



        /// <summary>
        /// Post data 
        /// </summary>
        public async Task<T> PostAsync<T>(object postData, string uri, JsonSerializerSettings settings = null)
        {
            CreateHttpClient();
            var data = JsonConvert.SerializeObject(postData);
            var contentPost = new StringContent(data, Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync(uri, contentPost);
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception($"Error in PostAsync: {result.StatusCode}");
            }
            var response = await result.Content.ReadAsStringAsync();
            var resultData = JsonConvert.DeserializeObject<T>(response, settings);
            return resultData;
        }



        /// <summary>
        /// Executes a GET method to the service
        /// </summary>
        public async Task<JObject> GetJsonObjectAsync(string uri, JsonSerializerSettings settings = null)
        {
            CreateHttpClient();
            var result = await httpClient.GetAsync(uri);
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }
            var response = await result.Content.ReadAsStringAsync();
            return JObject.Parse(response);
        }



        /// <summary>
        /// Executes a GET method to the service
        /// </summary>
        public async Task<JObject[]> GetJsonArrayAsync(string uri, JsonSerializerSettings settings = null)
        {
            CreateHttpClient();
            var result = await httpClient.GetAsync(uri);
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }
            var response = await result.Content.ReadAsStringAsync();
            var jsonArray = JArray.Parse(response);
            return jsonArray.ToObject<JObject[]>();
        }
    }
}
