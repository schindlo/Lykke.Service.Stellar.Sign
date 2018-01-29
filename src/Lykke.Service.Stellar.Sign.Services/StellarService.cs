using System;
using StellarBaseKeyPair = Stellar.KeyPair;
using Lykke.Service.Stellar.Sign.Core.Domain.Stellar;
using Lykke.Service.Stellar.Sign.Core.Services;

namespace Lykke.Service.Stellar.Sign.Services
{
    public class StellarService: IStellarService
    {
        public KeyPair GenerateKeyPair()
        {
            var keyPair = StellarBaseKeyPair.Random();
            return new KeyPair
            {
                Seed = keyPair.Seed,
                Address = keyPair.Address
            };
        }
    }
}
