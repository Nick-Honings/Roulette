using System;
using System.Collections.Generic;
using System.Timers;
using InterfaceLayerBD;
using InterfaceLayerBD.Bet;
using InterfaceLayerBD.Round;
using Roulette.GameStructure;
using Roulette.Users;

namespace Roulette
{
    public class Round : IRoundDTO
    {       

        // Dependencies
        private readonly IWheel _wheel;
        private readonly IRoundDAL _roundDAL;

        public int Id { get; set; }
        public int RoundTime { get; set; }
        public bool HasEnded { get; set; } = false;
        public int RoomId { get; set; }

        public IPocket Pocket { get; private set; }
        

        //public List<IBet> Bets { get; private set; }

        public event EventHandler<RoundEndedEventArgs> RoundEnded;

        
        private Timer roundTimer;
        private int counter = 0;


        public Round(int id, IRoundDAL roundDAL, IWheel wheel)
        {
            this.Id = id;
            this._roundDAL = roundDAL;
            this._wheel = wheel;
            roundTimer = new Timer(1000);
            roundTimer.Elapsed += RoundTimer_Elapsed;

            this.Pocket = ExtractPocket(_roundDAL.GetPocket(this.Id));
        }

        //Constructor just used for testing in mem.
        // This prevents a type error.
        public Round(int id)
        {
            this.Id = id;
        }

        private void RoundTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            counter++;
            if (counter >= RoundTime)
            {
                this.EndRound();
            }
        }

        private void EndRound()
        {
            HasEnded = true;
            Pocket = _wheel.Spin();
            this.roundTimer.Stop();
            if (RoundEnded != null)
            {
                RoundEnded(this, new RoundEndedEventArgs("Round has ended"));                
            }
            this._roundDAL.Update(this);
            
        }

        internal void Start()
        {
            // Start the timer that holds track of how long into the round we are.
            this.roundTimer.Start();
        }
   
        private IPocket ExtractPocket(IPocketDTO dto)
        {
            return new Pocket((IPocketNumber)dto.ToNumber);  
        }
    
    }
}