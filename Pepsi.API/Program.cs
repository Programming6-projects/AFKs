using Microsoft.Extensions.DependencyInjection;
using Pepsi.Infrastructure.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<DatabaseHelper>();

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);

var app = builder.Build();

var vehicles = FileReader.ReadVehiclesFromJson();
Console.WriteLine(vehicles!.Count);


app.MapGet("/check-connection", (DatabaseHelper dbHelper) =>
{
    var isConnected = dbHelper.CheckConnection();
    return isConnected ? Results.Ok("Database connection is successful!") : Results.StatusCode(500);
});

app.Run();
