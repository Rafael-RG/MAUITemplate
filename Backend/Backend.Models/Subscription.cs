using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Subscription
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("product")]
        public Product Product { get; set; }
    }
}
