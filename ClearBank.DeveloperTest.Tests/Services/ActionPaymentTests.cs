using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using FluentAssertions;
using System;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Services
{
    public class ActionPaymentTests
    {
        [Fact]
        public void Constructor_CalledWithNullAccountDataStoreFactory_ExpectArgumentNullExceptionWithCorrectParamName()
        {
            Action constructor = () => CreateServiceWith((IAccountDataStoreFactory)null);
            constructor.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("accountDataStoreFactory");
        }

        private static ActionPayment CreateServiceWith(IAccountDataStoreFactory accountDataStoreFactory)
        {
            return new ActionPayment(accountDataStoreFactory, PaymentSchemeValidationServiceDouble.Dummy());
        }

        [Fact]
        public void Constructor_CalledWithNullPaymentSchemeValidationFactory_ExpectArgumentNullExceptionWithCorrectParamName()
        {
            Action constructor = () => CreateServiceWith((IPaymentSchemeValidationService)null);
            constructor.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("paymentSchemeValidationFactory");
        }

        private static ActionPayment CreateServiceWith(IPaymentSchemeValidationService paymentSchemeValidationService)
        {
            return new ActionPayment(AccountDataStoreFactoryDoubles.Dummy(), paymentSchemeValidationService);
        }

        [Fact]
        public void ShouldReturnTryMakePaymentResultWithValidMakePaymentRequest()
        {
            var paymentServiceSettings = ActionPaymentDouble.StubActionPayment();

            var service = CreateServiceWith(AccountDataStoreFactoryDoubles.StubAccountDataStoreFactory(), PaymentSchemeValidationServiceDouble.StubPaymentSchemeValidationService());
            service
                .Invoking(x => x.TryMakePayment(new MakePaymentRequest("123", "123", 100, DateTime.UtcNow, PaymentScheme.Bacs))
                .Should().BeOfType<MakePaymentResult>());
        }

        private static ActionPayment CreateServiceWith(IAccountDataStoreFactory accountDataStoreFactory, IPaymentSchemeValidationService paymentSchemeValidationService)
        {
            return new ActionPayment(accountDataStoreFactory, paymentSchemeValidationService);
        }
    }
}
