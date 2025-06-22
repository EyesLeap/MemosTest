using TestAssignment.Exceptions;
using TestAssignment.SecondTask;
using SwapiAndStartrekTasks.SecondTask.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<SwapiService>(client =>
{
    client.BaseAddress = new Uri("https://swapi.dev/api");
})
.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
});

builder.Services.AddScoped<StarshipService>();

var app = builder.Build();

//GET /api/task2?planet=Kashyyyk
app.MapGet("api/task2", async (StarshipService crewService, string planet = "Kashyyyk") =>
{
    try
    {
        var result = await crewService.GetStarshipsByPilotPlanet(planet);
        return Results.Ok(result);
    }
    catch (PlanetNotFoundException ex)
    {
        return Results.NotFound(ex.Message);
    }
    catch (Exception ex)
    {
        return Results.Problem("Internal server error");
    }
});

//GET /api/task3/subordinates?person=Jean Luc Picard
app.MapGet("api/task3/subordinates", (string person = "Jean Luc Picard") =>
{
    try
    {
        var result = CrewGraphTask.GetSubordinates(person);
        return Results.Ok(result);
    }
    catch (PersonNotFoundException ex)
    {
        return Results.NotFound(ex.Message);
    }
    catch (Exception ex)
    {
        return Results.Problem("Internal server error");
    }
});

//GET /api/task3/infection?person=Julian Bashir
app.MapGet("api/task3/infection", (string person = "Julian Bashir") =>
{
    try
    {
        var result = CrewGraphTask.InfectionSpread(person);
        return Results.Ok(result);
    }
    catch (PersonNotFoundException ex)
    {
        return Results.NotFound(ex.Message);
    }
    catch (Exception ex)
    {
        return Results.Problem("Internal server error");
    }
});


app.Run();
