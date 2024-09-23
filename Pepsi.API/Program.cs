using System.Diagnostics;
using Microsoft.OpenApi.Models;
using Pepsi.API.Seeders;
using Pepsi.Core;
using Pepsi.Infrastructure;

namespace Pepsi.API;

internal static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pepsi API", Version = "v1" });
        });

        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddCoreServices();
        builder.Services.AddScoped<DataSeeder>();

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
            var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
            await dataSeeder.SeedVehiclesAsync("Data/Vehicles.json").ConfigureAwait(false);
        }

        Debug.Assert(app != null, nameof(app) + " != null");
        await app.RunAsync().ConfigureAwait(false);
    }
}
