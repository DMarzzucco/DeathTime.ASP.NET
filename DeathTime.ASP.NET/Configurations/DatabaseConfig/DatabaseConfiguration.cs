using DeathTime.ASP.NET.Configurations.DatabaseConfig.Helper;
using DeathTime.ASP.NET.Context;
using Microsoft.EntityFrameworkCore;

namespace DeathTime.ASP.NET.Configurations.DatabaseConfig
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection service, IConfiguration config) {

            var connectionString = config.GetConnectionString("Connection");

            DatabaseHelper.WaitForDatabaseAsync(connectionString).GetAwaiter().GetResult();

            service.AddDbContext<AppDbContext>(op => op.UseNpgsql(connectionString));

            return service;
        }
    }
}
