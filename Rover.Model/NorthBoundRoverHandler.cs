using System;

namespace Rover.Model
{
    internal class NorthBoundRoverHandler : IRoverMovementHandler
    {
        private readonly ICommandableRover _commandableRover;

        public NorthBoundRoverHandler(ICommandableRover commandableRover)
        {
            _commandableRover = commandableRover;
        }
        public void MoveWheels(RoverCommand command)
        {
            int x = _commandableRover.CurrentXPos;

            if (command.Rotation == RoverRotates.Left)
            {
                x = _commandableRover.CurrentXPos - command.Steps;
                _commandableRover.SetPosition(x, _commandableRover.CurrentYPos, RoverDirections.West);
            }
            else if (command.Rotation == RoverRotates.Right)
            {
                x = _commandableRover.CurrentXPos + command.Steps;
                _commandableRover.SetPosition(x, _commandableRover.CurrentYPos, RoverDirections.East);
            }
            else
                throw new ApplicationException($"Northbound rover unable move {command.Steps} steps towards {command.Rotation}");
        }
    }
}