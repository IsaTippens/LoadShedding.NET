using System.Collections.Generic;
using LoadShedding.NET.Objects;
using System.Text.Json.Serialization;

namespace LoadShedding.NET.Internal
{
    public class SuburbsData
    {
        [JsonPropertyName("Results")]
        public List<Suburb>? Results { get; set; }
        [JsonPropertyName("Total")]
        public int Total { get; set; }
    }
}
