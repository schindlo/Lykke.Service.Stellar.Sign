namespace Lykke.Service.Stellar.Sign.Models
{
    public class SignRequest
    {
        public string[] PrivateKeys { get; set; }

        public string TransactionContext { get; set; }
    }
}
