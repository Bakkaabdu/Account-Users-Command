using Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos;
using Anis.SubcategoryFillingMechanism.Commands.Test.Fakers.UserAccess;
using Grpc.Core;

namespace Anis.SubcategoryFillingMechanism.Commands.Test.Helpers
{
    public static class MetadataHelper
    {
        public static Metadata GetMetadata(
            AccountData? accountData = null,
            UserData? userData = null,
            WalletData? walletData = null)
        {
            var claims = AccessClaimsFaker.GetAccessClaims(accountData, userData, walletData);

            var metadata = new Metadata
            {
                {"access-claims-bin",claims }
            };

            return metadata;
        }

        public static Metadata GetMetadata(byte[] claims)
        {
            var metadata = new Metadata
            {
                {"access-claims-bin",claims }
            };

            return metadata;
        }


    }
}