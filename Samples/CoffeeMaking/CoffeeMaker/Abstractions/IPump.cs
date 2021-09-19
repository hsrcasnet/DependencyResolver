using System;
using System.Threading.Tasks;

namespace CoffeeMaker.Abstractions
{
    public interface IPump
    {
        decimal FlowRate { get; }

        Task<decimal> Pump(ITank tank, TimeSpan duration);
    }
}
