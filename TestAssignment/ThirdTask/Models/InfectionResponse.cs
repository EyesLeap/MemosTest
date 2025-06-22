using System.Text.Json.Serialization;

namespace SwapiAndStartrekTasks.ThirdTask.Models
{
    public class InfectionResponse
    {
        public string PatientZero { get; set; }
        public List<string> InfectedMembers { get; set; }
    }
}
