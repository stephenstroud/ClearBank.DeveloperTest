using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public interface IPaymentSchemeValidationService
    {
        bool ValidateAccount(MakePaymentRequest makePaymentRequest, Account account);
    }
}
