using Roulette.Users;
using System;

namespace Roulette.BattleStructure
{
    public class Battle : IBattle
    {
        public object Id { get; internal set; }
        public int Player1Id { get; private set; }
        public double Player1Profit { get; set; }
        public int Player2Id { get; private set; }
        public double Player2Profit { get; set; }
        public DateTime StartDate { get; private set; }
        //Raise event when accepted?
        public bool IsAccepted { get; set; }
        public bool HasEnded { get; private set; }
        public int TimePeriod { get; private set; }
        public double ProfitGoal { get; set; }

        public Battle()
        {
            
        }

        //Obsolete, might move this one to battlecontainer.
        //If IsAccepted = true, this method has to execute.
        //Has to set start time to DateTime.Now.ToUTC().
        public void StartBattle()
        {

            throw new NotImplementedException();
        }

        //Has to update HasEnded property, value changes to true if time has ended.
        public void EndBattle()
        {
            throw new NotImplementedException();
        }

        public void SetTimePeriod(int time)
        {
            TimePeriod = time;
        }

    }
}