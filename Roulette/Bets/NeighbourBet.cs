﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Bets
{
    public class NeighbourBet : IBet
    {
        public Color Color { get; set; }
        public string Name { get; set; }
        public double Stake { get; set; }
        public int Payout { get; } = 2;

        public double GetReturnStake()
        {
            return Stake * Payout;
        }
    }
}
