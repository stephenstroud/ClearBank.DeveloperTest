using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Services;
using FluentAssertions;
using System;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Services
{
    public class AccountDataStoreFactoryTests
    {
        [Fact]
        public void Constructor_CalledWithNullPaymentServiceSettings_ExpectArgumentNullExceptionWithCorrectParamName()
        {
            Action constructor = () => CreateServiceWith(null);
            constructor.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("paymentServiceSettings");
        }

        private static AccountDataStoreFactory CreateServiceWith(PaymentServiceSettings paymentServiceSettings)
        {
            return new AccountDataStoreFactory(paymentServiceSettings);
        }

        [Fact]
        public void Build_CalledWithPaymentServiceSettingsBackupStoreType_ExpectBackupAccountDataStoreReturned()
        {
            var paymentServiceSettings = PaymentServiceSettingsDoubles.StubPaymentServiceSettings("Backup");

            var service = CreateServiceWith(paymentServiceSettings);
            service
                .Invoking(x => x.Build()
                .Should().BeOfType<BackupAccountDataStore>());
        }

        [Theory]
        [InlineData("notnull")]
        [InlineData("}*&%")]
        [InlineData("00000")]
        public void Build_CalledWithPaymentServiceSettingsRandomStoreType_ExpectBackupAccountDataStoreReturned(string storeType)
        {
            var paymentServiceSettings = PaymentServiceSettingsDoubles.StubPaymentServiceSettings(storeType);

            var service = CreateServiceWith(paymentServiceSettings);
            service
                .Invoking(x => x.Build()
                .Should().BeOfType<AccountDataStore>());
        } 
    }
}
