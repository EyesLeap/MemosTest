using System.Text.Json.Serialization;

namespace SwapiAndStartrekTasks.ThirdTask.Models
{
    public class SubordinatesResponse
    {
        public List<string> Subordinates { get; set; } = new List<string>();
    }
}
