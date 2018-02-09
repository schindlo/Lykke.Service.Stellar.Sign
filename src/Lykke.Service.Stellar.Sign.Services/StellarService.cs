using System;
using StellarBase;
using StellarBase.Generated;
using Lykke.Service.Stellar.Sign.Core.Services;

namespace Lykke.Service.Stellar.Sign.Services
{
    public class StellarService: IStellarService
    {
        public StellarService(string network)
        {
            Network.CurrentNetwork = network;
        }

        public Core.Domain.Stellar.KeyPair GenerateKeyPair()
        {
            var keyPair = KeyPair.Random();
            return new Core.Domain.Stellar.KeyPair
            {
                Seed = keyPair.Seed,
                Address = keyPair.Address
            };
        }

        public string SignTransaction(string[] seeds, string xdrBase64)
        {
            var xdr = Convert.FromBase64String(xdrBase64);

            var reader = new ByteReader(xdr);
            var tx = StellarBase.Generated.Transaction.Decode(reader);
            var txHash = GetTransactionHash(tx);

            var signer = KeyPair.FromSeed(seeds[0]);
            var signature = signer.SignDecorated(txHash);

            var signedTx = CreateEnvelopeXdrBase64(tx, signature);
            return signedTx;
        }

        private byte[] GetTransactionHash(StellarBase.Generated.Transaction tx)
        {
            var writer = new ByteWriter();

            // Hashed NetworkID
            writer.Write(Network.CurrentNetworkId);

            // Envelope Type - 4 bytes
            EnvelopeType.Encode(writer, EnvelopeType.Create(EnvelopeType.EnvelopeTypeEnum.ENVELOPE_TYPE_TX));

            // Transaction XDR bytes
            var txWriter = new ByteWriter();
            StellarBase.Generated.Transaction.Encode(txWriter, tx);
            writer.Write(txWriter.ToArray());

            var data = writer.ToArray();
            return StellarBase.Utilities.Hash(data);
        }

        private string CreateEnvelopeXdrBase64(StellarBase.Generated.Transaction tx, DecoratedSignature signature)
        {
            var txEnvelope = new TransactionEnvelope
            {
                Tx = tx,
                Signatures = new [] { signature }
            };

            var writer = new ByteWriter();
            TransactionEnvelope.Encode(writer, txEnvelope);
            var data = writer.ToArray();
            return Convert.ToBase64String(data);
        }
    }
}
