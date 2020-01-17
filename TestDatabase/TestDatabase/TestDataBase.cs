using Roulette;
using Roulette.Bets;
using Roulette.News;
using Roulette.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayerBD.Bet;
using InterfaceLayerBD.News;
using InterfaceLayerBD.Room;
using InterfaceLayerBD.Round;
using InterfaceLayerBD;
using Roulette.GameStructure;
using InterfaceLayerBD.Admin;

namespace TestDatabase.TestDatabase
{
    public static class TestDB
    {
        private static List<IRoomDTO> rooms = new List<IRoomDTO>()
        {
            new Room(1)
            {                
                Name = "Speed Roulette",
                Capacity = 50,
                StakeUpLim = 2000,
                StakeLowLim = 0.50,
                RoundTime = 30
            },
            new Room(2)
            {
                Name = "Live Roulette",
                Capacity = 25,
                StakeUpLim = 20000,
                StakeLowLim = 0.50,
                RoundTime = 120
            },
            new Room(3)
            {
                Name = "Russian Roulette",
                Capacity = 6,
                StakeUpLim = 2000,
                StakeLowLim = 0.50,
                RoundTime = 30
            },
        };

        private static List<IUserDTO> users = new List<IUserDTO>()
        {
            new User("Nick", null, null)
            {
                Id = 1,
                Password = "test",
                Email = "nick.honings@gmail.com",
                Age = 20,
                IsActive = true,
                Balance = 2000,
                UserRole = 2,
                RoomId = 1

            },
            new User("Peter", null, null)
            {
                Id = 2,
                Password = "test",
                Email = "Peter@gmail.com",
                Age = 20,
                IsActive = true,
                Balance = 1500,
                UserRole = 2,
                RoomId = 2

            },
            new User("Henk", null, null)
            {
                Id = 3,
                Password = "test",
                Email = "henk@gmail.com",
                Age = 20,
                IsActive = true,
                Balance = 23000,
                UserRole = 2,
                RoomId = 3
            },
            new User("fda", null, null)
            {
                Id = 4,
                Password = "test",
                Email = "fda@gmail.com",
                Age = 20,
                IsActive = true,
                Balance = 2000,
                UserRole = 2
            },
            new User("abc", null, null)
            {
                Id = 5,
                Password = "test",
                Email = "abc@gmail.com",
                Age = 20,
                IsActive = true,
                Balance = 2000,
                UserRole = 2
            },
        };

        private static List<IAdminDTO> admins = new List<IAdminDTO>()
        {
            new Admin(null)
            {
                Id = 6,
                Name = "admin1",
                Password = "admin1",
                UserRole = 1
            },
            new Admin(null)
            {
                Id = 7,
                Name = "admin2",
                Password = "admin2",
                UserRole = 1
            },
        };

        private static List<INewsItemDTO> news = new List<INewsItemDTO>() 
        {
            new NewsItem("New betting modes", null)
            {
                Id = 1,
                Description = "New betting modes are available in this room",
                PostDate = DateTime.Today
            },
            new NewsItem("Double Reward Weekend", null)
            {
                Id = 2,
                Description = "There are new rewards available",
                PostDate = DateTime.Today
            },
            new NewsItem("New game modes", null)
            {
                Id = 3,
                Description = "New game modes are available",
                PostDate = DateTime.Today
            },
        };

        private static List<IRoundDTO> rounds = new List<IRoundDTO>()
        {
            new Round(1)
            {
                HasEnded = true,
                RoomId = 1
            },
            new Round(2)
            {
                HasEnded = true,
                RoomId = 1
            },
            new Round(3)
            {
                HasEnded = false,
                RoomId = 1
            },
            new Round(4)
            {
                HasEnded = true,
                RoomId = 2
            },
            new Round(5)
            {
                HasEnded = false,
                RoomId = 2
            },
            new Round(6)
            {         
                HasEnded = false,
                RoomId = 3
            },
        };

        private static List<IPocketDTO> pockets = new List<IPocketDTO>()
        {
            // Have to check for actual number/color combinations.
            new Pocket((IPocketNumber)12)
            {
                Id = 1,
                RoundId = 1
            },
            new Pocket((IPocketNumber)17)
            {
                Id = 2,
                RoundId = 2
            },
            new Pocket((IPocketNumber)25)
            {
                Id = 3,
                RoundId = 4
            }
        };

        private static List<IBet> bets = new List<IBet>()
        {
            new ColorBet(IPocketColor.Black)
            {
                Id = 1,
                Stake = 20,                
            },
            new ColorBet(IPocketColor.Red)
            {
                Id = 1,
                Stake = 10,
            },
            new SingleNumberBet(IPocketNumber.Eight)
            {
                Id = 2,
                Stake = 50
            },
            new EvenUnevenBet(true)
            {
                Id = 2,
                Stake = 1000
            },
            new NeighbourBet(IPocketNumber.Eightteen, IPocketNumber.Nineteen)
            {
                Id = 2,
                Stake = 200
            }
        };

        public static List<IBet> GetBetsTable()
        {
            return bets;
        }

        public static List<IUserDTO> GetUserTable()
        {
            return users;
        }
        public static List<IAdminDTO> GetAdminTable()
        {
            return admins;
        }
        public static List<INewsItemDTO> GetNewsTable()
        {
            return news;
        }
        public static List<IRoomDTO> GetRoomsTable()
        {
            return rooms;
        }
        public static List<IRoundDTO> GetRoundsTable()
        {
            return rounds;
        }
        public static List<IPocketDTO> GetPocketTable()
        {
            return pockets;
        }
    }
}
