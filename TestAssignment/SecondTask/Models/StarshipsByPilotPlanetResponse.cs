namespace SwapiAndStartrekTasks.SecondTask.Models
{
    public class StarshipsByPilotPlanetResponse
    {
        public string Planet { get; set; } = "";
        public int StarshipsCount { get; set; }
        public List<Starship> Starships { get; set; } = new();

    }
}
