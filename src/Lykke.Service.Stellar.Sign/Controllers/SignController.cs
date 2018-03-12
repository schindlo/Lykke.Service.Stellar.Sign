using System.Net;
using Microsoft.AspNetCore.Mvc;
using Lykke.Service.Stellar.Sign.Core.Services;
using Lykke.Service.Stellar.Sign.Models;
using Lykke.Common.Api.Contract.Responses;

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
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public IActionResult SignTransaction([FromBody]SignRequest request)
        {
            if (request.PrivateKeys == null || request.PrivateKeys.Length < 1)
            {
                return BadRequest(ErrorResponse.Create("Invalid parameter").AddModelError("request.privateKeys", "Must contain at least one item"));
            }
            if (string.IsNullOrWhiteSpace(request.TransactionContext))
            {
                return BadRequest(ErrorResponse.Create("Invalid parameter").AddModelError("request.transactionContext", "Must be non empty"));
            }

            var xdrSigned = _stellarService.SignTransaction(request.PrivateKeys, request.TransactionContext);
            return Ok(new SignResponse
            {
                SignedTransaction = xdrSigned
            });
        }
    }
}
