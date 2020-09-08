using System.Threading.Tasks;

namespace CoffeeMaker.Components
{
    public class Heater : IHeater
    {
        public async Task Heat(decimal volume, float temperature)
        {
            await Task.Delay(1000);
        }
    }
}
