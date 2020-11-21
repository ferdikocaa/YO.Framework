using System;
using System.Linq;

namespace YO.Framework.Dal.Repository
{
    public interface IGenericRepository<TEntiy> where TEntiy : class
    {
        IQueryable<TEntiy> GetAll();
        TEntiy Find(Guid Id);
        TEntiy Add(TEntiy entity);
        TEntiy Update(TEntiy entityToUpdate);
        void Delete(Guid Id);
        void Delete(TEntiy entityToDelete);
    }
}
