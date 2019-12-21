namespace Roulette.Users
{
    public interface IPlayer
    {
        string Name { get; }
        IBet CurrentBet { get; }
        decimal Balance { get; set; }


        void MakeBet(IBet bet, decimal stake);
    }
}