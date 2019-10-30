using System.Collections.Generic;
using Roulette.Users;

namespace Roulette
{
    public class Round
    {
        public int RoundId { get; set; }
        public int ElapsedTime { get; set; }
        public Result Result { get; private set; }
        public List<IBet> Bets { get; private set; }

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