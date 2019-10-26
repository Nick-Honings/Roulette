using System.Collections.Generic;

namespace Roulette
{
    public class Round
    {
        public int RoundId { get; private set; }
        public int ElapsedTime { get; set; }
        public List<User> Winners { get; private set; }
        public List<User> Losers { get; private set; }
        public Result Result { get; private set; }

        public Round(int id)
        {
            RoundId = id;
        }

        public void AddResult(Result result)
        {
            Result = result;
        }


    }
}