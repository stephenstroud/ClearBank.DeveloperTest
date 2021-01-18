using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.PaymentSchemeValidators
{
    public interface IPaymentSchemeValidationFactory
    {
        IPaymentSchemeValidator Lookup(PaymentScheme paymentScheme);
    }
}
