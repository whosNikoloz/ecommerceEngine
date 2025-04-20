using ecommerceEngine.Application.Interfaces;
using ecommerceEngine.Application.Services;
using ecommerceEngine.Domain.Interfaces;
using ecommerceEngine.Infrastructure.BankIntegrations.Models;
using ecommerceEngine.Infrastructure.Repositories;
using EcommerceEngine.Infrastructure.BankIntegrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EcommerceEngine.Infrastructure.Logging;
using Serilog;
using ecommerceEngine.Infrastructure.Email;
using Microsoft.Extensions.Logging;
using Serilog.Extensions.Logging;

namespace ecommerceEngine.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string mysqlConnection = configuration
                        .GetConnectionString("MySql");

            string sqlServerConnection = configuration
                        .GetConnectionString("SqlServer");

            // Register DbContext with connection string from appsettings
            // services.AddDbContext<ApplicationDbContext>(options =>
            //     options.UseSqlServer(sqlServerConnection));

            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseMySql(mysqlConnection, ServerVersion.AutoDetect(mysqlConnection)));

            // Register repositories
            services.AddScoped<IProductRepository, ProductRepository>();

            // Bank Integrations
            services.Configure<BogSettings>(configuration.GetSection("BankSettings:Bog"));
            services.Configure<TbcSettings>(configuration.GetSection("BankSettings:Tbc"));
            // Ensure the AddHttpClient extension is available
            services.AddHttpClient<BogPaymentService>();
            services.AddHttpClient<TbcPaymentService>();

            services.AddScoped<BogPaymentService>();
            services.AddScoped<TbcPaymentService>();

            services.AddScoped<IProductService, ProductService>();

            services.AddSingleton<LoggingService>();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddProvider(new SerilogLoggerProvider(Log.Logger));
            });

            services.AddScoped<EmailService>();

            return services;
        }
    }
}