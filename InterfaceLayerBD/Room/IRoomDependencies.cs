using InterfaceLayerBD;
using InterfaceLayerBD.Bet;
using InterfaceLayerBD.Room;
using InterfaceLayerBD.Round;


namespace InterfaceLayerBD.Room
{
    public interface IRoomDependencies
    {
        IBetDAL BetDAL { get; }
        IRoomContainerDAL RoomContainerDAL { get; }
        IRoomDAL RoomDAL { get; }
        IRoundDAL RoundDAL { get; }
        IUserDAL UserDAL { get; }        
    }
}