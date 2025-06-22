using System.Text.Json;
using SwapiAndStartrekTasks.SecondTask.Models;

namespace SwapiAndStartrekTasks.SecondTask.Services
{

    public class SwapiService
    {
        private readonly string SwapiBaseUrl;
        private readonly HttpClient _httpClient;

        public SwapiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            SwapiBaseUrl = httpClient.BaseAddress.ToString();
        }

        public async Task<Person> GetPersonAsync(string personUrl)
        {
            var response = await _httpClient.GetStringAsync(personUrl);
            return JsonSerializer.Deserialize<Person>(response);
        }

        public async Task<Planet> GetPlanetAsync(string planetUrl)
        {
            var response = await _httpClient.GetStringAsync(planetUrl);
            return JsonSerializer.Deserialize<Planet>(response);
        }

        public async Task<List<Starship>> GetAllStarshipsAsync()
        {
            var starships = new List<Starship>();
            var url = $"{SwapiBaseUrl}/starships/";

            while (!string.IsNullOrEmpty(url))
            {
                var starshipsPage = await GetStarshipsPageAsync(url);
                starships.AddRange(starshipsPage.Results);
                url = starshipsPage.Next;
            }

            return starships;
        }

        public async Task<bool> PlanetExistsAsync(string planetName)
        {
            var response = await _httpClient.GetStringAsync($"{SwapiBaseUrl}/planets?search={planetName}");
            var planetsResponse = JsonSerializer.Deserialize<PlanetsSwapiResponse>(response);
            return planetsResponse.Count > 0;
        }


        private async Task<StarshipsSwapiResponse> GetStarshipsPageAsync(string starshipUrl)
        {
            var response = await _httpClient.GetStringAsync(starshipUrl);
            return JsonSerializer.Deserialize<StarshipsSwapiResponse>(response);
        }
    }
}