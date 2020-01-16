using InterfaceLayerBD.Bet;

namespace Roulette.GameStructure
{
    public interface IPocket
    {
        IPocketColor Color { get; }
        bool Even { get; }
        IPocketNumber Number { get; }
    }
}