using System.Text.Json.Serialization;

namespace TestAssignment.Models.Swapi
{
    public class Person
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("gender")]
        public string Gender { get; set; } = string.Empty;

        [JsonPropertyName("birth_year")]
        public string BirthYear { get; set; } = string.Empty;

        [JsonPropertyName("homeworld")]
        public string Homeworld { get; set; } = string.Empty;
    }
}
