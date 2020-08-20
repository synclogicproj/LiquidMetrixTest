namespace Rover.Model
{
    public interface ICommandableRover
    {
        string Name { get; set; }
        void SetPosition(int x, int y, char direction);
        string Move(string commands);
        char GetCurrenctDirection();
    }
}
