using System.Threading.Tasks;
using ERP.Mursheed.Utility;

namespace Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> Repository<T>() where T : class;

        Task<TransResult<int>> Commit();

        void Rollback();
    }
}
