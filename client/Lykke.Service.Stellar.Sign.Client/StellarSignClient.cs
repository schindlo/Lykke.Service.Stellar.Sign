using System;
using Common.Log;

namespace Lykke.Service.Stellar.Sign.Client
{
    public class StellarSignClient : IStellarSignClient, IDisposable
    {
        private readonly ILog _log;

        public StellarSignClient(string serviceUrl,
                                 ILog log)
        {
            _log = log;
        }

        public void Dispose()
        {
            //if (_service == null)
            //    return;
            //_service.Dispose();
            //_service = null;
        }
    }
}
