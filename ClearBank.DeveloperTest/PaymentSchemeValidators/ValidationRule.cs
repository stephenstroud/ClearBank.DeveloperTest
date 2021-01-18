using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.PaymentSchemeValidators
{
    public class ValidationRule
    {
        public ValidationRule(PaymentScheme paymentScheme, IPaymentSchemeValidator paymentSchemeValidator)
        {
            PaymentScheme = paymentScheme;
            PaymentSchemeValidator = paymentSchemeValidator;
        }

        public PaymentScheme PaymentScheme { get; }
        public IPaymentSchemeValidator PaymentSchemeValidator { get; }
    }
} 
