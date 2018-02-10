using Newtonsoft.Json;

namespace Lykke.Service.Stellar.Sign.Models
{
    public class SignResponse
    {
        [JsonProperty("signedTransaction")]
        public string SignedTransaction { get; set; }
    }
}
