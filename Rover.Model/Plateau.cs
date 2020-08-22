using System;

namespace Rover.Model
{
    internal class Plateau : IPlateau
    {
        private readonly ICommandableRover[,] _surfaceArea;
        private readonly int _xUpperBound;
        private readonly int _yUpperBound;

        public Plateau(int xUpperBound = 40, int yUpperBound = 30)
        {
            _surfaceArea = new ICommandableRover[xUpperBound, yUpperBound];
            _xUpperBound = xUpperBound;
            _yUpperBound = yUpperBound;
        }

        /// <summary>
        /// Positions rover at given x, y coordinate of the grid
        /// </summary>
        /// <param name="rover">Rover that you want to position</param>
        /// <param name="x">X coordinate of the grid</param>
        /// <param name="y">Y coordinate of the grid</param>
        public void PositionRover(ICommandableRover rover, int x, int y)
        {
            GuardArea(rover, x, y);

            _surfaceArea[x, y] = rover;
        }

        /// <summary>
        /// Remove rover from the x, y coordinate of the grid
        /// </summary>
        /// <param name="x">X coordinate of the grid</param>
        /// <param name="y">Y coordinate of the grid</param>
        public void VoidPosition(int x, int y)
        {
            _surfaceArea[x, y] = null;
        }

        private void GuardArea(ICommandableRover rover, int x, int y)
        {
            if (x > _xUpperBound || y > _xUpperBound)
                throw new ApplicationException($"Attempt to move at position [{x},{y},{rover.CurrenctDirection}], {rover.Name} cannot move outside platue area {_xUpperBound}x{_yUpperBound}");

            if (x < 0 || y < 0)
                throw new ApplicationException($"Attempt to move at position [{x},{y},{rover.CurrenctDirection}], {rover.Name}  cannot must stay within platue area {_xUpperBound}x{_yUpperBound}");

            if (_surfaceArea[x, y] != null)
                throw new ApplicationException($"{_surfaceArea[x, y].Name} rover is stationed at [{x},{y},{rover.CurrenctDirection}]. Take a different route!");
        }

    }
}
