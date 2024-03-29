﻿using System;
using System.Threading.Tasks;
using CoffeeMaker.Abstractions;

namespace CoffeeMaker.Components
{
    public class RotationPump : IPump
    {
        public decimal FlowRate => 10m;

        public async Task<decimal> Pump(ITank tank, TimeSpan duration)
        {
            Console.WriteLine($"Pumping water for {duration}...");

            var drainedVolume = 0m;
            for (var i = 0; i < duration.TotalSeconds; i++)
            {
                await Task.Delay(1000);
                drainedVolume += tank.Drain(this.FlowRate);
                Console.Write(".");
            }

            Console.WriteLine();
            Console.WriteLine($"Pumping finished with volume={drainedVolume} (tank.CurrentVolume={tank.CurrentVolume})");
            return drainedVolume;
        }
    }
}
