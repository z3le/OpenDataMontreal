using Newtonsoft.Json;

namespace OpenDataMontreal.Models.GoogleMaps
{
    public class AddressComponent
    {
        [JsonProperty(PropertyName = "long_name")]
        public string LongName { get; set; }

        [JsonProperty(PropertyName = "short_name")]
        public string ShortName { get; set; }

        [JsonProperty(PropertyName = "types")]
        public string[] Types { get; set; }
    }
}
