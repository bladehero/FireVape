using System.Threading.Tasks;

namespace FireVape.Interfaces.Data.Repositories
{
    public interface IAsyncSaveable
    {
        bool IsSaved { get; }
        Task SaveAsync();
    }
}
