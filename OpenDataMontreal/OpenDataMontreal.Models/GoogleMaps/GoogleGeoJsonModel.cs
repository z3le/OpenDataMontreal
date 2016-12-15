using Newtonsoft.Json;

namespace OpenDataMontreal.Models.GoogleMaps
{
    public class GoogleGeoJsonModel
    {
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "results")]
        public Results[] Results { get; set; }
    }
}
