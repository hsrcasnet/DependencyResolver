namespace CoffeeMaker.Abstractions
{
    public interface ITank
    {
        decimal Capacity { get; }

        decimal CurrentVolume { get; }

        void Fill(decimal volume);

        decimal Drain(decimal volume);
    }
}