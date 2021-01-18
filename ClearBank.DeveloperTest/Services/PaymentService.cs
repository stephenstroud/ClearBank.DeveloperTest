using ClearBank.DeveloperTest.Types;
using System;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IActionPayment _actionPayment;
        public PaymentService(IActionPayment actionPayment)
        {
            _actionPayment = actionPayment ?? throw new ArgumentNullException(nameof(actionPayment));
        }

        public MakePaymentResult MakePayment(MakePaymentRequest makePaymentRequest)
        {
            if(makePaymentRequest == null)
                throw new ArgumentNullException(nameof(makePaymentRequest));

            return _actionPayment.TryMakePayment(makePaymentRequest);
        }
    }
}