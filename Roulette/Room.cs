using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Bets;

namespace Roulette
{
    public class Room
    {
        public string Name { get; private set; }
        public int Capacity { get; set; }
        public int StakeUpLim { get; set; }
        public int StakeLowLim { get; set; }
        public int RoundTime { get; set; }

        public List<Round> Rounds { get; private set; }
        public List<User> Players { get; private set; }


        public Room(string name)
        {
            Name = name;
        }

        public void AddRound(Round round)
        {
            foreach (Round r in Rounds)
            {
                if (r.RoundId == round.RoundId)
                {
                    return;
                }
            }
            Rounds.Add(round);
        }

        public void StartRound()
        {
            
        }

        public void AddUser(User user)
        {

        }

        public void RemoveUser(User user)
        {

        }

    }
}
