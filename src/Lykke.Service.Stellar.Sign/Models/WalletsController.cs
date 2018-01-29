using Lykke.Service.Stellar.Sign.Core.Services;
using Lykke.Service.Stellar.Sign.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
namespace Lykke.Service.Stellar.Sign.Models
{
    [Route("api/wallets")]
    public class WalletsController : Controller
    {
        private readonly IStellarService _stellarService;

        public WalletsController(IStellarService stellarService)
        {
            _stellarService = stellarService;
        }

        [HttpPost]
        public WalletResponse Post()
        {
            var privateKey = _stellarService.GetPrivateKey();
            var publicAddress = _stellarService.GetPublicAddress(privateKey);

            return new WalletResponse()
            {
                PrivateKey = privateKey,
                PublicAddress = publicAddress
            };
        }
    }
}