using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using FluentAssertions;
using System;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Services
{
    public class PaymentServiceTests
    {
        [Fact]
        public void Constructor_CalledWithNullAccountDataStoreFactory_ExpectArgumentNullExceptionWithCorrectParamName()
        {
            Action constructor = () => CreateServiceWith(null);
            constructor.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("actionPayment");
        }

        private static PaymentService CreateServiceWith(IActionPayment actionPayment)
        {
            return new PaymentService(actionPayment);
        }

        [Fact]
        public void MakePayment_CalledWithNullMakePaymentRequest_ExpectArgumentNullExceptionWithCorrectParamName()
        {
            var paymentServiceSettings = ActionPaymentDouble.StubActionPayment();

            var service = CreateServiceWith(paymentServiceSettings);
            service
                .Invoking(x => x.MakePayment(null))
                .Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("makePaymentRequest");
        }

        [Fact]
        public void ShouldReturnMakePaymentResultWithMakePaymentRequest()
        {
            var paymentServiceSettings = ActionPaymentDouble.StubActionPayment();

            var service = CreateServiceWith(paymentServiceSettings);
            service
                .Invoking(x => x.MakePayment(new MakePaymentRequest("123", "123", 100, DateTime.UtcNow, PaymentScheme.Bacs))
                .Should().BeOfType<MakePaymentResult>());
        }
    }
}
