using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.PaymentSchemeValidators
{
    public class FasterPaymentsValidator : IPaymentSchemeValidator
    {
        public bool IsValid(MakePaymentRequest makePaymentRequest, Account account)
              => account != null || !account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments); 
    }
}
