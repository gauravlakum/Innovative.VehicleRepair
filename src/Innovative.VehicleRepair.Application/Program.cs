#nullable enable
using System;
using Innovative.VehicleRepair.Application.Enums;
using Innovative.VehicleRepair.Application.IoHandlers;
using Innovative.VehicleRepair.Application.Models;
using Innovative.VehicleRepair.Application.Repositories;
using Innovative.VehicleRepair.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Innovative.VehicleRepair.Application
{
    class Program
    {

        static void Main(string[] args)
        {
            var services = ConfigureServices();

            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<ApplicationHost>()?.Run().Wait();


        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IRuleRepository, RuleRepository>();
            services.AddScoped<IInputHandler, ConsoleInputHandler>();
            services.AddScoped<IOutputHandler, ConsoleOutputHandler>();

            // required to run the application
            services.AddScoped<ApplicationHost>();

            return services;
        }
    }
}
