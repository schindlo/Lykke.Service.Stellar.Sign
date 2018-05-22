using Autofac;
using Common.Log;
using Lykke.Service.Stellar.Sign.Core.Services;
using Lykke.Service.Stellar.Sign.Core.Settings.ServiceSettings;
using Lykke.Service.Stellar.Sign.Services;
using Lykke.SettingsReader;

namespace Lykke.Service.Stellar.Sign.Modules
{
    public class ServiceModule : Module
    {
        private readonly IReloadingManager<StellarSignSettings> _settings;
        private readonly ILog _log;

        public ServiceModule(IReloadingManager<StellarSignSettings> settings,
                             ILog log)
        {
            _settings = settings;
            _log = log;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_log)
                .As<ILog>()
                .SingleInstance();

            builder.RegisterType<HealthService>()
                .As<IHealthService>()
                .SingleInstance();

            builder.RegisterType<StartupManager>()
                .As<IStartupManager>();

            builder.RegisterType<ShutdownManager>()
                .As<IShutdownManager>();

            builder.RegisterType<StellarService>()
                   .As<IStellarService>()
                   .WithParameter("network", _settings.CurrentValue.NetworkPassphrase)
                   .WithParameter("depositBaseAddress", _settings.CurrentValue.DepositBaseAddress)
                   .SingleInstance();
        }
    }
}
