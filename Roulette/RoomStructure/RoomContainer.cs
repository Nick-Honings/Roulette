using InterfaceLayerBD.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    public class RoomContainer
    {
        public List<Room> Rooms { get; private set; }

        private IRoomContainerDAL containerDAL;

        public RoomContainer(IRoomContainerDAL dAL)
        {
            Rooms = new List<Room>();
            containerDAL = dAL;
        }

        public bool AddRoom(Room room)
        {
            if (room != null)
            {
                foreach (Room r in Rooms)
                {
                    if (r.Name != room.Name)
                    {
                        Rooms.Add(room);
                        IRoomDTO dTO = new Room(room.Name, null)
                        {
                            Capacity = room.Capacity,
                            StakeUpLim = room.StakeUpLim,
                            StakeLowLim = room.StakeLowLim,
                            RoundTime = room.RoundTime
                        };
                        if(containerDAL.Save(dTO))
                        {
                            return true;
                        }                        
                    }
                }                
            }
            return false;
        }

        public bool RemoveRoom(Room room)
        {
            if (room != null)
            {
                Rooms.Remove(room);
                if (containerDAL.Delete(room.Id))
                {
                    return true;
                }
            }
            return false;
        }

        public List<Room> GetAllRooms()
        {
            List<Room> rooms = new List<Room>();
            var dtos = containerDAL.GetAllRooms();
            foreach (var d in dtos)
            {
                rooms.Add(ExtractRoom(d));                
            }
            Rooms = rooms;
            return rooms;
        }

        private Room ExtractRoom(IRoomDTO dto)
        {
            return new Room(dto.Name, null)
            {
                Id = dto.Id,
                Capacity = dto.Capacity,
                StakeUpLim = dto.StakeUpLim,
                StakeLowLim = dto.StakeLowLim,
                RoundTime = dto.RoundTime
            };
        }

    }
}
