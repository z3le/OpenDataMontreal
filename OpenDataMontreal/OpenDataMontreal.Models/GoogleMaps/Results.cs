using Newtonsoft.Json;

namespace OpenDataMontreal.Models.GoogleMaps
{
    public class Results
    {
        [JsonProperty(PropertyName = "formatted_address")]
        public string FormattedAddress { get; set; }

        [JsonProperty(PropertyName = "geometry")]
        public Geometry Geometry { get; set; }

        [JsonProperty(PropertyName = "types")]
        public string[] Types { get; set; }

        [JsonProperty(PropertyName = "address_components")]
        public AddressComponent[] AddressComponents { get; set; }
    }
}
