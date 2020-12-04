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
            try
            {
                _transaction = _context.Database.BeginTransaction();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }

        public bool RollBackTransaction()
        {
            try
            {
                _transaction.Rollback();
                _transaction = null;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int SaveChanges()
        {
            var transcation = _transaction != null ? _transaction : _context.Database.BeginTransaction();
            using (transcation)
            {
                try
                {
                    if (_context == null)
                    {
                        throw new ArgumentException("Context is null");
                    }
                    int result = _context.SaveChanges();
                    transcation.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    _transaction.Rollback();

                    throw new Exception("Error on save",ex);
                }
            }
        }
    }
}
