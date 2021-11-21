using System;
using System.Threading.Tasks;
using CoffeeMaker.Abstractions;

namespace CoffeeMaker
{
    public class CoffeeMachine : ICoffeeMachine
    {
        private const float temperature = 94f;

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
            await this.grinder.Grind(TimeSpan.FromMilliseconds(4400), 2);

            var totalVolume = await this.pump.Pump(this.tank, TimeSpan.FromSeconds(24));

            await this.heater.Heat(totalVolume, temperature);

            return new Espresso(totalVolume);
        }
    }
}
