using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using Rover.Model;

namespace RoverSoftware.Test
{
    [TestClass]
    public class Parse_Command_For_Multiple_Rover_Test
    {
        private ServiceProvider _serviceProvider;
        public Parse_Command_For_Multiple_Rover_Test()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddRoverServices();

            _serviceProvider = services.BuildServiceProvider();
        }

        [TestMethod]
        public void Multiple_Rovers_In_The_Platue_Test()
        {
            var rover1 = _serviceProvider.GetService<ICommandableRover>();
            rover1.Name = "Rover1";
            rover1.SetPosition(10, 10, RoverDirections.North);

            var rover2 = _serviceProvider.GetService<ICommandableRover>();
            rover2.Name = "Rover2";
            rover2.SetPosition(20, 20, RoverDirections.East);

            var rover3 = _serviceProvider.GetService<ICommandableRover>();
            rover3.Name = "Rover3";
            rover3.SetPosition(5, 5, RoverDirections.West);

            var rover4 = _serviceProvider.GetService<ICommandableRover>();
            rover4.Name = "Rover4";
            rover4.SetPosition(15, 15, RoverDirections.South);

            Assert.AreEqual<string>("[13, 8, N]", rover1.Move("R1R3L2L1"));
            Assert.AreEqual<string>("[18, 17, E]", rover2.Move("R1R3L2L1"));
            Assert.AreEqual<string>("[7, 8, W]", rover3.Move("R1R3L2L1"));
            Assert.AreEqual<string>("[12, 17, S]", rover4.Move("R1R3L2L1"));
        }

        [TestMethod]
        public void Rovers_Crashing_To_Each_Other_Test()
        {
            var rover1 = _serviceProvider.GetService<ICommandableRover>();
            rover1.Name = "Rover1";
            rover1.SetPosition(10, 10, RoverDirections.North);

            var rover2 = _serviceProvider.GetService<ICommandableRover>();
            rover2.Name = "Rover2";

            Assert.ThrowsException<ApplicationException>(() => rover2.SetPosition(10, 10, RoverDirections.East));
        }
    }
}
