using InterfaceLayerBD.Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.BattleStructure
{
    public class BattleContainer
    {
        private readonly IBattleContainerDAL _containerDAL;
        private readonly IBattleDAL _battleDAL;

        public List<Battle> Battles { get; private set; }

        public BattleContainer(IBattleContainerDAL containerDAL, IBattleDAL battleDAL)
        {
            Battles = new List<Battle>();
            this._containerDAL = containerDAL;
            this._battleDAL = battleDAL;
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

        public void UpdateUserBalance()
        {
            throw new NotImplementedException();
        }

    }
}
