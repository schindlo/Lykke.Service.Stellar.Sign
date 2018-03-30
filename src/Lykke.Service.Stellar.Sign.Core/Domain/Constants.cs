using System;

namespace Lykke.Service.Stellar.Sign.Core.Domain
{
    public class Constants
    {
        public static Version ContractVersion = new Version("1.1.0");

        public const string NoPrivateKey = "NO_PK";

        public class PublicAddressExtension
        {
            public const char Separator = '$';
        }
    }
}
