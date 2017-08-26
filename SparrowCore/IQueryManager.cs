using System.Threading.Tasks;

namespace SparrowCore
{
    public interface IQueryManager
    {
        Task Connect();

        void Disconnect();
    }
}