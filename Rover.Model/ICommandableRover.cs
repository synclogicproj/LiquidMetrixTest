namespace Rover.Model
{
    public interface ICommandableRover
    {
        string Name { get; set; }
        int CurrentXPos { get; }
        int CurrentYPos { get; }
        RoverDirections CurrenctDirection { get; }
        void SetPosition(int x, int y, RoverDirections direction);
        string Move(string commands);
    }
}
