using System;
using CoffeeMaker.Abstractions;

namespace CoffeeMaker.Components
{
    public class WaterTank : ITank
    {
        public WaterTank(decimal capacity)
        {
            this.Capacity = capacity;
            this.CurrentVolume = 0m;
        }

        public decimal Capacity { get; private set; }

        public decimal CurrentVolume { get; private set; }

        public void Fill(decimal volume)
        {
            if (this.CurrentVolume + volume > this.Capacity)
            {
                throw new ArgumentException($"Tank is too small to fill volume {volume}");
            }

            this.CurrentVolume = volume;
        }

        public decimal Drain(decimal volume)
        {
            if (volume < 0m)
            {
                throw new ArgumentException("Can only drain positive amount");
            }

            var diff = this.CurrentVolume - volume;
            if (diff < 0m)
            {
                throw new ArgumentException($"Remaining capacity is too low to drain {volume}");
            }

            this.CurrentVolume -= volume;

            return volume;
        }
    }
}
