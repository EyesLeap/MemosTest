using System.Text.Json.Serialization;

namespace SwapiAndStartrekTasks.ThirdTask.Models
{
    public class CrewMemberNode
    {
        public string Name { get; }
        public CrewMemberNode Boss { get; set; }
        public List<CrewMemberNode> Subordinates { get; }
        public bool IsInfected { get; set; }

        public CrewMemberNode(string name)
        {
            Name = name;
            Subordinates = new List<CrewMemberNode>();
            IsInfected = false;
        }
    }
}
