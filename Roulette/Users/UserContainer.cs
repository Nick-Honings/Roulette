
using InterfaceLayerBD;
using InterfaceLayerBD.Bet;
using Roulette.Users.Eventargs;
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

        private readonly IUserContainerDAL _containerDAL;
        private readonly IUserDAL _userdal;
        private readonly IBetDAL _betDAL;

        //Alle dependecies injecteren via deze constructor.

        public UserContainer(IUserContainerDAL dAL, IUserDAL userdal, IBetDAL betDAL)
        {
            this._containerDAL = dAL;
            this._userdal = userdal;
            this._betDAL = betDAL;
            Users = this.GetAllUsers();
            
        }

        //Adds a user to the database.
        public bool AddUser(User user)
        {
            if(user != null)
            {
                // Before we add the user, check if he already exists.
                //if (user.VerifyLogin(_userdal))
                //{
                //    return true;
                //}

                if(_containerDAL.AddUser(user))
                {
                    Users.Add(user);
                    return true;
                }
            }
            return false;
        }

        //Removes a user from the database
        public bool RemoveUser(User user)
        {
            if (user != null)
            {                
                if(_containerDAL.DeleteUser(user.Id))
                {
                    Users.Remove(user);
                    return true;
                }                
            }
            return false;
        }

        //Gets all users from the database.
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            var dtos = _containerDAL.GetAllUsers();
            foreach (var d in dtos)
            {
                User user = ExtractUser(d);
                users.Add(user);
            }            
            return users;
        }

        // Gets a user by id.
        public User GetUserById(int id)
        {
            IUserDTO dto = _containerDAL.GetUserById(id);

            User user = ExtractUser(dto);

            return user;
        }

        // Fires when a new user is added by a admin class.
        public void ReceiveNewUserNotification(object sender, NewUserEventArgs e)
        {
            this.Users = this.GetAllUsers();
        }

        public void ReceiveUserModificationNotification(object sender, UserModificationEventArgs e)
        {
            var user = this.GetUserById(e.UserId);
            int index = this.Users.FindIndex(i => i.Id == e.UserId);
            this.Users[index] = user;
        }

        // Constructs a user class out of an dto object.
        private User ExtractUser(IUserDTO dto)
        {
            if (dto != null)
            {
                return new User(dto.Name, _userdal, _betDAL)
                {
                    Id = dto.Id,                    
                    Email = dto.Email,
                    Age = dto.Age,
                    IsActive = dto.IsActive,
                    Balance = dto.Balance,
                    Permissions = dto.Permissions,
                    UserRole = dto.UserRole,
                    RoomId = dto.RoomId
                    
                }; 
            }
            return null;
        }
    }
}
