using ClearBank.DeveloperTest.Services;
using NSubstitute;

namespace ClearBank.DeveloperTest.Tests.Services
{
    public class ActionPaymentDouble
    {
        public static IActionPayment StubActionPayment()
        {
            return Substitute.For<IActionPayment>();
        }
    }
}
