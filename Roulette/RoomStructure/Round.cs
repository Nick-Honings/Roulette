using System;
using System.Collections.Generic;
using System.Timers;
using Roulette.GameStructure;
using Roulette.Users;

namespace Roulette
{
    public class Round
    {
        public int RoundId { get; set; }
        public int TimeLeft { get; set; }        
        public bool HasEnded { get; set; }

        // Obsolete
        public Result Result { get; private set; }

        public IPocket Pocket { get; set; }

        //public List<IBet> Bets { get; private set; }

        public event EventHandler<RoundEndedEventArgs> RoundEnded;

        private IWheel _wheel;
        private Timer roundTimer;
        private int counter = 0;

        public Round(IWheel wheel, int roundTime)
        {
            _wheel = wheel;
            TimeLeft = roundTime;
            roundTimer = new Timer(1000);
            roundTimer.Elapsed += RoundTimer_Elapsed;
            
        }

        private void RoundTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            counter++;
            if (counter >= TimeLeft)
            {
                EndRound();
            }
        }

        private IPocket GetPocket()
        {
            return Pocket;
        }

        private void EndRound()
        {
            HasEnded = true;
            Pocket = _wheel.Spin();
            if(RoundEnded != null)
            {
                RoundEnded(this, new RoundEndedEventArgs("Round has ended"));
            }
            
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