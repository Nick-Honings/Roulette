using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.BattleStructure
{
    public class BattleContainer
    {
        public List<Battle> Battles { get; private set; }

        public BattleContainer()
        {
            Battles = new List<Battle>();
        }


        public void AddBattle(Battle battle)
        {
            if (battle != null)
            {
                foreach (Battle b in Battles)
                {
                    if (b.Id == battle.Id)
                    {
                        return;
                    }
                }
                Battles.Add(battle);
            }
        }

        public void RemoveBattle(Battle battle)
        {
            if (battle != null)
            {
                Battles.Remove(battle); 
            }
        }

    }
}
