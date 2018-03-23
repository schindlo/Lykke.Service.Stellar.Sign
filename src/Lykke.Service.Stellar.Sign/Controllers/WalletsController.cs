using System.Net;
using Microsoft.AspNetCore.Mvc;
using Lykke.Service.Stellar.Sign.Core.Services;
using Lykke.Service.Stellar.Sign.Models;
using Lykke.Service.Stellar.Sign.Core.Domain;

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
            var baseAddress = _stellarService.GetDepositBaseAddress();
            var memoText = _stellarService.GenerateRandomMemoText();

            return Ok(new WalletResponse
            {
                PrivateKey = Constants.NoPrivateKey,
                PublicAddress = $"{baseAddress}{Constants.PublicAddressExtension.Separator}{memoText}",
                AddressContext = string.Empty
            });
        }
    }
}