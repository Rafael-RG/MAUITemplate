using Newtonsoft.Json;
using System.Collections.Generic;

namespace Backend.Common.Models
{
    /// <summary>
    /// Envelop the API response to add extra details
    /// </summary>
    public class Response
    {

        /// <summary>
        /// True of the API response was succesful
        /// </summary>
        public bool Success { get; set; }


        /// <summary>
        /// Response menssage
        /// </summary>
        public string Message { get; set; }


        [JsonProperty("_links")]
        public Dictionary<string, string> Links { get; set; }


        /// <summary>
        /// Empty constructor
        /// </summary>
        public Response()
        {

        }


        /// <summary>
        /// Message based constructor
        /// </summary>
        public Response(bool sucess, string message = "")
        {
            this.Success = sucess;
            this.Message = message;
        }
    }



    /// <summary>
    /// Typed API response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T> : Response
    {
        /// <summary>
        /// Actual endoint response data
        /// </summary>
        public T Data { get; set; }


        /// <summary>
        /// Typed constructor
        /// </summary>
        public Response(T data)
        {
            this.Data = data;
        }


        /// <summary>
        /// Message based constructor
        /// </summary>
        public Response(bool sucess, T data, string message = "")
        {
            this.Success = sucess;
            this.Message = message;
            this.Data = data;
        }
    }

}