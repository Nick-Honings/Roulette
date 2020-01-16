using Roulette.Bets;

namespace Roulette.Users
{
    public interface IPlayer
    {
        int Id { get; set; }
        string Name { get; }
        IBet CurrentBet { get; }
        decimal Balance { get; set; }
        bool UpdateBalance(decimal balance);
        bool MakeBet(IBet bet);
        void StartBattle(int playerId);
    }
}