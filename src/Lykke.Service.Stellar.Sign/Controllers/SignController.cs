using System.Net;
using Microsoft.AspNetCore.Mvc;
using Lykke.Service.Stellar.Sign.Core.Services;
using Lykke.Service.Stellar.Sign.Models;

namespace Lykke.Service.Stellar.Sign.Controllers
{
    [Route("api/sign")]
    public class SignController : Controller
    {
        private readonly IStellarService _stellarService;

        public SignController(IStellarService stellarService)
        {
            _stellarService = stellarService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(SignResponse), (int)HttpStatusCode.OK)]
        public IActionResult SignTransaction([FromBody]SignRequest request)
        {
            var xdrSigned = _stellarService.SignTransaction(request.PrivateKeys, request.TransactionContext);
            return Ok(new SignResponse
            {
                SignedTransaction = xdrSigned
            });
        }
    }
}
