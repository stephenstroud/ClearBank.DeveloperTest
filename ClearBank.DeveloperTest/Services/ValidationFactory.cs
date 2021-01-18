using ClearBank.DeveloperTest.PaymentSchemeValidators;
using ClearBank.DeveloperTest.Types;
using System.Collections.Generic;

namespace ClearBank.DeveloperTest.Services
{
    public class ValidationFactory : IPaymentSchemeValidationFactory
    {
        readonly List<ValidationRule> ValidationRules = new List<ValidationRule>
        {
            new ValidationRule(PaymentScheme.Bacs, new BacsValidator()),
            new ValidationRule(PaymentScheme.FasterPayments, new FasterPaymentsValidator()),
            new ValidationRule(PaymentScheme.Chaps, new ChapsValidator())
        };
        public IPaymentSchemeValidator Lookup(PaymentScheme paymentScheme)
        {
           var rule = ValidationRules.Find(item => item.PaymentScheme == paymentScheme);
           return rule.PaymentSchemeValidator;
        }
    }
}
