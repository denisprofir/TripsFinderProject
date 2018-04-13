using System.Collections.Generic;
using TripsFinder.Data.Domain.DomainModels.Concrete;

namespace TripsFinder.Data.Interfaces.RepositoryInterfaces
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
