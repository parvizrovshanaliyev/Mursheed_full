using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ERP.Atlas.Utility;

namespace ERP.Atlas.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> Repository<T>() where T : class;

        Task<TransResult<int>> Commit();

        void Rollback();
    }
}
