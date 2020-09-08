namespace CoffeeMaker
{
    public class Espresso : ICoffee
    {
        internal Espresso(decimal totalVolume)
        {
            this.Volume = totalVolume;
        }

        public decimal Volume { get; }
    }
}
