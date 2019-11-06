using Roulette.Users;

namespace Roulette.BattleStructure
{
    public interface IBattle
    {
        IUser Player1 { get; }
        IUser Player2 { get; }
        double ProfitGoal { get; set; }

        void SetTimePeriod(int time);
        void StartBattle();
    }
}