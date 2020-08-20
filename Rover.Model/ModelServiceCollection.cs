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
            services.AddScoped<IPlateau, Plateau>();
            services.AddScoped<ICommandableRover, MarsRover>();

            return services;
        }
    }
}
