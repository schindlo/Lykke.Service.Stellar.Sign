using System;
using Autofac;
using Common.Log;

namespace Lykke.Service.Stellar.Sign.Client
{
    public static class AutofacExtension
    {
        public static void RegisterStellar.SignClient(this ContainerBuilder builder, string serviceUrl, ILog log)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            if (serviceUrl == null) throw new ArgumentNullException(nameof(serviceUrl));
            if (log == null) throw new ArgumentNullException(nameof(log));
            if (string.IsNullOrWhiteSpace(serviceUrl))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(serviceUrl));

            builder.RegisterType<Stellar.SignClient>()
                .WithParameter("serviceUrl", serviceUrl)
                .As<IStellar.SignClient>()
                .SingleInstance();
        }

        public static void RegisterStellar.SignClient(this ContainerBuilder builder, Stellar.SignServiceClientSettings settings, ILog log)
        {
            builder.RegisterStellar.SignClient(settings?.ServiceUrl, log);
        }
    }
}
