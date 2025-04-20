using ecommerceEngine.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace ecommerceEngine.API.Extensions;

public static class HostExtensions
{
    public static async Task MigrateAndSeedDatabaseAsync(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var logger = services.GetRequiredService<ILogger<Program>>();
        var config = services.GetRequiredService<IConfiguration>();

        var connectionString = config.GetConnectionString("MySql");

        if (!await CanConnectToMySqlServerAsync(connectionString, logger))
        {
            throw new InvalidOperationException("MySQL Server is unreachable.");
        }

        try
        {
            var context = services.GetRequiredService<ApplicationDbContext>();
            await context.Database.MigrateAsync();
            SeedData.Initialize(services);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred during migration or seeding.");
        }
    }

    private static async Task<bool> CanConnectToMySqlServerAsync(string connectionString, ILogger logger)
    {
        try
        {
            var builder = new MySqlConnectionStringBuilder(connectionString)
            {
                Database = "mysql"
            };

            await using var connection = new MySqlConnection(builder.ConnectionString);
            await connection.OpenAsync();

            logger.LogInformation("Successfully connected to MySQL Server.");
            return true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to connect to MySQL Server.");
            return false;
        }
    }

    private static async Task<bool> CanConnectToSqlServerAsync(string connectionString, ILogger logger)
    {
        try
        {
            // Modify connection string to use 'master' DB
            var builder = new SqlConnectionStringBuilder(connectionString)
            {
                InitialCatalog = "master" // only checks if server is reachable
            };

            await using var connection = new SqlConnection(builder.ConnectionString);
            await connection.OpenAsync();

            logger.LogInformation("Successfully connected to SQL Server.");

            return true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to connect to SQL Server.");
            return false;
        }
    }

}
