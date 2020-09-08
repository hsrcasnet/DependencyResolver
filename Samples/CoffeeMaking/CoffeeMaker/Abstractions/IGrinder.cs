using System;
using System.Threading.Tasks;

namespace CoffeeMaker.Abstractions
{
    public interface IGrinder
    {
        Task Grind(TimeSpan duration, int granularity);
    }
}
