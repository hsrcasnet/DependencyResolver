using CoffeeMaker.Abstractions;
using System;
using System.Threading.Tasks;

namespace CoffeeMaker
{
    public class CoffeeMachine : ICoffeeMachine
    {
        private readonly IPump pump;
        private readonly ITank tank;
        private readonly IHeater heater;
        private readonly IGrinder grinder;

        public CoffeeMachine(IGrinder grinder, IHeater heater, IPump pump, ITank tank)
        {
            this.grinder = grinder;
            this.heater = heater;
            this.pump = pump;
            this.tank = tank;
        }

        public void FillWater(int volume)
        {
            this.tank.Fill(volume);
        }

        public async Task<ICoffee> GetEspresso()
        {
            await grinder.Grind(TimeSpan.FromMilliseconds(4400), 2);

            var totalVolume = await pump.Pump(this.tank, this.heater, TimeSpan.FromSeconds(24));

            return new Espresso(totalVolume);
        }
    }
}
