using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace YO.Framework.Dal.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DbContext _context;
        private DbSet<T> _dbset;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }
      
        public IQueryable<T> GetAll()
        {
            return _dbset;
        }

        public T Find(Guid Id)
        {
            return _dbset.Find(Id);
        }

        public T Update(T entityToUpdate)
        {
            _dbset.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
            return entityToUpdate;
        }

        public T Add(T entity)
        {
            _dbset.Add(entity);
            return entity;
        }
        public void Delete(Guid Id)
        {
            Delete(Find(Id));
        }

        public void Delete(T entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _context.Attach(entityToDelete);
            }
            _dbset.Remove(entityToDelete);
        }
        
    }
}
