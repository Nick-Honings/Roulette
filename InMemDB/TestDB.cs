
using Roulette.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testdatabase
{
    public static class TestDB
    {
        private static List<User> users = new List<IUserDTO>()
        {
            new UserDTO()
            {
                Id = 1,
                Name = "Nick",
                Password = "test",
                Email = "nick.honings@gmail.com",
                Age = 20,
                IsActive = true,
                Balance = 2000
            },
            new UserDTO()
            {
                Id = 2,
                Name = "Peter",
                Password = "test",
                Email = "Peter@gmail.com",
                Age = 20,
                IsActive = true,
                Balance = 1500
            },
            new UserDTO()
            {
                Id = 3,
                Name = "Henk",
                Password = "test",
                Email = "henk@gmail.com",
                Age = 20,
                IsActive = true,
                Balance = 23000
            },
            new UserDTO()
            {
                Id = 4,
                Name = "fda",
                Password = "test",
                Email = "fda@gmail.com",
                Age = 20,
                IsActive = true,
                Balance = 2000
            },
            new UserDTO()
            {
                Id = 5,
                Name = "abc",
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
            new NewsItemDTO()
            {
                Id = 1,
                Title = "New betting modes",
                Description = "New betting modes are available in this room",
                date = DateTime.Today
            },
            new NewsItemDTO()
            {
                Id = 2,
                Title = "Double Reward Weekend",
                Description = "There are new rewards available",
                date = DateTime.Today
            },
            new NewsItemDTO()
            {
                Id = 3,
                Title = "New game modes",
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
            new RoomDTO()
            {
                Id = 1,
                Name = "Speed Roulette",
                Capacity = 50,
                StakeUpLim = 2000,
                StakeLowLim = 0.50,
                RoundTime = 30
            },
            new RoomDTO()
            {
                Id = 2,
                Name = "Live Roulette",
                Capacity = 25,
                StakeUpLim = 20000,
                StakeLowLim = 0.50,
                RoundTime = 120
            },
            new RoomDTO()
            {
                Id = 3,
                Name = "Russian Roulette",
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
            new RoudDTO()
            {
                Id = 1,
                HasEnded = true,
                RoomId = 1
            },
            new RoudDTO()
            {
                Id = 2,
                HasEnded = true,
                RoomId = 1
            },
            new RoudDTO()
            {
                Id = 3,
                HasEnded = false,
                RoomId = 1
            },
            new RoudDTO()
            {
                Id = 4,
                HasEnded = true,
                RoomId = 2
            },
            new RoudDTO()
            {
                Id = 5,
                HasEnded = false,
                RoomId = 2
            },
            new RoudDTO()
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
            new PocketDTO()
            {
                Id = 1,
                ToColorNumber = 1,
                ToNumber = 12,
                RoundId = 1
            },
            new PocketDTO()
            {
                Id = 2,
                ToColorNumber = 2,
                ToNumber = 17,
                RoundId = 2
            },
            new PocketDTO()
            {
                Id = 3, 
                ToColorNumber = 1,
                ToNumber = 25,
                RoundId = 4
            }
        };

        public static List<IPocketDTO> ReturnPocketTable()
        {
            return pockets;
        }
    }
}
