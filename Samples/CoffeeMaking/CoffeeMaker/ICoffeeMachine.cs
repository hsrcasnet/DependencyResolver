using System.Threading.Tasks;

namespace CoffeeMaker
{
    public interface ICoffeeMachine
    {
        Task<ICoffee> GetEspresso();

        void FillWater(int volume);
    }
}
