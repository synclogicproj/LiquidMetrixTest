namespace Rover.Model
{
    internal class RoverCommand
    {
        public char Rotation { get; set; }
        public int Steps { get; set; }

        public override string ToString()
        {
            return $"Move {Steps} - {Rotation}";
        }
    }
}
