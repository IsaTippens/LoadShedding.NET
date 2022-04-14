using System.Text.Json.Serialization;
namespace LoadShedding.NET.Objects
{
    public struct Municipality
    {
        [JsonPropertyName("Text")]
        public String Name { get; set; }
        
        [JsonPropertyName("Value")]
        public String ID { get; set; }
    }
}