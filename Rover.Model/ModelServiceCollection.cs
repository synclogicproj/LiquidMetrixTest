using Rover.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ModelServiceCollection
    {
        public static IServiceCollection AddRoverServices(this IServiceCollection services)
        {
            services.AddSingleton<IPlateau, Plateau>();
            services.AddTransient<ICommandableRover, MarsRover>();
            services.AddScoped<IRoverMovementHandlerFactory, RoverMovementHandlerFactory>();

            return services;
        }
    }
}
