using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.Stellar.Sign.Core.Settings.ServiceSettings
{
    public class DbSettings
    {
        [AzureTableCheck]
        public string LogsConnString { get; set; }
    }
}