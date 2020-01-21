using Roulette.ASP.NETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette.ASP.NETCore.ViewModels
{
    public class BetViewModel
    {
        public List<BetModel> BetModels { get; set; }

        public BetViewModel()
        {
            BetModels = new List<BetModel>()
            {
                new BetModel
                {
                    Type = Bets.BetType.Color,
                    Stake = 100
                },
                new BetModel
                {
                    Type = Bets.BetType.EvenUneven,
                    Stake = 1030
                },
                new BetModel
                {
                    Type = Bets.BetType.Single,
                    Stake = 10
                }
            };
        }

    }
}
