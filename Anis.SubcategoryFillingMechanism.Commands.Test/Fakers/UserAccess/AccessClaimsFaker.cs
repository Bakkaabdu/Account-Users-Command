using Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos;
using Bogus;
using Google.Protobuf;
using Google.Protobuf.Collections;

namespace Anis.SubcategoryFillingMechanism.Commands.Test.Fakers.UserAccess
{
    public class AccessClaimsFaker : Faker<AccessClaims>
    {
        public AccessClaimsFaker(
            AccountData? accountData = null,
            UserData? userData = null,
            WalletData? walletData = null)
        {
            RuleFor(r => r.Account, accountData ?? new AccountDataFaker().Generate());
            RuleFor(r => r.User, userData ?? new UserDataFaker().Generate());
            RuleFor(r => r.Wallet, walletData ?? new WalletDataFaker().Generate());
        }
        public static byte[] GetAccessClaims(
            AccountData? accountData = null,
            UserData? userData = null,
            WalletData? walletData = null)
        {
            var cliams = new AccessClaimsFaker(accountData, userData, walletData).Generate();

            return cliams.ToByteArray();
        }
    }

    public class AccountDataFaker : Faker<AccountData>
    {
        public AccountDataFaker()
        {
            RuleFor(r => r.Id, f => f.Random.Guid().ToString());
            RuleFor(r => r.LocationId, f => f.Random.Guid().ToString());
            RuleFor(r => r.SubscriptionId, f => f.Random.Guid().ToString());
            RuleFor(r => r.SubscriptionType, f => f.PickRandom<SubscriptionType>());
        }

        public AccountDataFaker(Guid? id = null, Guid? locationId = null, SubscriptionType? subscriptionType = null)
        {
            RuleFor(r => r.Id, id.HasValue ? id.ToString() : Guid.NewGuid().ToString());
            RuleFor(r => r.LocationId, locationId.HasValue ? locationId.ToString() : Guid.NewGuid().ToString());
            RuleFor(r => r.SubscriptionId, f => f.Random.Guid().ToString());
            RuleFor(r => r.SubscriptionType, subscriptionType.HasValue ? subscriptionType : SubscriptionType.Personal);
        }
    }

    public class UserDataFaker : Faker<UserData>
    {
        public UserDataFaker()
        {

            RuleFor(r => r.Id, f => f.Random.Guid().ToString());
            RuleFor(r => r.ScopId, f => f.Random.Guid().ToString());
            RuleFor(r => r.Role, f => f.PickRandom<UserRole>());
            RuleFor(r => r.Permissions, new RepeatedField<UserPermission> { UserPermission.AllMyCards });
        }
    }

    public class WalletDataFaker : Faker<WalletData>
    {
        public WalletDataFaker(Guid? regionId = null)
        {
            RuleFor(r => r.Id, f => f.Random.Guid().ToString());
            RuleFor(r => r.RegionId, regionId.HasValue ? regionId.ToString() : Guid.NewGuid().ToString());
        }
    }
}