using SwapiAndStartrekTasks.ThirdTask.Models;
using SwapiAndStartrekTasks.ThirdTask.Services;

namespace TestAssignment.SecondTask
{
    public static class CrewGraphTask
    {
        private static readonly CrewGraph _crewGraph = new CrewGraph();

        public static SubordinatesResponse GetSubordinates(string person)
        {
            var subordinates = _crewGraph.GetAllSubordinates(person);

            return new SubordinatesResponse
            {
                Subordinates = subordinates
            };
        }

        public static InfectionResponse InfectionSpread(string infectedPerson)
        {
            var result = _crewGraph.InfectionSpread(infectedPerson);

            return new InfectionResponse
            {
                PatientZero = result.PatientZero,
                InfectedMembers = result.InfectedMembers
            };
        }
    }
}