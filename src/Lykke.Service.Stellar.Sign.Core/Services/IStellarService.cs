using Lykke.Service.Stellar.Sign.Core.Domain.Stellar;

namespace Lykke.Service.Stellar.Sign.Core.Services
{
    public interface IStellarService
    {
        KeyPair GenerateKeyPair();
    }
}
