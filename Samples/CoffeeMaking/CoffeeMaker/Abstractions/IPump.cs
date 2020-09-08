using System;
using System.Threading.Tasks;

namespace CoffeeMaker.Abstractions
{
    public interface IPump
    {
        decimal FlowRate { get; }

        Task<decimal> Pump(ITank tank, IHeater heater, TimeSpan duration);
    }
}
