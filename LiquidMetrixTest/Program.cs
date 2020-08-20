using Microsoft.Extensions.DependencyInjection;
using Rover.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidMetrixTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddRoverServices();
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            string command = Console.ReadLine();
            var commandableRover = serviceProvider.GetService<ICommandableRover>();
            commandableRover.Name = "Rover1";
            commandableRover.SetPosition(10, 10, 'N');

            string position = commandableRover.Move(command);

            Console.WriteLine($"{commandableRover.Name} is now at position {position}");
        }
    }
}
