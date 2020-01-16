using Roulette.Users;

namespace Roulette.BattleStructure
{
    public interface IBattle
    {
        int Player1Id { get; }
        int Player2Id { get; }
        double ProfitGoal { get; set; }

        void SetTimePeriod(int time);
        void StartBattle();
    }
}