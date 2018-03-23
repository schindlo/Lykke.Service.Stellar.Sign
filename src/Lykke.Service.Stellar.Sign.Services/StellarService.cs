using System;
using StellarBase;
using StellarBase.Generated;
using Lykke.Service.Stellar.Sign.Core.Services;
using Lykke.Service.Stellar.Sign.Core.Encoding;
using Lykke.Service.Stellar.Sign.Core.Domain;
using System.Text;

namespace Lykke.Service.Stellar.Sign.Services
{
    public class StellarService : IStellarService
    {
        private string _depositBaseAddress;

        public StellarService(string network, string depositBaseAddress)
        {
            Network.CurrentNetwork = network;
            _depositBaseAddress = depositBaseAddress;
        }

        public string GetDepositBaseAddress()
        {
            return _depositBaseAddress;
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

        public string GenerateRandomMemoText()
        {
            byte[] guid = Guid.NewGuid().ToByteArray();
            string memoText = Base3264Encoding.ToZBase32(guid);
            return memoText;
        }

        public string SignTransaction(string[] seeds, string xdrBase64)
        {
            byte[] xdr;
            try
            {
                xdr = Convert.FromBase64String(xdrBase64);
            }
            catch (FormatException ex)
            {
                throw new ArgumentException("Invalid base64 encoded transaction XDR", nameof(xdrBase64), ex);
            }

            var reader = new ByteReader(xdr);
            var tx = StellarBase.Generated.Transaction.Decode(reader);
            var txHash = GetTransactionHash(tx);

            var seed = seeds[0];
            DecoratedSignature signature;
            if (Constants.NoPrivateKey.Equals(seed, StringComparison.Ordinal))
            {
                signature = new DecoratedSignature
                {
                    Hint = new SignatureHint(new byte[4]),
                    Signature = new Signature(new byte[64])
                };
            }
            else 
            {
                var signer = KeyPair.FromSeed(seed);
                signature = signer.SignDecorated(txHash);
            }

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
            return Utilities.Hash(data);
        }

        private string CreateEnvelopeXdrBase64(StellarBase.Generated.Transaction tx, DecoratedSignature signature)
        {
            var txEnvelope = new TransactionEnvelope
            {
                Tx = tx,
                Signatures = new[] { signature }
            };

            var writer = new ByteWriter();
            TransactionEnvelope.Encode(writer, txEnvelope);
            var data = writer.ToArray();
            return Convert.ToBase64String(data);
        }
    }
}
