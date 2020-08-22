namespace Rover.Model
{
    internal class RoverMovementHandlerFactory : IRoverMovementHandlerFactory
    {
        public IRoverMovementHandler GetHandler(ICommandableRover commandableRover)
        {
            if (commandableRover.CurrenctDirection == RoverDirections.North)
                return new NorthBoundRoverHandler(commandableRover);
            else if (commandableRover.CurrenctDirection == RoverDirections.South)
                return new SouthBoundRoverHandler(commandableRover);
            else if (commandableRover.CurrenctDirection == RoverDirections.East)
                return new EastBoundRoverHandler(commandableRover);
            else
                return new WestBoundRoverHandler(commandableRover);
        }
    }
}
