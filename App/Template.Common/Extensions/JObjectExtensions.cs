using Newtonsoft.Json.Linq;
using System;

namespace Template.Common.Extensions
{
    /// <summary>
    /// JObject extenstion methods
    /// </summary>
    public static class JObjectExtensions
    {
        /// <summary>
        /// Extension method to parse and get a value from a JObject
        /// </summary>
        public static T GetValue<T>(this JObject item, string property)
        {
            var value = item.GetValue(property, StringComparison.OrdinalIgnoreCase);
            if (value == null) return default(T);
            return value.ToObject<T>();
        }


        /// <summary>
        /// Parse a Json object and returns an array of child items
        /// </summary>
        public static JObject[] ParseArray(this JObject jobject, string property = "")
        {
            var value = (property.Length > 0) ? JArray.Parse(jobject.ToString())
                : jobject.GetValue(property, StringComparison.OrdinalIgnoreCase);

            if (value == null) return new JObject[0];
            var items = JArray.Parse(value.ToString());
            return items.ToObject<JObject[]>();
        }
    }
}
