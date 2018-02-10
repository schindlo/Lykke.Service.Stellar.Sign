using Newtonsoft.Json;

namespace Lykke.Service.Stellar.Sign.Models
{
    public class WalletResponse
    {
        [JsonProperty("privateKey")]
        public string PrivateKey { get; set; }

        [JsonProperty("publicAddress")]
        public string PublicAddress { get; set; }

        [JsonProperty("addressContext")]
        public string AddressContext { get; set; }
    }
}