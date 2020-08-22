using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Rover.Model
{
    internal class MarsRover : ICommandableRover
    {
        #region private fields
        
        private readonly IPlateau _plateau;
        private readonly IRoverMovementHandlerFactory _roverMovementHandlerFactory;
        private RoverDirections _currentDirection = RoverDirections.North;
        private int _currentXPos;
        private int _currentYPos;

        #endregion

        #region public properties        
        public string Name { get; set; }
        public int CurrentXPos => _currentXPos; 
        public int CurrentYPos => _currentYPos; 
        public RoverDirections CurrenctDirection => _currentDirection;

        #endregion

        public MarsRover(IPlateau plateau, IRoverMovementHandlerFactory roverMovementHandlerFactory)
        {
            _plateau = plateau;
            _roverMovementHandlerFactory = roverMovementHandlerFactory;
        }

        #region public methods
        public string Move(string commands)
        {
            IList<RoverCommand> roverCommands = ParseCommands(commands);

            foreach(var roverCommand in roverCommands)
            {
                IRoverMovementHandler roverMovementHandler = _roverMovementHandlerFactory.GetHandler(this);
                roverMovementHandler.MoveWheels(roverCommand);

                #region Refactored using factory and strategy design pattern. This method should not have anymore reason to change to comply with open and close principle

                //int x = _currentXPos;
                //int y = _currentYPos;

                //if (roverCommand.Rotation == RoverRotates.Left && _currentDirection == RoverDirections.North)
                //{
                //    x = _currentXPos - roverCommand.Steps;
                //    _currentDirection = 'W';
                //}
                //else if (roverCommand.Rotation == RoverRotates.Right && _currentDirection == RoverDirections.North)
                //{
                //    x = _currentXPos + roverCommand.Steps;
                //    _currentDirection = 'E';
                //}
                //else if (roverCommand.Rotation == RoverRotates.Left && _currentDirection == 'S')
                //{
                //    x = _currentXPos + roverCommand.Steps;
                //    _currentDirection = 'E';
                //}
                //else if (roverCommand.Rotation == RoverRotates.Right && _currentDirection == 'S')
                //{
                //    x = _currentXPos - roverCommand.Steps;
                //    _currentDirection = 'W';
                //}
                //else if (roverCommand.Rotation == RoverRotates.Left && _currentDirection == 'E')
                //{
                //    y = _currentYPos + roverCommand.Steps;
                //    _currentDirection = RoverDirections.North;
                //}
                //else if (roverCommand.Rotation == RoverRotates.Right && _currentDirection == 'E')
                //{
                //    y = _currentYPos - roverCommand.Steps;
                //    _currentDirection = 'S';
                //}
                //else if (roverCommand.Rotation == RoverRotates.Left && _currentDirection == 'W')
                //{
                //    y = _currentYPos - roverCommand.Steps;
                //    _currentDirection = 'S';
                //}
                //else if (roverCommand.Rotation == RoverRotates.Right && _currentDirection == 'W')
                //{
                //    y = _currentYPos + roverCommand.Steps;
                //    _currentDirection = RoverDirections.North;
                //}

                //SetPosition(x, y, _currentDirection);

                #endregion 
            }

            return $"[{CurrentXPos}, {CurrentYPos}, {(char)CurrenctDirection}]";
        }

        public void SetPosition(int x, int y, RoverDirections direction)
        {
            _plateau.VoidPosition(_currentXPos, _currentYPos);
            _plateau.PositionRover(this, x, y);
            
            _currentXPos = x;
            _currentYPos = y;
            _currentDirection = direction;
        }

        #endregion

        #region private methods

        private IList<RoverCommand> ParseCommands(string commands)
        {
            List<RoverCommand> roverCommands = new List<RoverCommand>();
            string stepInCommand = string.Empty;

            for (int i = 0; i < commands.Length; i++)
            {
                char character = commands[i];
                if (character == (char)RoverRotates.Left || character == (char)RoverRotates.Right)
                {
                    if (roverCommands.Count > 0 && !string.IsNullOrEmpty(stepInCommand))
                    {
                        roverCommands.Last().Steps = int.Parse(stepInCommand);
                        stepInCommand = string.Empty;
                    }

                    var roverCommand = new RoverCommand { Rotation = (RoverRotates)Enum.ToObject(typeof(RoverRotates), character) };
                    roverCommands.Add(roverCommand);
                    continue;
                }

                if (char.IsDigit(character))
                    stepInCommand = string.Concat(stepInCommand, character);
            }

            if (roverCommands.Count > 0 && !string.IsNullOrEmpty(stepInCommand))
                roverCommands.Last().Steps = int.Parse(stepInCommand);

            return roverCommands;
        }

        #endregion

    }
}
