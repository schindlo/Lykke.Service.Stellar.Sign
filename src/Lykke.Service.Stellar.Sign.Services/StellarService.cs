using System;
using Lykke.Service.Stellar.Sign.Core.Domain.Stellar;
using Lykke.Service.Stellar.Sign.Core.Services;

namespace Lykke.Service.Stellar.Sign.Services
{
    public class StellarService: IStellarService
    {
        public KeyPair GenerateKeyPair()
        {
            return new KeyPair
            {
                Seed = "seed",
                Address = "address"
            };
        }
    }
}
