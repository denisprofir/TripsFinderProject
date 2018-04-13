using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TripsFinder.Data.Domain.DomainModels.Concrete;
using TripsFinder.Data.Interfaces.RepositoryInterfaces;

namespace TripsFinder.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context, DbSet<T> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public T Get(long id)
        {
            return _dbSet.FirstOrDefault(t => t.Id == id);
        }

        public void Add(T element)
        {
            if (element == null)
                throw new ArgumentNullException(paramName: nameof(element));

            _dbSet.Add(element);
        }

        public void Update(T element)
        {
            if (element == null)
                throw new ArgumentNullException(paramName: nameof(element));

            _context.Entry(element).State = EntityState.Modified;
        }

        public void Delete(T element)
        {
            if (element == null)
                throw new ArgumentNullException(paramName: nameof(element));

            _dbSet.Remove(element);
        }

        public void Delete(long id)
        {
            T element = _dbSet.Find(id);

            if (element != null)
                _dbSet.Remove(element);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
