using InterfaceLayerBD;

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
        public double Balance { get; set; }        
    }
}
