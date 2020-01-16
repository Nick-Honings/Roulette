using InterfaceLayerBD;
using System.Collections.Generic;

namespace Roulette.DAL.MYSQL
{
    public class UserDTO : IUserDTO
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
        public decimal Balance { get; set; }

        public List<string> Permissions { get; set; }

        public int UserRole { get; set; }
        public int RoomId { get; set; }
    }
}
