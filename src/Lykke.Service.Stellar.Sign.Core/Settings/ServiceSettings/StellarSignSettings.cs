namespace Lykke.Service.Stellar.Sign.Core.Settings.ServiceSettings
{
    public class StellarSignSettings
    {
        public DbSettings Db { get; set; }

        public string NetworkPassphrase { get; set; }

        public string DepositBaseAddress { get; set; }
    }
}
