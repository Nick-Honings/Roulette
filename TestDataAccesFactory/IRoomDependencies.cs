using InterfaceLayerBD;
using InterfaceLayerBD.Bet;
using InterfaceLayerBD.Room;
using InterfaceLayerBD.Round;
using Roulette.GameStructure;

namespace TestDataAccesFactory
{
    public interface IRoomDependencies
    {
        IBetDAL BetDAL { get; }
        IRoomContainerDAL RoomContainerDAL { get; }
        IRoomDAL RoomDAL { get; }
        IRoundDAL RoundDAL { get; }
        IUserDAL UserDAL { get; }
        IWheel Wheel { get; }
    }
}