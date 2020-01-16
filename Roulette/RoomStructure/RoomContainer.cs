using InterfaceLayerBD;
using InterfaceLayerBD.Bet;
using InterfaceLayerBD.Room;
using InterfaceLayerBD.Round;
using Roulette.GameStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    public class RoomContainer
    {
        // Dependencies 
        private readonly IRoundDAL _roundDAL;
        private readonly IUserDAL _userDAL;
        private readonly IBetDAL _betDAL;
        private readonly IRoomContainerDAL _containerDAL;
        private readonly IRoomDAL _roomDAL;
        private readonly IWheel _wheel;

        public List<Room> Rooms { get; private set; }
        

        public RoomContainer(
            IRoomContainerDAL containerdAL, 
            IRoomDAL roomDAL, 
            IRoundDAL roundDAL, 
            IUserDAL userDAL,
            IBetDAL betDAL,
            IWheel wheel)
        {            
            this._containerDAL = containerdAL;
            this._roomDAL = roomDAL;
            this._roundDAL = roundDAL;
            this._userDAL = userDAL;
            this._betDAL = betDAL;
            this._wheel = wheel;

            this.Rooms = this.GetAllRooms();
        }

        public bool AddRoom(Room room)
        {
            if (room != null)
            {                                
                IRoomDTO dto = room;
                if(_containerDAL.AddRoom(dto))
                {
                    Rooms.Add(room);
                    return true;
                }                              
            }
            return false;
        }

        public bool RemoveRoom(Room room)
        {
            if (room != null)
            {                
                if (_containerDAL.DeleteRoom(room.Id))
                {
                    Rooms.RemoveAt(Rooms.FindIndex(i => i.Id == room.Id));
                    return true;
                }
            }
            return false;
        }

        private List<Room> GetAllRooms()
        {
            List<Room> rooms = new List<Room>();
            var dtos = _containerDAL.GetAllRooms();

            foreach (var d in dtos)
            {                
                rooms.Add(ExtractRoom(d));                
            }           
            
            return rooms;
        }

        private Room ExtractRoom(IRoomDTO dto)
        {
            return new Room(dto.Id, _roomDAL, _roundDAL, _userDAL, _betDAL, _wheel)
            {
                Name = dto.Name,
                Capacity = dto.Capacity,
                StakeUpLim = dto.StakeUpLim,
                StakeLowLim = dto.StakeLowLim,
                RoundTime = dto.RoundTime
            };
        }

    }
}
