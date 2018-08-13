using System;

namespace Lykk.Service.Stellar.KeyGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var stellarPrivateKeyPair = StellarBase.KeyPair.Random();
            Console.WriteLine($"Seed(PrivateKey): {stellarPrivateKeyPair.Seed}");
            Console.WriteLine($"Address(PublicAddress): {stellarPrivateKeyPair.Address}");
            Console.ReadLine();
        }
    }
}
