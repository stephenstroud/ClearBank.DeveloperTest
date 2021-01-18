using System;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentServiceSettings
    {
        public PaymentServiceSettings(string dataStoreType)
        {
            DataStoreType = dataStoreType?.Trim() ?? throw new ArgumentNullException(nameof(dataStoreType));
            if (DataStoreType == string.Empty)
                throw new ArgumentException("DataStoreType must be specified", nameof(dataStoreType));
        }

        public string DataStoreType { get; }
    }
}
