using System;

namespace Rover.Model
{
    internal class SouthBoundRoverHandler : IRoverMovementHandler
    {
        private ICommandableRover _commandableRover;

        public SouthBoundRoverHandler(ICommandableRover commandableRover)
        {
            _commandableRover = commandableRover;
        }

        public void MoveWheels(RoverCommand command)
        {
            int x = _commandableRover.CurrentXPos;

            if (command.Rotation == RoverRotates.Left)
            {
                x = _commandableRover.CurrentXPos + command.Steps;
                _commandableRover.SetPosition(x, _commandableRover.CurrentYPos, RoverDirections.East);
            }
            else if (command.Rotation == RoverRotates.Right)
            {
                x = _commandableRover.CurrentXPos - command.Steps;
                _commandableRover.SetPosition(x, _commandableRover.CurrentYPos, RoverDirections.West);
            }
            else
                throw new ApplicationException($"Southbound rover unable move {command.Steps} steps towards {command.Rotation}");

        }
    }
}