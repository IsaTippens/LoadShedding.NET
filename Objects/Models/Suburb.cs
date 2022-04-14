using System.Text.Json.Serialization;
namespace LoadShedding.NET.Objects
{
    public struct Suburb
    {
        [JsonPropertyName("text")]
        public String? Name { get; set; }
        
        [JsonPropertyName("id")]
        public String? ID { get; set; }
    }
}