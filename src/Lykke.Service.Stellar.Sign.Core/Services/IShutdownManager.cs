using System.Threading.Tasks;

namespace Lykke.Service.Stellar.Sign.Core.Services
{
    public interface IShutdownManager
    {
        Task StopAsync();
    }
}