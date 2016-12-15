using Newtonsoft.Json;

namespace OpenDataMontreal.Models.GoogleMaps
{
    public class Geometry
    {
        [JsonProperty(PropertyName = "location_type")]
        public string LocationType { get; set; }

        [JsonProperty(PropertyName = "location")]
        public Location Location { get; set; }
    }
}
