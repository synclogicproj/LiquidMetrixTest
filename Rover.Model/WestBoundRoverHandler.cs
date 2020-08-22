using System;

namespace Rover.Model
{
    internal class WestBoundRoverHandler : IRoverMovementHandler
    {
        private ICommandableRover _commandableRover;

        public WestBoundRoverHandler(ICommandableRover commandableRover)
        {
            _commandableRover = commandableRover;
        }

        public void MoveWheels(RoverCommand command)
        {
            int y = _commandableRover.CurrentYPos;

            if (command.Rotation == RoverRotates.Left)
            {
                y = _commandableRover.CurrentYPos - command.Steps;
                _commandableRover.SetPosition(_commandableRover.CurrentXPos, y, RoverDirections.South);
            }
            else if (command.Rotation == RoverRotates.Right)
            {
                y = _commandableRover.CurrentYPos + command.Steps;
                _commandableRover.SetPosition(_commandableRover.CurrentXPos, y, RoverDirections.North);
            }
            else
                throw new ApplicationException($"Westbound rover unable move {command.Steps} steps towards {command.Rotation}");
        }
    }
}