using DependencyResolver;
using PaymentProcessing;
using PaymentProcessing.Logging;
using PaymentProcessing.PaymentMethods;
using System;

namespace PaymentProcessor.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new Dependency Injection Container
            var resolver = new Resolver();

            // Register dependencies
            resolver.Register<ILogger, ConsoleLogger>();
            resolver.Register<IPaymentService, PaymentService>();
            resolver.Register<IPaymentServiceConfiguration, PaymentServiceConfiguration>();

            // Resolve dependencies
            var paymentService = resolver.Resolve<IPaymentService>();
            paymentService.Charge(88m, new MasterCard());
            paymentService.Charge(99m, new Visa());

            Console.ReadLine();
        }
    }
}