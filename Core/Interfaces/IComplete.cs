using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IComplete
    {
        Task<int> CompleteAsync();
    }
}
