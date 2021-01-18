using ClearBank.DeveloperTest.Types;
using FluentAssertions;
using Lophtware.Testing.Utilities.NonDeterminism.PrimitiveGeneration;
using System;
using Xunit;

namespace ClearBank.DeveloperTest.Tests.Types
{
    public class MakePaymentRequestTests
    {
        [Fact]
        public void Constructor_CalledWithNullCreditorAccountNumber_ExpectArgumentNullExceptionWithCorrectParamName()
        {
            Action constructor = () => CreateMakePaymentRequestWithCreditorAccountNumber(null);
            constructor.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("creditorAccountNumber");
        }

        private static MakePaymentRequest CreateMakePaymentRequestWithCreditorAccountNumber(string creditorAccountNumber)
        {
            return new MakePaymentRequest(creditorAccountNumber, AnyDebtorAccountNumber(), AnyAmount(), DateTime.MinValue, PaymentScheme.Bacs);
        }

        [Fact]
        public void Constructor_CalledWithEmptyCreditorAccountNumber_ExpectArgumentNullExceptionWithCorrectParamName()
        {
            Action constructor = () => CreateMakePaymentRequestWithCreditorAccountNumber("");
            constructor.Should().Throw<ArgumentException>().And.ParamName.Should().Be("creditorAccountNumber");
        }

        [Fact]
        public void Constructor_CalledWithNullDebtorAccountNumber_ExpectArgumentNullExceptionWithCorrectParamName()
        {
            Action constructor = () => CreateMakePaymentRequestWithDebtorAccountNumber(null);
            constructor.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("debtorAccountNumber");
        }

        private static MakePaymentRequest CreateMakePaymentRequestWithDebtorAccountNumber(string debtorAccountNumber)
        {
            return new MakePaymentRequest(AnyCreditorAccountNumber(), debtorAccountNumber, AnyAmount(), DateTime.MinValue, PaymentScheme.Bacs);
        }

        [Fact]
        public void Constructor_CalledWithEmptyDebtorAccountNumber_ExpectArgumentNullExceptionWithCorrectParamName()
        {
            Action constructor = () => CreateMakePaymentRequestWithDebtorAccountNumber("");
            constructor.Should().Throw<ArgumentException>().And.ParamName.Should().Be("debtorAccountNumber");
        }

        private static string AnyDebtorAccountNumber()
        {
            return StringGenerator.AnyNonNullNonWhitespaceNonEmpty();
        }

        private static string AnyCreditorAccountNumber()
        {
            return StringGenerator.AnyNonNullNonWhitespaceNonEmpty();
        }

        private static decimal AnyAmount()
        {
            return LongGenerator.Any();
        }
    }
}
