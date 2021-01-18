using ClearBank.DeveloperTest.Services;
using NSubstitute;

namespace ClearBank.DeveloperTest.Tests.Services
{
    public class PaymentSchemeValidationServiceDouble
    {
        public static IPaymentSchemeValidationService StubPaymentSchemeValidationService()
        {
            return Substitute.For<IPaymentSchemeValidationService>();
        }

        public static IPaymentSchemeValidationService Dummy()
        {
            return Substitute.For<IPaymentSchemeValidationService>();
        }
    }
}
