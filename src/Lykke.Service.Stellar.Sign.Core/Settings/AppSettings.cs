using Lykke.Service.Stellar.Sign.Core.Settings.ServiceSettings;
using Lykke.Service.Stellar.Sign.Core.Settings.SlackNotifications;

namespace Lykke.Service.Stellar.Sign.Core.Settings
{
    public class AppSettings
    {
        public StellarSignSettings StellarSignService { get; set; }

        public SlackNotificationsSettings SlackNotifications { get; set; }
    }
}
