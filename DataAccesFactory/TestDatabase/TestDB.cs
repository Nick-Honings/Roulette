using InterfaceLayerBD;
using InterfaceLayerBD.News;
using Roulette.DAL.MYSQL;
using Roulette.DAL.MYSQL.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesFactory
{
    public static class TestDB
    {
        private static List<IUserDTO> users = new List<IUserDTO>()
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
    }
}
