using System.Threading.Tasks;

namespace CoffeeMaker
{
    public interface IHeater
    {
        Task Heat(decimal liquid, float temperature);
    }
}