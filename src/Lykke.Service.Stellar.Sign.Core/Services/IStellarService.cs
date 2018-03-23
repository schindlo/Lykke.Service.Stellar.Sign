using Lykke.Service.Stellar.Sign.Core.Domain.Stellar;

namespace Lykke.Service.Stellar.Sign.Core.Services
{
    public interface IStellarService
    {
        string GetDepositBaseAddress();

        KeyPair GenerateKeyPair();

        string GenerateRandomMemoText();

        string SignTransaction(string[] seeds, string xdrBase64);
    }
}
