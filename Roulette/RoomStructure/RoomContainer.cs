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

        public RoomContainer()
        {
            Rooms = new List<Room>();
        }

        public void AddRoom(Room room)
        {
            if (room != null)
            {
                foreach (Room r in Rooms)
                {
                    if (r.Name == room.Name)
                    {
                        return;
                    }
                }
                Rooms.Add(room); 
            }
        }

        public void RemoveRoom(Room room)
        {
            Rooms.Remove(room);  
        }

    }
}
