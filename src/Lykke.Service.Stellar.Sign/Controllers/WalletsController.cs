using System.Net;
using Microsoft.AspNetCore.Mvc;
using Lykke.Service.Stellar.Sign.Core.Services;
using Lykke.Service.Stellar.Sign.Models;

namespace Lykke.Service.Stellar.Sign.Controllers
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
        [ProducesResponseType(typeof(WalletResponse), (int)HttpStatusCode.OK)]
        public IActionResult Post()
        {
            var keyPair = _stellarService.GenerateKeyPair();

            return Ok(new WalletResponse
            {
                PrivateKey = keyPair.Seed,
                PublicAddress = keyPair.Address,
                AddressContext = string.Empty
            });
        }
    }
}