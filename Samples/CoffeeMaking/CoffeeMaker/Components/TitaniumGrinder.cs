using System;
using System.Threading.Tasks;
using CoffeeMaker.Abstractions;

namespace CoffeeMaker
{
    public class TitaniumGrinder : IGrinder
    {
        public async Task Grind(TimeSpan duration, int granularity)
        {
            Console.WriteLine($"Grinding with granularity={granularity}...");

            await Task.Delay(duration);

            Console.WriteLine($"Grinding finished after {duration}");
        }
    }
}
