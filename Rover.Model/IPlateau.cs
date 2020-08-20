namespace Rover.Model
{
    public interface IPlateau
    {
        void PositionRover(ICommandableRover rover, int x, int y);
        void VoidPosition(int x, int y);
    }
}
