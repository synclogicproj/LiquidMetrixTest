using System;

namespace Rover.Model
{
    internal class EastBoundRoverHandler : IRoverMovementHandler
    {
        private ICommandableRover _commandableRover;

        public EastBoundRoverHandler(ICommandableRover commandableRover)
        {
            _commandableRover = commandableRover;
        }

        public void MoveWheels(RoverCommand command)
        {
            int y = _commandableRover.CurrentYPos;

            if (command.Rotation == RoverRotates.Left)
            {
                y = _commandableRover.CurrentYPos + command.Steps;
                _commandableRover.SetPosition(_commandableRover.CurrentXPos, y, RoverDirections.North);
            }
            else if (command.Rotation == RoverRotates.Right)
            {
                y = _commandableRover.CurrentYPos - command.Steps;
                _commandableRover.SetPosition(_commandableRover.CurrentXPos, y, RoverDirections.South);
            }
            else
                throw new ApplicationException($"Eastbound rover unable move {command.Steps} steps towards {command.Rotation}");

        }
    }
}