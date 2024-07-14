using System;
using Newtonsoft.Json.Linq;

namespace Backend.Common.Extensions
{
    /// <summary>
    /// JSON Extension for getting values
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// Finds a value
        /// </summary>
        public static string GetValue(this JToken jtoken, string parameter)
        {
            return ((JObject)jtoken).GetValue(parameter, StringComparison.OrdinalIgnoreCase)?.ToString();
        }


        /// <summary>
        /// Checks if the json is empty
        /// </summary>
        public static bool IsEmpty(this JToken token)
        {
            return (token.Type == JTokenType.Null);
        }
    }
}
