using System;
using System.Threading.Tasks;
using CoffeeMaker.Abstractions;
using CoffeeMaker.Components;
using DependencyResolver;

namespace CoffeeMaker.ConsoleApp
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            // Create a new Dependency Injection Container
            var resolver = new Resolver();

            // Register dependencies
            resolver.Register<IGrinder, TitaniumGrinder>();
            resolver.Register<IHeater, Heater>();
            resolver.Register<IPump, RotationPump>();
            resolver.Register<ITank, WaterTank3L>();
            resolver.Register<ICoffeeMachine, CoffeeMachine>();

            // Resolve dependencies
            var coffeeMachine = resolver.Resolve<ICoffeeMachine>();
            coffeeMachine.FillWater(300);

            var numberOfEspressos = 10;
            for (var i = 1; i <= numberOfEspressos; i++)
            {
                Console.WriteLine($"Starting espresso #{i}...");

                var espresso = await coffeeMachine.GetEspresso();

                Console.WriteLine($"Finished espresso #{i} with volume={espresso.Volume}");
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
