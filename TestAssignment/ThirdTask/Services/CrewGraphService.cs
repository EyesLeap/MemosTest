using SwapiAndStartrekTasks.ThirdTask.Models;
using TestAssignment.Exceptions;

namespace SwapiAndStartrekTasks.ThirdTask.Services
{
    public class CrewGraph
    {
        private readonly Dictionary<string, CrewMemberNode> _crewGraph;

        public CrewGraph()
        {
            _crewGraph = SeedGraph();
        }

        private Dictionary<string, CrewMemberNode> SeedGraph()
        {
            var nodes = new Dictionary<string, CrewMemberNode>();

            var names = new[]
            {
                "Alexander Rozhenko", "Tasha Yar",
                "K'Ehleyr", "Worf son of Mog",
                "Westley Crusher", "Guinan",
                "William Riker", "Julian Bashir",
                "Alyssa Ogawa", "Beverly Crusher",
                "Lwaxana Troi", "Deana Troi",
                "Jean Luc Picard", "Reginald Barkley",
                "Mr. Data", "Jordi La Forge",
                "Miles O'Brien"
            };

            foreach (var name in names)
            {
                nodes[name] = new CrewMemberNode(name);
            }

            SetSubordinates(nodes, "Jean Luc Picard", new[] { "Deana Troi", "Jordi La Forge", "William Riker" });
            SetSubordinates(nodes, "William Riker", new[] { "Worf son of Mog", "Guinan", "Beverly Crusher" });
            SetSubordinates(nodes, "Deana Troi", new[] { "Lwaxana Troi", "Reginald Barkley" });
            SetSubordinates(nodes, "Jordi La Forge", new[] { "Mr. Data", "Miles O'Brien" });
            SetSubordinates(nodes, "Beverly Crusher", new[] { "Alyssa Ogawa" });
            SetSubordinates(nodes, "Worf son of Mog", new[] { "Tasha Yar", "K'Ehleyr" });
            SetSubordinates(nodes, "Alyssa Ogawa", new[] { "Julian Bashir" });
            SetSubordinates(nodes, "K'Ehleyr", new[] { "Alexander Rozhenko" });

            return nodes;
        }

        private void SetSubordinates(Dictionary<string, CrewMemberNode> nodes,
            string boss,
            string[] subordinates)
        {
            var bossNode = nodes[boss];
            foreach (var subName in subordinates)
            {
                var subNode = nodes[subName];
                bossNode.Subordinates.Add(subNode);
                subNode.Boss = bossNode;
            }
        }

        public List<string> GetAllSubordinates(string personName)
        {
            if (!_crewGraph.TryGetValue(personName, out var person))
                throw new PersonNotFoundException(personName);

            var result = new List<string>();
            var visited = new HashSet<string>();

            GetSubordinatesRecursive(person, result, visited);

            return result;
        }

        private void GetSubordinatesRecursive(CrewMemberNode node,
            List<string> result,
            HashSet<string> visited)
        {
            if (visited.Contains(node.Name))
                return;

            visited.Add(node.Name);

            foreach (var subordinate in node.Subordinates)
            {
                result.Add(subordinate.Name);
                GetSubordinatesRecursive(subordinate, result, visited);
            }
        }

        public InfectionResponse InfectionSpread(string patientZeroName)
        {
            if (!_crewGraph.TryGetValue(patientZeroName, out var patientZero))
                throw new PersonNotFoundException(patientZeroName);

            foreach (var node in _crewGraph.Values)
                node.IsInfected = false;

            patientZero.IsInfected = true;
            var infected = new HashSet<string> { patientZeroName };
            var captain = _crewGraph["Jean Luc Picard"];

            var queue = new Queue<CrewMemberNode>();
            queue.Enqueue(patientZero);

            //Virus spreads layer by layer using BFS until it infects captain
            while (queue.Count > 0 && !captain.IsInfected)
            {
                var current = queue.Dequeue();

                if (current.Boss is not null && !current.Boss.IsInfected)
                {
                    current.Boss.IsInfected = true;
                    infected.Add(current.Boss.Name);
                    queue.Enqueue(current.Boss);
                }

                foreach (var subordinate in current.Subordinates)
                {
                    if (!subordinate.IsInfected)
                    {
                        subordinate.IsInfected = true;
                        infected.Add(subordinate.Name);
                        queue.Enqueue(subordinate);
                    }
                }
            }

            return new InfectionResponse
            {
                PatientZero = patientZeroName,
                InfectedMembers = infected.ToList()
            };
        }
    }
}