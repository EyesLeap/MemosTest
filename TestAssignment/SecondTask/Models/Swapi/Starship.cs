using System.Text.Json.Serialization;

namespace TestAssignment.Models.Swapi
{
    public class Starship
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("model")]
        public string Model { get; set; } = string.Empty;

        [JsonPropertyName("manufacturer")]
        public string Manufacturer { get; set; } = string.Empty;

        [JsonPropertyName("starship_class")]
        public string StarshipClass { get; set; } = string.Empty;

        [JsonPropertyName("pilots")]
        public List<string> Pilots { get; set; } = new();
    }
}
