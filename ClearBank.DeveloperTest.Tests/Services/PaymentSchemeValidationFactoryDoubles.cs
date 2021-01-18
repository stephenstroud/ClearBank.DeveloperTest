using ClearBank.DeveloperTest.PaymentSchemeValidators;
using NSubstitute;

namespace ClearBank.DeveloperTest.Tests.Services
{
    public class PaymentSchemeValidationFactoryDoubles
    {
        public static IPaymentSchemeValidationFactory StubPaymentSchemeValidationService()
        {
            return Substitute.For<IPaymentSchemeValidationFactory>();
        }
    }
}
