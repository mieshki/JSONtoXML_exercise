using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONtoXML
{
    public partial class AllBuses
    {
        [JsonProperty("lastUpdate")]
        public DateTimeOffset LastUpdate { get; set; }

        [JsonProperty("delay")]
        public Arrives[] Arrives { get; set; }

        public static AllBuses FromJson(string json) => JsonConvert.DeserializeObject<AllBuses>(json);
    }


    public partial class Arrives
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("delayInSeconds")]
        public long DelayInSeconds { get; set; }

        [JsonProperty("estimatedTime")]
        public string EstimatedTime { get; set; }

        [JsonProperty("headsign")]
        public string Headsign { get; set; }

        [JsonProperty("routeId")]
        public long RouteId { get; set; }

        [JsonProperty("tripId")]
        public long TripId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("theoreticalTime")]
        public string TheoreticalTime { get; set; }

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("trip")]
        public long Trip { get; set; }

        [JsonProperty("vehicleCode")]
        public long VehicleCode { get; set; }

        [JsonProperty("vehicleId")]
        public long VehicleId { get; set; }
    }

    
}
