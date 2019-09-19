using PaymentProcessing.Logging;
using PaymentProcessing.PaymentMethods;

namespace PaymentProcessing
{
    public class PaymentService : IPaymentService
    {
        private readonly ILogger logger;
        private readonly IPaymentServiceConfiguration paymentServiceConfiguration;

        public PaymentService(ILogger logger, IPaymentServiceConfiguration paymentServiceConfiguration)
        {
            this.logger = logger;
            this.paymentServiceConfiguration = paymentServiceConfiguration;
        }

        public void Charge(decimal amount, IPaymentMethod paymentMethod)
        {
            this.logger.Log($"Charging {amount:F2} using paymentMethod={paymentMethod.GetType().Name} and apikey={this.paymentServiceConfiguration.ApiKey}");
        }
    }
}