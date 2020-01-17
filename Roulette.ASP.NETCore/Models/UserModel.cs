namespace Roulette.ASP.NETCore.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
        public decimal Balance { get; set; }
        public int RoomId { get; set; }
    }
}
