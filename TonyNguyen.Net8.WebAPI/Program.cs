using TonyNguyen.Net8.WebAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region KeyedService

builder.Services.AddKeyedSingleton<IUserStore, ReplicatedUserStore>("ReplicatedUserStore");
builder.Services.AddKeyedSingleton<IUserStore, Auth0UserStore>("Auth0UserStore");

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

#region ShortCircuit

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi()
    .ShortCircuit();
#endregion

#region KeyedService

app.MapGet("/signup/user", ([FromKeyedServices("Auth0UserStore")] IUserStore userStore) => userStore.GetUser());
app.MapGet("/find/user", ([FromKeyedServices("ReplicatedUserStore")] IUserStore userStore) => userStore.GetUser());

#endregion

#region FileUploadSupport

// Pre net8 version
app.MapPost("/pre-net8-upload", async (HttpRequest request) =>
{
    var form = await request.ReadFormAsync();
    var file = form.Files["file"];
    // ... Process the file
    
    return file != null ? Results.Ok(file.Name) : Results.BadRequest("File doesn't exist in payload");
}).WithOpenApi();

// .net8 version
app.MapPost("/net8-upload",  async (IFormFile file) =>
{
    return file != null ? Results.Ok(file.Name) : Results.BadRequest("File doesn't exist in payload");
}).WithOpenApi();

#endregion

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}