using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using YO.Framework.Dal.Repository;

namespace YO.Framework.Dal.UoW
{
    public class UoW : IUoW
    {
        private readonly DbContext _context;
        private IDbContextTransaction _transaction;
        private bool _disposed;

        public UoW(DbContext context)
        {
            _context = context;
        }

        public bool BeginNewTransaction()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public bool RollBackTransaction()
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
