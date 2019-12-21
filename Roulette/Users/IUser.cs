namespace Roulette.Users
{
    public interface IUser
    {
        string Name { get; }
        int Age { get; set; }
        decimal Balance { get; set; }
        string Email { get; set; }
        bool IsActive { get; set; }

        void UpdateProfile();
    }
}