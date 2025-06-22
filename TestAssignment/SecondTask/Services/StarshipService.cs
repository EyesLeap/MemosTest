using SwapiAndStartrekTasks.SecondTask.Models;
using TestAssignment.Exceptions;

namespace SwapiAndStartrekTasks.SecondTask.Services
{
    public class StarshipService
    {
        private readonly SwapiService _swapiService;

        public StarshipService(SwapiService swapiService)
        {
            _swapiService = swapiService;
        }

        public async Task<StarshipsByPilotPlanetResponse> GetStarshipsByPilotPlanet(string planetName)
        {
            if (!await _swapiService.PlanetExistsAsync(planetName))
                throw new PlanetNotFoundException(planetName);

            var allStarships = await _swapiService.GetAllStarshipsAsync();

            //For caching pilots if they were already checked
            var checkedPilots = new Dictionary<string, bool>();
            var result = new List<Starship>();

            foreach (var starship in allStarships)
            {
                if (await HasAnyPilotFromPlanetAsync(starship, planetName, checkedPilots))
                {
                    result.Add(starship);
                }
            }

            return new StarshipsByPilotPlanetResponse
            {
                Planet = planetName,
                StarshipsCount = result.Count,
                Starships = result
            };
        }

        private async Task<bool> HasAnyPilotFromPlanetAsync(Starship starship,
            string planetName,
            Dictionary<string, bool> checkedPilots)
        {
            if (starship.Pilots is null || !starship.Pilots.Any())
                return false;

            foreach (var pilotUrl in starship.Pilots)
            {
                if (await IsPilotFromPlanetAsync(pilotUrl, planetName, checkedPilots))
                    return true;
            }

            return false;
        }

        private async Task<bool> IsPilotFromPlanetAsync(string pilotUrl,
            string planetName,
            Dictionary<string, bool> checkedPilots)
        {
            if (checkedPilots.TryGetValue(pilotUrl, out bool cachedResult))
                return cachedResult;

            var pilot = await _swapiService.GetPersonAsync(pilotUrl);
            var planet = await _swapiService.GetPlanetAsync(pilot.Homeworld);

            bool isFromTargetPlanet = planet.Name.Equals(planetName, StringComparison.OrdinalIgnoreCase);
            checkedPilots[pilotUrl] = isFromTargetPlanet;

            return isFromTargetPlanet;
        }
    }
}