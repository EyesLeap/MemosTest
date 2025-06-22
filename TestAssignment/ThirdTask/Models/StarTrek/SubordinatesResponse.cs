using System.Text.Json.Serialization;

namespace TestAssignment.Models.StarTrek
{
    public class SubordinatesResponse
    {
        public List<string> Subordinates { get; set; } = new List<string>();
    }
}
