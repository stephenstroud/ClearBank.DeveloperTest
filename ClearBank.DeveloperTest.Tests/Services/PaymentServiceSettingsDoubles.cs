using ClearBank.DeveloperTest.Services;
using NSubstitute;

namespace ClearBank.DeveloperTest.Tests.Services
{
    public class PaymentServiceSettingsDoubles
    {
        public static PaymentServiceSettings StubPaymentServiceSettings(string dataStoreType)
        {
            return Substitute.For<PaymentServiceSettings>(dataStoreType);
        }
    }
}
