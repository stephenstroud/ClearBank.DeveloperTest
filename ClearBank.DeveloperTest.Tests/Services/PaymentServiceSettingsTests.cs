using ClearBank.DeveloperTest.Services;
using FluentAssertions;
using System;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Services
{
    public class PaymentServiceSettingsTests
    {
        [Fact]
        public void Constructor_CalledWithNullDataStoreType_ExpectArgumentNullExceptionWithCorrectParamName()
        {
            Action constructor = () => CreateMakePaymentServiceSettingsWithDataStoreType(null);
            constructor.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("dataStoreType");
        }

        private static PaymentServiceSettings CreateMakePaymentServiceSettingsWithDataStoreType(string dataStoreType)
        {
            return new PaymentServiceSettings(dataStoreType);
        }

        [Fact]
        public void Constructor_CalledWithEmptyDataStoreType_ExpectArgumentNullExceptionWithCorrectParamName()
        {
            Action constructor = () => CreateMakePaymentServiceSettingsWithDataStoreType("");
            constructor.Should().Throw<ArgumentException>().And.ParamName.Should().Be("dataStoreType");
        }
    }
}
