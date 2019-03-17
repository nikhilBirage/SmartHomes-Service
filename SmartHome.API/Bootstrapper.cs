using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartHome.API.Models;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using SmartHome.API.Repositories;

namespace SmartHome.API
{
    public class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddScoped<SmartHomeContext>();
            services.AddDbContext<SmartHomeContext>(o => o.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IMeterReadingRepository, MeterReadingRepository>();

            services.AddScoped<IRechargeRepository, RechargeRepository>();

            services.AddScoped<IUserManagementRepository, UserManagementRepository>();

            services.AddScoped<ITransactionRepository, TransactionRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
