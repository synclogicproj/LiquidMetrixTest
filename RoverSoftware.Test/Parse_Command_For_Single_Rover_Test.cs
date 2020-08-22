using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rover.Model;

namespace RoverSoftware.Test
{
    [TestClass]
    public class Parse_Command_For_Single_Rover_Test
    {
        private ServiceProvider _serviceProvider;

        public Parse_Command_For_Single_Rover_Test()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddRoverServices();

            _serviceProvider = services.BuildServiceProvider();
        }

        [TestMethod]
        public void One_Rover_In_The_Platue_Test()
        {
            var commandableRover = _serviceProvider.GetService<ICommandableRover>();
            commandableRover.Name = "Rover1";
            commandableRover.SetPosition(10, 10, RoverDirections.North);

            string position = commandableRover.Move("R1R3L2L1");
            Assert.AreEqual<string>("[13, 8, N]", position);

            commandableRover.SetPosition(10, 10, RoverDirections.North);

            string position1 = commandableRover.Move("L6R6L1");
            Assert.AreEqual<string>("[3, 16, W]", position1);

            commandableRover.SetPosition(10, 10, RoverDirections.North);

            string position3 = commandableRover.Move("L10R11");
            Assert.AreEqual<string>("[0, 21, N]", position3);
        }

        [TestMethod]
        public void Move_Rover_Multiple_Times_In_The_Platue_Test()
        {
            var commandableRover = _serviceProvider.GetService<ICommandableRover>();
            commandableRover.Name = "Rover1";
            commandableRover.SetPosition(10, 10, RoverDirections.North);

            Assert.AreEqual<string>("[13, 8, N]", commandableRover.Move("R1R3L2L1"));
            Assert.AreEqual<string>("[16, 6, N]", commandableRover.Move("R1R3L2L1"));
        }

        [TestMethod]
        public void One_Rover_In_The_Platue_Outside_YBoundary_Test()
        {
            var commandableRover = _serviceProvider.GetService<ICommandableRover>();
            commandableRover.Name = "Rover1";
            commandableRover.SetPosition(10, 10, RoverDirections.North);

            Assert.ThrowsException<ApplicationException>(() => commandableRover.Move("R1R50"));
        }

        [TestMethod]
        public void One_Rover_In_The_Platue_Outside_XBoundary_Test()
        {
            var commandableRover = _serviceProvider.GetService<ICommandableRover>();
            commandableRover.Name = "Rover1";
            commandableRover.SetPosition(10, 10, RoverDirections.North);

            Assert.ThrowsException<ApplicationException>(() => commandableRover.Move("L90R20"));
        }

    }
}
