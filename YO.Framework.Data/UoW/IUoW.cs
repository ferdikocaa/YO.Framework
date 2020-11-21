using System;
using YO.Framework.Dal.Repository;

namespace YO.Framework.Dal.UoW
{
    public interface IUoW : IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : class;
        bool BeginNewTransaction();
        bool RollBackTransaction();
        int SaveChanges();
    }
}
