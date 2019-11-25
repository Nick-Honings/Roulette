﻿using InterfaceLayerBD.Bet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Bets
{
    public class ColorBet : IBet, IColorBetDTO
    {
        Color _color;
        public Color Color
        {
            get
            {
                return this._color;
            }
            set
            {
                _color = value;
                color = (int)value;
            }
        }
        

        public int color { get; set; }
        public double Stake { get; set; }
        public int Payout { get; private set; } = 2;

        private IBetDAL betDAL;

        public ColorBet(Color color, IBetDAL dAL)
        {
            Color = color;
            betDAL = dAL;
        }
        public double GetReturnStake()
        {
            return Stake * Payout;
        }

        public bool Update()
        {
            object[] param = new object[] { this.color, this.Stake, this.Payout };

            if(betDAL.Insert<IColorBetDTO>(param))
            {
                return true;
            }

            return false;
        }
    }
}
