using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Bets;
using Roulette.Users;

namespace Roulette
{
    public class Room
    {
        public string Name { get; private set; }
        public int Capacity { get; set; } = 20;
        public double StakeUpLim { get; set; } = 2500;
        public double StakeLowLim { get; set; } = 0.5;
        public int RoundTime { get; set; } = 30;

        public List<Round> Rounds { get; private set; }
        public List<IPlayer> Players { get; private set; }


        public Room(string name)
        {
            Name = name;
            Rounds = new List<Round>();
            Players = new List<IPlayer>();
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

        public void AddUser(IPlayer player)
        {
            Players.Add(player);
        }

        public void RemoveUser(IPlayer player)
        {
            Players.Remove(player);
        }

        public void UpdateUserBalance()
        {
            Result result = Rounds[Rounds.Count - 1].GetResult();

            foreach ( IPlayer p in Players)
            {
                IBet bet = p.CurrentBet;
                if(bet is ColorBet cBet)
                {
                    if(cBet.Color == result.Color)
                    {
                        p.Balance += cBet.GetReturnStake();
                    }
                }
                if (bet is EvenUnevenBet eBet)
                {
                    if (eBet.IsEven == result.IsEven)
                    {
                        p.Balance += eBet.GetReturnStake();
                    }
                }
                if (bet is NeighbourBet nBet)
                {
                    if (nBet.Neighbours[0] == result.Number | nBet.Neighbours[1] == result.Number)
                    {
                        p.Balance += nBet.GetReturnStake();
                    }
                }
                if (bet is SingleNumberBet sBet)
                {
                    if (sBet.Number == result.Number)
                    {
                        p.Balance += sBet.GetReturnStake();
                    }
                }
            }
        }
    }
}
