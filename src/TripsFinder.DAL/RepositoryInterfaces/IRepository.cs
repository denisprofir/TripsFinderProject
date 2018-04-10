using System;
using System.Collections.Generic;
using System.Text;
using TripsFinder.DAL.Models.Concrete;

namespace TripsFinder.DAL.RepositoryInterfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Add(T element);
        void Update(T element);
        void Delete(T element);
        void Delete(long id);
        void Save();
    }
}
