using InterfaceLayerBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Users
{
    public class UserContainer
    {
        public List<User> Users { get; private set; }

        private IUserContainerDAL ContainerDAL;
        public UserContainer(IUserContainerDAL dAL)
        {
            Users = new List<User>();
            ContainerDAL = dAL;
        }

        public bool AddUser(User user)
        {
            if(user != null)
            {
                Users.Add(user);
                IUserDTO dto = new User(user.Name, null)
                {
                    Password = user.Password,
                    Email = user.Email,
                    Age = user.Age,
                    IsActive = user.IsActive,
                    Balance = user.Balance
                };
                if(ContainerDAL.Save(dto))
                {
                    return true;
                }
            }
            return false;
        }

        public bool RemoveUser(User user)
        {
            if (user != null)
            {
                Users.Remove(user);
                if(ContainerDAL.Delete(user.Id))
                {
                    return true;
                }                
            }
            return false;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            var dtos = ContainerDAL.GetAllUsers();
            foreach (var d in dtos)
            {
                User user = ExtractUser(d);
                users.Add(user);
            }
            Users = users;
            return users;
        }

        public User GetUserById(int id)
        {
            IUserDTO dto = ContainerDAL.GetUserById(id);
            User user = ExtractUser(dto);
            return user;
        }

        private User ExtractUser(IUserDTO dto)
        {
            return new User(dto.Name, null)
            {
                Email = dto.Email,
                Age = dto.Age,
                IsActive = dto.IsActive,
                Balance = dto.Balance
            };
        }
    }
}
