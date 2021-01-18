using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.PaymentSchemeValidators
{
    public interface IPaymentSchemeValidator
    {
        bool IsValid(MakePaymentRequest makePaymentRequest, Account account);
    }
}
