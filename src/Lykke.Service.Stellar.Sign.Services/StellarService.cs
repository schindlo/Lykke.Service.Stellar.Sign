using System;
using StellarBase = Stellar;
using StellarGenerated = Stellar.Generated;
using Lykke.Service.Stellar.Sign.Core.Domain.Stellar;
using Lykke.Service.Stellar.Sign.Core.Services;

namespace Lykke.Service.Stellar.Sign.Services
{
    public class StellarService: IStellarService
    {
        public StellarService()
        {
            StellarBase.Network.CurrentNetwork = "Test SDF Network ; September 2015";
        }

        public KeyPair GenerateKeyPair()
        {
            var keyPair = StellarBase.KeyPair.Random();
            return new KeyPair
            {
                Seed = keyPair.Seed,
                Address = keyPair.Address
            };
        }

        public string SignTransaction(string[] seeds, string xdrBase64)
        {
            var xdr = Convert.FromBase64String(xdrBase64);

            var reader = new StellarGenerated.ByteReader(xdr);
            var tx = StellarGenerated.Transaction.Decode(reader);
            var txHash = GetTransactionHash(tx);

            var signer = StellarBase.KeyPair.FromSeed(seeds[0]);
            var signature = signer.SignDecorated(txHash);

            var signedTx = CreateEnvelopeXdrBase64(tx, signature);
            return signedTx;
        }

        private byte[] GetTransactionHash(StellarGenerated.Transaction tx)
        {
            var writer = new StellarGenerated.ByteWriter();

            // Hashed NetworkID
            writer.Write(StellarBase.Network.CurrentNetworkId);

            // Envelope Type - 4 bytes
            StellarGenerated.EnvelopeType.Encode(writer, StellarGenerated.EnvelopeType.Create(StellarGenerated.EnvelopeType.EnvelopeTypeEnum.ENVELOPE_TYPE_TX));

            // Transaction XDR bytes
            var txWriter = new StellarGenerated.ByteWriter();
            StellarGenerated.Transaction.Encode(txWriter, tx);
            writer.Write(txWriter.ToArray());

            var data = writer.ToArray();
            return StellarBase.Utilities.Hash(data);
        }

        private string CreateEnvelopeXdrBase64(StellarGenerated.Transaction tx, StellarGenerated.DecoratedSignature signature)
        {
            var txEnvelope = new StellarGenerated.TransactionEnvelope
            {
                Tx = tx,
                Signatures = new [] { signature }
            };

            var writer = new StellarGenerated.ByteWriter();
            StellarGenerated.TransactionEnvelope.Encode(writer, txEnvelope);
            var data = writer.ToArray();
            return Convert.ToBase64String(data);
        }
    }
}
