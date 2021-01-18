using ClearBank.DeveloperTest.PaymentSchemeValidators;
using ClearBank.DeveloperTest.Types;
using System;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentSchemeValidationService : IPaymentSchemeValidationService
    {
        private readonly IPaymentSchemeValidationFactory PaymentSchemeValidationFactory;
        public PaymentSchemeValidationService(IPaymentSchemeValidationFactory paymentSchemeValidationFactory)
        {
            PaymentSchemeValidationFactory = paymentSchemeValidationFactory ?? throw new ArgumentNullException(nameof(paymentSchemeValidationFactory));
        }

        public bool ValidateAccount(MakePaymentRequest makePaymentRequest, Account account)
        {
            var validator = PaymentSchemeValidationFactory.Lookup(makePaymentRequest.PaymentScheme);

            return validator.IsValid(makePaymentRequest, account);
        }
    }
}
