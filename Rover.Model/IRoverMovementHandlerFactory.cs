namespace Rover.Model
{
    internal interface IRoverMovementHandlerFactory
    {
        IRoverMovementHandler GetHandler(ICommandableRover commandableRover);
    }
}
