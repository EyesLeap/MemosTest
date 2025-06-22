using System.Text.Json.Serialization;

namespace TestAssignment.Models.StarTrek
{
    public class InfectionResponse
    {
        public string PatientZero { get; set; }
        public List<string> InfectedMembers { get; set; }
    }
}
