﻿namespace Roulette.Users
{
    public interface IUser
    {
        string Name { get; }
        int Age { get; set; }
        double Balance { get; set; }
        string Email { get; set; }
        bool IsActive { get; set; }

        void UpdateProfile();
    }
}