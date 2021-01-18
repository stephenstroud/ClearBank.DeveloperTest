using System;

namespace ClearBank.DeveloperTest.Types
{
    public class MakePaymentRequest
    {
        public MakePaymentRequest(string creditorAccountNumber, string debtorAccountNumber, decimal amount, DateTime paymentDate, PaymentScheme paymentScheme)
        {
            CreditorAccountNumber = creditorAccountNumber?.Trim() ?? throw new ArgumentNullException(nameof(creditorAccountNumber));
            if (CreditorAccountNumber == string.Empty)
                throw new ArgumentException("CreditorAccountNumber must be specified", nameof(creditorAccountNumber));

            DebtorAccountNumber = debtorAccountNumber?.Trim() ?? throw new ArgumentNullException(nameof(debtorAccountNumber));
            if (DebtorAccountNumber == string.Empty)
                throw new ArgumentException("DebtorAccountNumber must be specified", nameof(debtorAccountNumber));

            Amount = amount;

            PaymentDate = paymentDate;

            PaymentScheme = paymentScheme;
        }
        public string CreditorAccountNumber { get; }

        public string DebtorAccountNumber { get; }

        public decimal Amount { get; }

        public DateTime PaymentDate { get; }

        public PaymentScheme PaymentScheme { get; }
    }
}
