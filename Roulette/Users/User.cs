using System;

namespace Roulette.Users
{
    public class User : BaseUser
    {
        public string Email { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; } = true;
        public double Balance { get; set; } = 0;
        public IBet CurrentBet { get; private set; }

        public User()
        {

        }

        public void UpdateProfile()
        {
            throw new NotImplementedException();
        }

        public void MakeBet(double stake)
        {

        }

    }
}