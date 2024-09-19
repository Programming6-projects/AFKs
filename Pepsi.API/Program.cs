using Microsoft.OpenApi.Models;
using Pepsi.Core;
using Pepsi.Core.Entity;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Infrastructure;
using Pepsi.Infrastructure.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pepsi API", Version = "v1" });
});

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCoreServices();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pepsi API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var vehicleLoader = scope.ServiceProvider.GetRequiredService<IDataLoader<Vehicle>>();
    var vehicleRepository = scope.ServiceProvider.GetRequiredService<IVehicleRepository>();
    var vehicles = await vehicleLoader.LoadDataAsync("Data/Vehicles.json").ConfigureAwait(false);
    foreach (var vehicle in vehicles)
    {
        await vehicleRepository.AddAsync(vehicle).ConfigureAwait(false);
    }
    Console.WriteLine($"Loaded and added {vehicles.Count()} vehicles to the database.");

}

app.Run();
