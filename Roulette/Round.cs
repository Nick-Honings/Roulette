using System.Collections.Generic;
using Roulette.Users;

namespace Roulette
{
    public class Round
    {
        public int RoundId { get; private set; }
        public int ElapsedTime { get; set; }
        public Result Result { get; private set; }
        public List<IBet> Bets { get; private set; }

        public Round(int id)
        {
            RoundId = id;
        }

        public void AddResult(Result result)
        {
            if (Result == null)
            {
                Result = result; 
            }
        }

        public Result GetResult()
        {
            return Result;
        }
    }
}