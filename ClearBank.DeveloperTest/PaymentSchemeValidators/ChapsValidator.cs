using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.PaymentSchemeValidators
{
    public class ChapsValidator : IPaymentSchemeValidator
    {
        public bool IsValid(MakePaymentRequest makePaymentRequest, Account account)
        {
           return account != null ||
                !account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps) ||
                account.Status != AccountStatus.Live;
        }
      
    }
}
