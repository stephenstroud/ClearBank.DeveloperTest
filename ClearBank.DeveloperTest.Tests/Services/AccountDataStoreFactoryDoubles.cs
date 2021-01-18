using ClearBank.DeveloperTest.Services;
using NSubstitute;

namespace ClearBank.DeveloperTest.Tests.Services
{
    public class AccountDataStoreFactoryDoubles
    {
        public static IAccountDataStoreFactory StubAccountDataStoreFactory()
        {
            return Substitute.For<IAccountDataStoreFactory>();
        }

        public static IAccountDataStoreFactory Dummy()
        {
            return Substitute.For<IAccountDataStoreFactory>();
        }
    }
}
