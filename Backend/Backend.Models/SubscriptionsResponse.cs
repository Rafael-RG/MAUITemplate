using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class SubscriptionsResponse
    {
        [JsonProperty("subscriptions")]
        public List<Subscription> Subscriptions { get; set; }
    }
}
