using System.Collections.Generic;

namespace Backend.Models
{
    /// <summary>
    /// Common properties for all models
    /// </summary>
    public class BaseModel
    {       
        //[JsonProperty("_links")]
        public Dictionary<string, string> Links { get; set; }
    }
}
