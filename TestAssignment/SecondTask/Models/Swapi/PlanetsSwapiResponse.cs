using System.Text.Json.Serialization;

namespace TestAssignment.Models.Swapi
{
    public class PlanetsSwapiResponse
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("next")]
        public string? Next { get; set; }

        [JsonPropertyName("previous")]
        public string? Previous { get; set; }

        [JsonPropertyName("results")]
        public List<Starship> Results { get; set; } = new();
    }
}
