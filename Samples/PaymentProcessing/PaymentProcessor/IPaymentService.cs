using PaymentProcessing.PaymentMethods;

namespace PaymentProcessing
{
    public interface IPaymentService
    {
        void Charge(decimal amount, IPaymentMethod paymentMethod);
    }
}