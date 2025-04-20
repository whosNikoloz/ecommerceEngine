using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ecommerceEngine.Domain.Entities;

namespace ecommerceEngine.Infrastructure.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var services = scope.ServiceProvider;

            var logger = services.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(SeedData));
            var context = services.GetRequiredService<ApplicationDbContext>();

            logger.LogInformation("Checking for pending migrations...");
            context.Database.Migrate();

            if (!context.Products.Any())
            {
                logger.LogInformation("Seeding initial data...");

                context.Products.AddRange(
                    new Product { Name = "Product A", Price = 10 },
                    new Product { Name = "Product B", Price = 20 }
                );

                context.SaveChanges();
                logger.LogInformation("Seeding complete.");
            }
            else
            {
                logger.LogInformation("Seed data already exists. Skipping seeding.");
            }
        }
    }
}
