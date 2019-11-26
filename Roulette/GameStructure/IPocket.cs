namespace Roulette.GameStructure
{
    public interface IPocket
    {
        PocketColor Color { get; }
        bool Even { get; }
        PocketNumber Number { get; }
    }
}