using InterfaceLayerBD.Bet;
using Roulette;
using Roulette.Bets;
using Roulette.GameStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDatabase.TestDatabase;

namespace TestDataAccesFactory.TestDAL
{
    public class TestBetDAL : IBetDAL
    {
        private List<IBet> bets;

        public TestBetDAL()
        {
            bets = TestDB.GetBetsTable();
        }

        public IBetDTO GetCurrentBet(int id)
        {
            // Needs a fix
            return null;
        }

        public bool Insert<T>(object[] param)
        {
            return true;
        }

        // Not going to retriev bet type. This won't be used in the application.
        // FOR GETTING BET INFO

        public bool Save(IBetDTO dto)
        {
            bets.Add(MakeBetObject(dto));
            return true;
        }

        private IBet MakeBetObject(IBetDTO bet)
        {
            var info = bet.GetBetSpecificInfo();
            IBet output = null;
            if (info.TryGetValue("Color", out object tempcolor))
            {
                int color = (int)tempcolor;
                output = new ColorBet((IPocketColor)color)
                {
                    Id = bet.Id,
                    Stake = bet.Stake,
                };
            }
 
            else if (info.TryGetValue("IsEven", out object tempEven))
            {
                bool isEven = (bool)tempEven;
                output = new EvenUnevenBet(isEven)
                {
                    Id = bet.Id,
                    Stake = bet.Stake,
                };
            }           

            else if (info.TryGetValue("FirstNumber", out object first) && info.TryGetValue("SecondNumber", out object second))
            {
                int firstNumber = (int)first;
                int secondNumber = (int)second;
                output = new NeighbourBet((IPocketNumber)firstNumber, (IPocketNumber)secondNumber)
                {
                    Id = bet.Id,
                    Stake = bet.Stake,
                };
            }

            else if (info.TryGetValue("Number", out object tempNumber))
            {
                int number = (int)tempNumber;
                output = new SingleNumberBet((IPocketNumber)number)
                {
                    Id = bet.Id,
                    Stake = bet.Stake,
                };
            }
            
            return output;
        }
    }
}
