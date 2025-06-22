using System.Text.Json.Serialization;

namespace SwapiAndStartrekTasks.SecondTask.Models
{
    public class Planet
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("climate")]
        public string Climate { get; set; } = string.Empty;

        [JsonPropertyName("population")]
        public string Population { get; set; } = string.Empty;
    }
}
