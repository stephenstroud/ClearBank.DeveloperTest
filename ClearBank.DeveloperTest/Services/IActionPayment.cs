using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public interface IActionPayment
    {
        MakePaymentResult TryMakePayment(MakePaymentRequest makePaymentRequest);
    }
}
