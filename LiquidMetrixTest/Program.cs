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

            var commandableRover = serviceProvider.GetService<ICommandableRover>();
            commandableRover.Name = "Rover1";
            commandableRover.SetPosition(10, 10, RoverDirections.North);

            Console.WriteLine("Enter the command in 'LNRN' format: ");
            Console.WriteLine($"{commandableRover.Name} is now at position {commandableRover.Move(Console.ReadLine())}");

            Console.WriteLine("Enter the command in 'LNRN' format: ");
            Console.WriteLine($"{commandableRover.Name} is now at position {commandableRover.Move(Console.ReadLine())}");
        }
    }
}
