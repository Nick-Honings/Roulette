namespace Roulette.Users
{
    public interface IPlayer
    {
        string Name { get; }
        IBet CurrentBet { get; }
        double Balance { get; set; }


        void MakeBet(IBet bet, double stake);
    }
}