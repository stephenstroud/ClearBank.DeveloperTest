using ClearBank.DeveloperTest.Types;
using System;

namespace ClearBank.DeveloperTest.Services
{
    public class ActionPayment : IActionPayment
    {
        private readonly IAccountDataStoreFactory _accountDataStoreFactory;
        private readonly IPaymentSchemeValidationService _paymentSchemeValidationFactory;
        public ActionPayment(IAccountDataStoreFactory accountDataStoreFactory,
            IPaymentSchemeValidationService paymentSchemeValidationFactory)
        {
            _accountDataStoreFactory = accountDataStoreFactory ?? throw new ArgumentNullException(nameof(accountDataStoreFactory));
            _paymentSchemeValidationFactory = paymentSchemeValidationFactory ?? throw new ArgumentNullException(nameof(paymentSchemeValidationFactory));
        }
        public MakePaymentResult TryMakePayment(MakePaymentRequest makePaymentRequest)
        {
            var accountDataStore = _accountDataStoreFactory.Build();
            var account = accountDataStore.GetAccount(makePaymentRequest.DebtorAccountNumber);

            if (_paymentSchemeValidationFactory.ValidateAccount(makePaymentRequest, account))
            {
                account.Balance -= makePaymentRequest.Amount;
                accountDataStore.UpdateAccount(account);

                return new MakePaymentResult(true);
            }
            return new MakePaymentResult(false);
        }
    }
}
