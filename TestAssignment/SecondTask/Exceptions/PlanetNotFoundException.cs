using System.Text.Json.Serialization;

namespace TestAssignment.Exceptions
{
    public class PlanetNotFoundException : Exception
    {
        public string PlanetName { get; }

        public PlanetNotFoundException(string planetName)
            : base($"Planet '{planetName}' not found.")
        {
            PlanetName = planetName;
        }
    }

}
