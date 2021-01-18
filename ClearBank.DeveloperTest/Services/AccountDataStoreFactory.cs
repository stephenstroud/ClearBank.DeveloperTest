using ClearBank.DeveloperTest.Data;
using System;

namespace ClearBank.DeveloperTest.Services
{
    public class AccountDataStoreFactory : IAccountDataStoreFactory
    {
        private readonly PaymentServiceSettings _paymentServiceSettings;
        public AccountDataStoreFactory(PaymentServiceSettings paymentServiceSettings)
        {
            _paymentServiceSettings = paymentServiceSettings ?? throw new ArgumentNullException(nameof(paymentServiceSettings));
        }
        public IAccountDataStore Build()
        {
            if (_paymentServiceSettings.DataStoreType == "Backup")            
                return new BackupAccountDataStore();            
         
             return new AccountDataStore();     
        }
    }
}
