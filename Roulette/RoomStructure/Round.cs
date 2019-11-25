using System;
using System.Collections.Generic;
using System.Timers;
using Roulette.Users;

namespace Roulette
{
    public class Round
    {
        public int RoundId { get; set; }
        public int TimeLeft { get; set; }
        private bool hasEnded;
        public bool HasEnded 
        { 
            get 
            { 
                return hasEnded; 
            } 
            set 
            {
                hasEnded = value;
                if (value == true)
                {
                    roundTimer.Stop();
                    RoundEndedArgs args = new RoundEndedArgs();
                    RoundEnded(this, args);
                }
            } 
        }

        public Result Result { get; private set; }
        public List<IBet> Bets { get; private set; }
        
        private Timer roundTimer;

        public Round(int roundTime)
        {
            TimeLeft = roundTime;
            roundTimer = new Timer(roundTime);
            roundTimer.Elapsed += RoundTimer_Elapsed;
            roundTimer.Start();
        }

        private void RoundTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            TimeLeft--;
            if(TimeLeft <= 0)
            {
                HasEnded = true;
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

        public class RoundEndedArgs : EventArgs
        {
            public string RoundHasEnded = "Round has ended, no betting is allowed";
        }

        public delegate void RoundEndedEventHandler(
            object sender, RoundEndedArgs args);

        public event RoundEndedEventHandler RoundEnded;
    }
}