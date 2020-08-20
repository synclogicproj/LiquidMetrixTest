using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Rover.Model
{
    internal class MarsRover : ICommandableRover
    {
        private readonly IPlateau _plateau;
        private char _currentDirection = 'N';
        private int _currentXPos;
        private int _currentYPos;

        public string Name { get; set; }

        public MarsRover(IPlateau plateau)
        {
            _plateau = plateau;
        }
        public string Move(string commands)
        {
            IList<RoverCommand> roverCommands = ParseCommands(commands);

            foreach(var roverCommand in roverCommands)
            {
                int x = _currentXPos;
                int y = _currentYPos;

                if (roverCommand.Rotation == 'L' && _currentDirection == 'N')
                {
                    x = _currentXPos - roverCommand.Steps;
                    _currentDirection = 'W';
                }
                else if (roverCommand.Rotation == 'R' && _currentDirection == 'N')
                {
                    x = _currentXPos + roverCommand.Steps;
                    _currentDirection = 'E';
                }
                else if (roverCommand.Rotation == 'L' && _currentDirection == 'S')
                {
                    x = _currentXPos + roverCommand.Steps;
                    _currentDirection = 'E';
                }
                else if (roverCommand.Rotation == 'R' && _currentDirection == 'S')
                {
                    x = _currentXPos - roverCommand.Steps;
                    _currentDirection = 'W';
                }
                else if (roverCommand.Rotation == 'L' && _currentDirection == 'E')
                {
                    y = _currentYPos + roverCommand.Steps;
                    _currentDirection = 'N';
                }
                else if (roverCommand.Rotation == 'R' && _currentDirection == 'E')
                {
                    y = _currentYPos - roverCommand.Steps;
                    _currentDirection = 'S';
                }
                else if (roverCommand.Rotation == 'L' && _currentDirection == 'W')
                {
                    y = _currentYPos - roverCommand.Steps;
                    _currentDirection = 'S';
                }
                else if (roverCommand.Rotation == 'R' && _currentDirection == 'W')
                {
                    y = _currentYPos + roverCommand.Steps;
                    _currentDirection = 'N';
                }

                SetPosition(x, y, _currentDirection);
            }

            return $"[{_currentXPos}, {_currentYPos}, {_currentDirection}]";
        }

        private IList<RoverCommand> ParseCommands(string commands)
        {
            List<RoverCommand> roverCommands = new List<RoverCommand>();
            string stepInCommand = string.Empty;

            for(int i = 0; i < commands.Length; i++)
            {
                char character = commands[i];
                if (character == 'L' || character == 'R')
                {
                    if (roverCommands.Count > 0 && !string.IsNullOrEmpty(stepInCommand))
                    {
                        roverCommands.Last().Steps = int.Parse(stepInCommand);
                        stepInCommand = string.Empty;
                    }

                    var roverCommand = new RoverCommand { Rotation = character };
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

        public void SetPosition(int x, int y, char direction)
        {
            _plateau.VoidPosition(_currentXPos, _currentYPos);
            _plateau.PositionRover(this, x, y);
            
            _currentXPos = x;
            _currentYPos = y;
            _currentDirection = direction;
        }

        public char GetCurrenctDirection()
        {
            return _currentDirection;
        }
    }
}
