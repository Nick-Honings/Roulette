using InterfaceLayerBD;
using InterfaceLayerBD.News;
using InterfaceLayerBD.Room;
using InterfaceLayerBD.Round;
using Roulette;
using Roulette.GameStructure;
using Roulette.News;
using Roulette.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDatabase.TestDatabase
{
    public static class TestDBREAL
    {
        private static List<IUserDTO> users = new List<IUserDTO>()
        {
            new User("Nick", null)
            {
                Id = 1,
                Password = "test",
                Email = "nick.honings@gmail.com",
                Age = 20,
                IsActive = true,
                Balance = 2000
            },
            new User("Peter", null)
            {
                Id = 2,               
                Password = "test",
                Email = "Peter@gmail.com",
                Age = 20,
                IsActive = true,
                Balance = 1500
            },
            new User("Henk", null)
            {
                Id = 3,
                Password = "test",
                Email = "henk@gmail.com",
                Age = 20,
                IsActive = true,
                Balance = 23000
            },
            new User("fda", null)
            {
                Id = 4,
                Password = "test",
                Email = "fda@gmail.com",
                Age = 20,
                IsActive = true,
                Balance = 2000
            },
            new User("abc", null)
            {
                Id = 5,                
                Password = "test",
                Email = "abc@gmail.com",
                Age = 20,
                IsActive = true,
                Balance = 2000
            }
        };

        public static List<IUserDTO> ReturnUserTable()
        {
            return users;
        }

        private static List<INewsItemDTO> news = new List<INewsItemDTO>()
        {
            new NewsItem("New betting modes", null)
            {
                Id = 1,
                Description = "New betting modes are available in this room",
                date = DateTime.Today
            },
            new NewsItem("Double Reward Weekend", null)
            {
                Id = 2,
                Description = "There are new rewards available",
                date = DateTime.Today
            },
            new NewsItem("New game modes", null)
            {
                Id = 3,                
                Description = "New game modes are available",
                date = DateTime.Today
            },
        };

        public static List<INewsItemDTO> ReturnNewsTable()
        {
            return news;
        }

        private static List<IRoomDTO> rooms = new List<IRoomDTO>()
        {
            new Room("Speed Roulette", null)
            {
                Id = 1,                
                Capacity = 50,
                StakeUpLim = 2000,
                StakeLowLim = 0.50,
                RoundTime = 30
            },
            new Room("Live Roulette", null)
            {
                Id = 2,                
                Capacity = 25,
                StakeUpLim = 20000,
                StakeLowLim = 0.50,
                RoundTime = 120
            },
            new Room("Russian Roulette", null)
            {
                Id = 3,                
                Capacity = 6,
                StakeUpLim = 2000,
                StakeLowLim = 0.50,
                RoundTime = 30
            },
        };

        public static List<IRoomDTO> ReturnRoomTable()
        {
            return rooms;
        }

        private static List<IRoundDTO> rounds = new List<IRoundDTO>()
        {
            new Round(null, 30)
            {
                Id = 1,
                HasEnded = true,
                RoomId = 1
            },
            new Round(null, 30)
            {
                Id = 2,
                HasEnded = true,
                RoomId = 1
            },
            new Round(null, 30)
            {
                Id = 3,
                HasEnded = false,
                RoomId = 1
            },
            new Round(null, 120)
            {
                Id = 4,
                HasEnded = true,
                RoomId = 2
            },
            new Round(null, 120)
            {
                Id = 5,
                HasEnded = false,
                RoomId = 2
            },
            new Round(null, 30)
            {
                Id = 6,
                HasEnded = false,
                RoomId = 3
            },
        };

        public static List<IRoundDTO> ReturnRoundTable()
        {
            return rounds;
        }

        private static List<IPocketDTO> pockets = new List<IPocketDTO>()
        {
            // Have to check for actual number/color combinations.
            new Pocket((PocketNumber)12)
            {
                Id = 1,
                RoundId = 1
            },
            new Pocket((PocketNumber)17)
            {
                Id = 2,
                RoundId = 2
            },
            new Pocket((PocketNumber)25)
            {
                Id = 3,
                RoundId = 4
            }
        };

        public static List<IPocketDTO> ReturnPocketTable()
        {
            return pockets;
        }
    }
}
