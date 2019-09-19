using DependencyResolver;
using PaymentProcessing.Logging;
using PaymentProcessing.PaymentMethods;

namespace PaymentProcessing.Console
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
            paymentService.Charge(99m, new MasterCard());

            System.Console.ReadLine();
        }
    }
}