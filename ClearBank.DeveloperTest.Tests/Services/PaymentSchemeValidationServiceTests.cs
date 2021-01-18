using ClearBank.DeveloperTest.PaymentSchemeValidators;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using FluentAssertions;
using System;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Services
{
    public class PaymentSchemeValidationServiceTests
    {
        [Fact]
        public void Constructor_CalledWithNullPaymentSchemeValidationService_ExpectArgumentNullExceptionWithCorrectParamName()
        {
            Action constructor = () => CreateServiceWith(null);
            constructor.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("paymentSchemeValidationFactory");
        }

        private static PaymentSchemeValidationService CreateServiceWith(IPaymentSchemeValidationFactory paymentSchemeValidationFactory)
        {
            return new PaymentSchemeValidationService(paymentSchemeValidationFactory);
        }

        [Fact]
        public void ShouldReturnTryMakePaymentResultWithValidMakePaymentRequest()
        {
            var accountDataStoreFactory = PaymentSchemeValidationFactoryDoubles.StubPaymentSchemeValidationService();

            var service = CreateServiceWith(accountDataStoreFactory);
            service
                .Invoking(x => x.ValidateAccount(new MakePaymentRequest("123", "123", 100, DateTime.UtcNow, PaymentScheme.Bacs),
                             new Account() { AccountNumber = "123", AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs, Balance = 100, Status = AccountStatus.Live })
                .Should().BeTrue());
        }
    }
}
