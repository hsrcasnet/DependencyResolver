using System.Configuration;

namespace PaymentProcessing
{
    public class PaymentServiceConfiguration : IPaymentServiceConfiguration
    {
        public PaymentServiceConfiguration()
        {
        }

        public string ApiKey
        {
            get { return ConfigurationManager.AppSettings["ApiKey"]; }
        }
    }
}